using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApuestasApi.Models;
using ApuestasApi.Repositories.IRepositories;
using ApuestasApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using ApuestasApi.Models;

namespace ApuestasApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Correr
            //Scaffold-DbContext "{ConnectionString}" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models
            //Para importar modelos desde la base de datos

            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "5432";
            var user = Configuration["DBUser"] ?? "postgres";
            var password = Configuration["Password"] ?? "moki-moki24";
            var database = Configuration["Database"] ?? "Lotto";
            services.AddDbContext<LottoContext>(options =>
                options.UseNpgsql($"Server={server};Database={database};Port={port};UserId={user};Password={password}")
                //options.UseNpgsql(Configuration.GetConnectionString("Prueba"))
            );
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Animalitos.com",
                    ValidAudience = "Animalitos.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret_Key"])),
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KSAJDFLKSDAJNVKJASNAWPWORQIRPOWEQ")),
                    ClockSkew = TimeSpan.Zero
                });
            services.AddScoped<IEstatusRepository, EstatusRepository>();
            services.AddScoped<ITypeGameRepository, TypeGameRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IPlaysRepository, PlaysRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApuestasApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApuestasApi v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
