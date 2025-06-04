using FileService.Interfaces;
using FileService;
using models;
using models.Interface;
using ServiceCL;
using pizza.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using pizza.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Ipizza,PizzaSrevice>();
builder.Services.AddTransient<OrderInter,OrderServ>();
builder.Services.AddScoped<Iworker,WorkerService>();
builder.Services.AddSingleton<IFileService<PizzaTata>>(new ReadWrite<PizzaTata>(@"L:/webAPI/הגשות/lesson6/שיפי הורוביץ ואביגיל צ'רנוביצקי/webapi6/JsonConvert.json"));
builder.Services.AddSingleton<IFileService<string>>(new ReadWrite<string>(@"C:\Users\user\Documents\לימודים-אביגיל\webapi\webapi-lesson6\webapi6\pizza\Actionlog.txt"));
builder.Services.AddSingleton<IFileService<Worker>>(new ReadWrite<Worker>(@"pizza\worker.json"));
builder.Services
      .AddAuthentication(options =>
      {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(cfg =>
      {
          cfg.RequireHttpsMetadata = false;
          cfg.TokenValidationParameters = PizzaTokenService.GetTokenValidationParameters();
      });
      builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("role", "Admin"));
    cfg.AddPolicy("superworker", policy => policy.RequireClaim("role", "superworker"));
    
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIZZATATA", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
                });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();
app.MapControllers();

// app.UseDefaultFiles();
// app.UseStaticFiles();
// app.UseHttpsRedirection();

app.Userc();
app.Run();


