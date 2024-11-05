using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SustenAI.Configuration;
using SustenAI.DataBase;
using SustenAI.Repository;

namespace SustenAI.Extentions
{
    public static class  ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IPrevisaoRepository, PrevisaoRepository>();

            return service;
        }

        public static IServiceCollection AddDBContexts(this IServiceCollection service, AppConfiguration appConfiguration)
        {
            service.AddDbContext<SustenAIDBContext>(options =>
            {
                options.UseOracle(appConfiguration.ConnectionStrings.OracleFIAP);
            });

            return service;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection service, AppConfiguration appConfiguration)
        {

            service.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact()
                    {
                        Email = appConfiguration.Swagger.Email,
                        Name = appConfiguration.Swagger.Name
                    }
                }
                );
            });


            return service;
        }
    }
}
