using InternshipPlatformAPI.Data;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using InternshipPlatformAPI.Services.SelectionService;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.Text.Json.Serialization;
using System.Text;
using InternshipPlatformAPI.Services.UsersService;
using InternshipPlatformAPI.Services.EmailService;
using SendGrid.Extensions.DependencyInjection;
using InternshipPlatformAPI.Services.ApplicationService;
using InternshipPlatformAPI.Services.LoginService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Internship API",
        Version = "v1",
        Description = "Intership api services",
        Contact = new OpenApiContact
        {
            Name = "."
        }
    });
    c.ResolveConflictingActions(apiDescription => apiDescription.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string []{}
        }
    });
});
builder.Services.AddDbContextPool<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredUniqueChars = 0;
    //o.Password.
    //o.User.RequireUniqueEmail = true;
    
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ISelectionService, SelectionService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddSendGrid(options =>
    options.ApiKey = builder.Configuration.GetValue<string>("SendGridApiKey")
                     ?? throw new Exception("The 'SendGridApiKey' is not configured")
);
builder.Services.AddTransient<IEmailService, EmailService>();
//builder.Services.AddCors(options => options.AddPolicy("AllowAccess_To_API", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
var jwtConfig = builder.Configuration.GetSection("jwtConfig");
var secretKey = jwtConfig["secret"];
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["validIssuer"],
        ValidAudience = jwtConfig["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

    };
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseCors("AllowAccess_To_API");
app.MapControllers();
app.Run();
