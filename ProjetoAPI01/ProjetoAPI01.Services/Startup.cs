using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoAPI01.CrossCutting;
using ProjetoAPI01.CrossCutting.Settings;
using ProjetoAPI01.Repository.Contexts;
using ProjetoAPI01.Repository.Interfaces;
using ProjetoAPI01.Repository.Repositories;
using System;
using System.Text;

namespace ProjetoAPI01.Services
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
            services.AddControllers();

            #region EntityFramework

            //configurar a classe DbContext (SqlServerContext)
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("ProjetoAPI01")));

            //adicionar as interfaces / classes de repositorio criadas no projeto..
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Swagger

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "API Controle de Empresas e Funcionários",
                        Description = "API REST desenvolvida em .NET CORE com EntityFramework",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "COTI Informática",
                            Url = new Uri("http://www.cotiinformatica.com.br"),
                            Email = "contato@cotiinformatica.com.br"
                        }
                    });
                }
                );

            #endregion

            #region AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region CORS

            services.AddCors(s => s.AddPolicy("DefaultPolicy",
                builder => {
                    builder.AllowAnyOrigin()  //qualquer servidor pode fazer requisições
                           .AllowAnyMethod()  //qualquer método (POST PUT DELETE ou GET)
                           .AllowAnyHeader(); //qualquer informação de cabeçalho
                }));

            #endregion

            #region JWT

            var settingsSection = Configuration.GetSection("TokenSettings");
            services.Configure<TokenSettings>(settingsSection);

            var appSettings = settingsSection.Get<TokenSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new TokenService(appSettings));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region CORS

            app.UseCors("DefaultPolicy");

            #endregion

            app.UseAuthentication();
            app.UseAuthorization();

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(swagger => { swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "COTI API"); });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
