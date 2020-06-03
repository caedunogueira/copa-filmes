using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using CopaFilmes.WebAPI.Infra.Implementacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.WebAPI
{
    public class Startup
    {
        public readonly string PoliticaOrigemCopaMundoSPA = "_origemCopaMundoSPA";

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OpcoesCatalogoFilmes>(Configuration.GetSection(OpcoesCatalogoFilmes.CatalogoFilmes));
            services.AddHttpClient<ICatalogoFilmes, CatalogoFilmesWebAPI>();

            services.AddCors(opcoes =>
            {
                opcoes.AddPolicy(PoliticaOrigemCopaMundoSPA,
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetSection("SPA:Endereco").Value);
                    });
            });

            services.AddControllers();
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

            app.UseCors(PoliticaOrigemCopaMundoSPA);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
