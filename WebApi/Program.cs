using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.AutoFac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Encryption;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var devCorsPolicy = "devCorsPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(devCorsPolicy, builder => {
                    //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                    //builder.SetIsOriginAllowed(origin => true);
                });
            });
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience= tokenOptions.Audience,
                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey=SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                };
            }
            );




            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder=>builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            


            app.MapControllers();

            app.Run();
        }
    }
}