using Calculator.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet($"/{OperationConsts.Add}/{{a}}/{{b}}/", (double a, double b) => OperationCalculator.CalculateAdd(a, b).ToString());
app.MapGet($"/{OperationConsts.Multiply}/{{a}}/{{b}}/", (double a, double b) => OperationCalculator.CalculateMultiply(a, b).ToString());
app.MapGet($"/{OperationConsts.Subtract}/{{a}}/{{b}}/", (double a, double b) => OperationCalculator.CalculateSubtract(a, b).ToString());
app.MapGet($"/{OperationConsts.Divide}/{{a}}/{{b}}/", (double a, double b) => OperationCalculator.CalculateDivide(a, b).ToString());

app.Run();
