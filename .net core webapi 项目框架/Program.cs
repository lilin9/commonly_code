using api.Extensions;
using api.model;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//自动注入所有的 Service 层类
builder.Services.AddServiceFromAssembly();


builder.Services.AddControllers(opt => {
    //注册统一响应管理拦截器
    opt.Filters.Add<ResponseActionFilter>();
});

//注入 MySqlDbContext
var dbConnectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();