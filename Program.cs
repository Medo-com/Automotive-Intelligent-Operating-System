using AIOS.Configuration;
using AIOS.Repositories;

var builder = WebApplication.CreateBuilder(args);

// =========================
// MVC + JSON OPTIONS
// =========================
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// =========================
// MONGODB SETTINGS
// =========================
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


// =========================
// REPOSITORIES (DI)
// =========================

// AI Sales Training Simulator
builder.Services.AddSingleton<SalesTrainingRepository>();

// Newsletter
builder.Services.AddSingleton<NewsletterRepository>();

// Customer
builder.Services.AddSingleton<CustomerRepository>();

// Appointment
builder.Services.AddSingleton<AppointmentRepository>();

// Vehicle
builder.Services.AddSingleton<VehicleRepository>();

// AI Pricing
builder.Services.AddSingleton<AiPricingRepository>();

// AI Loan Approval
builder.Services.AddScoped<LoanApprovalRepository>();


// =========================
// CORS POLICY
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// =========================
// TEST MONGODB CONNECTION
// =========================
try
{
    var customerRepo = app.Services.GetRequiredService<CustomerRepository>();
    var customers = await customerRepo.GetAllAsync();

    Console.WriteLine($"? MongoDB connected! Found {customers.Count} customer(s).");
}
catch (Exception ex)
{
    Console.WriteLine($"? MongoDB connection error: {ex.Message}");
    Console.WriteLine("Check your connection string in appsettings.json");
}


// =========================
// MIDDLEWARE PIPELINE
// =========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable CORS globally
app.UseCors("AllowAll");

app.UseAuthorization();


// =========================
// ROUTING
// =========================

// MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// API routes
app.MapControllers();

app.Run();
