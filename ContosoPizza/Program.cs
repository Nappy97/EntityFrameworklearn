using ContosoPizza.Data;
using ContosoPizza.Services;

// Additional using declarations

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the PizzaContext
// PizzaContext를 ASP.NET Core의 종속성 삽입 시스템에 등록합니다.
// PizzaContext가 SQLite 데이터베이스 공급자를 사용하도록 지정합니다.로컬 파일 ContosoPizza.db를 가리키는 SQLite 연결 문자열을 정의합니다.
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

// Add the PromotionsContext

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Add the CreateDbIfNotExists method call
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();