using APIRepository.Contracts;
using APIRepository.Repositories;
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


namespace APIApresention
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

            #region Configuração do Swagger
            services.AddSwaggerGen(s =>
            {
                new OpenApiInfo
                {
                    Title = "Acesso De Arquivos de Fucionario",
                    Version = "v1",
                    Description = "Sistema desenvolvido em NET CORE API com Dapper",
                    Contact = new OpenApiContact
                    {
                        Name = "RhFuncionario",
                        Url = new Uri("http://www.RHFuncionario.com.br"),
                        Email = "Rhfuncionario@gmail.com.br"
                    }


                };
            });
            #endregion

            #region Inicializando os repositórios
            //ler a connectionstring mapeada no arquivo [appsettings.json]..
            var connectionstring = Configuration.GetConnectionString("APICadastroAutenticacao");
            //inicializando as classes do repositorio, passando para elas
            //o endereço da connectionstring do banco de dados..

             services.AddTransient
            (map => new UsuarioRepository(connectionstring));


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
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

            app.UseAuthorization();

            #region Configuração do Swagger

            app.UseSwagger();

            app.UseSwaggerUI(s => s.SwaggerEndpoint
           ("/swagger/v1/swagger.json", "projeto"));

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

} 

