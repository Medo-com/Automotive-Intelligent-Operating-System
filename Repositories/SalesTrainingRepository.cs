using AIOS.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AIOS.Repositories
{
    public class SalesTrainingRepository
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public SalesTrainingRepository(IConfiguration config)
        {
            _http = new HttpClient();
            _apiKey = config["OpenAI:ApiKey"]; // store your key in appsettings.json

            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new Exception("Missing OpenAI API key in configuration.");
        }

        public SalesTrainingResult GetReply(SalesTrainingRequest req)
        {
            return GenerateAIResponse(req).Result;
        }

        private async Task<SalesTrainingResult> GenerateAIResponse(SalesTrainingRequest req)
        {
            var messages = new List<object>();

            // SYSTEM PROMPT (AI Personality Setup)
            messages.Add(new
            {
                role = "system",
                content = @$"
You are simulating a REAL car dealership customer.
Your goal is to respond realistically, based on:

• Personality: {req.Personality}
• Scenario: {req.Scenario}

Behaviors by personality:
- Analytical: logical, wants numbers, slow to trust.
- Emotional: influenced by feelings, needs reassurance.
- Impatient: short replies, hates long explanations.
- Price-Focused: insists on lowest price, skeptical of add-ons.
- Skeptical: questions everything.

Scenarios:
PaymentTooHigh — customer thinks payment is too high.
TradeInLow — customer feels their trade-in value is too low.
Undecided — customer isn’t convinced yet.
ShoppingAround — customer compares you to competitors.

Rules:
- Respond like a natural human.
- DO NOT repeat the same sentence.
- Vary your tone, emotions, and detail.
- Consider the salesperson's last message.
- Speak as a customer, not an AI.
- RETURN ONLY the customer reply, nothing else.
"
            });

            // Add conversation history
            foreach (var turn in req.History)
            {
                messages.Add(new
                {
                    role = turn.Role == "salesperson" ? "user" : "assistant",
                    content = turn.Content
                });
            }

            // Add the latest user message
            if (!string.IsNullOrWhiteSpace(req.UserMessage))
            {
                messages.Add(new
                {
                    role = "user",
                    content = req.UserMessage
                });
            }

            // COACH AI
            var coachPrompt = @$"
You are a sales coaching AI.
Given the salesperson's last message: '{req.UserMessage}',
give a short, helpful coaching tip.
Focus on:
- technique
- tone
- improving rapport
- improving deal structure
Return 1–2 sentences ONLY.
";

            // Build request
            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = messages,
                max_tokens = 180,
                temperature = 0.8,
                n = 1
            };

            var coachBody = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = "You are an expert car sales coach." },
                    new { role = "user", content = coachPrompt }
                },
                max_tokens = 120,
                temperature = 0.6
            };

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            // Send main customer reply request
            var response = await _http.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            );

            var coachResponse = await _http.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(coachBody), Encoding.UTF8, "application/json")
            );

            var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var jsonCoach = JsonDocument.Parse(await coachResponse.Content.ReadAsStringAsync());

            var reply = json.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            var coach = jsonCoach.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return new SalesTrainingResult
            {
                CustomerReply = reply,
                CoachComment = coach
            };
        }
    }
}
