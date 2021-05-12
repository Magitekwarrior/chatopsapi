using System;
using chatopsapi.Infrastructure.Extensions;
using chatopsapi.Infrastructure.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace chatopsapi
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
      services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
      
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddCustomHealthChecks(Configuration);
      services.AddCustomConfigurationDI(Configuration);
      services.AddCustomInfrastructureDI();
      services.AddCustomServicesDI();

      services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

      services.AddControllers();

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatOpsApi", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicTacToe v1"));
      }

      app.UseCors(Configuration);

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
