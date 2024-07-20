using TagFin.Services;

var builder = WebApplication.CreateBuilder(args);


var _AdminConnectionString = builder.Configuration.GetConnectionString("AdminConnection");
var _FinConnectionString = builder.Configuration.GetConnectionString("FinConnection");

//services
builder.Services.AddTransient<CustomerService>(c => new CustomerService(_AdminConnectionString, _FinConnectionString));
builder.Services.AddTransient<AccountService>(c => new AccountService(_AdminConnectionString, _FinConnectionString));
builder.Services.AddTransient<BranchService>(c => new BranchService(_AdminConnectionString, _FinConnectionString));

// Configure the HTTP request pipeline.

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE"));

app.UseAuthorization();

app.MapControllers();

app.Run();
