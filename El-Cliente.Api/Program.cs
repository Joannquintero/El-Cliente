using El_Cliente.Api.Data;
using El_Cliente.Api.Repository.Availability;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Api.Repository.Branch;
using El_Cliente.Api.Repository.Customer;
using El_Cliente.Api.Repository.Product;
using El_Cliente.Api.Repository.Registration;
using El_Cliente.Api.Repository.Transaction;
using El_Cliente.Api.Repository.Visit;
using El_Cliente.Api.Services.Availability;
using El_Cliente.Api.Services.Balance;
using El_Cliente.Api.Services.Branch;
using El_Cliente.Api.Services.Customer;
using El_Cliente.Api.Services.Funds;
using El_Cliente.Api.Services.Product;
using El_Cliente.Api.Services.Registration;
using El_Cliente.Api.Services.Visit;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped<IAvailabilityServices, AvailabilityServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IBranchServices, BranchServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IRegistrationServices, RegistrationServices>();
builder.Services.AddScoped<IVisitServices, VisitServices>();
builder.Services.AddScoped<IBalanceServices, BalanceServices>();
builder.Services.AddScoped<IFundServices, FundServices>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();
builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();