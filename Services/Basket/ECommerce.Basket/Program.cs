using ECommerce.Basket.LoginServices;
using ECommerce.Basket.Services;
using ECommerce.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceBasket";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginServices>();
builder.Services.AddScoped<IBasketService, BasketServices>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("ResourceBasket"));
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redissseting = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redissseting.Host, redissseting.Port);
    redis.Connect();
    return redis;
});
builder.Services.AddControllers( opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
