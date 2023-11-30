using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Extensions;
using SocialNetwork.Application.Errors;
using SocialNetwork.Application.Middlewares;
using SocialNetwork.Application.Services;
using SocialNetwork.Application;
using SocialNetwork.Infrastructure.Data;
using SocialNetwork.Infrastructure.Identity;
using SocialNetwork.Infrastructure.Repositories;
using SocialNetwork.Infrastructure.Repositories.Contract;
using SocialNetwork.Infrastructure;
using SocialNetwork.Application.GraphQL;

namespace SocialNetwork.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDefault")));

            builder.Services.AddIdentityServices(builder.Configuration);

            #region Validation Behavior

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(x => x.Value?.Errors.Count > 0)
                                            .SelectMany(x => x.Value.Errors)
                                            .Select(x => x.ErrorMessage)
                                            .ToList();

                    var validationErrorResponse = new ApiValidationErrorResponse() { Errors = errors };

                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });
            #endregion

            builder.Services.AddApplicationsServices(builder.Configuration);
            builder.Services.AddInfrastructureDependencies();


            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddScoped<IPostService, PostService>();


            builder.Services
                .AddGraphQLServer()
                .RegisterDbContext<AppDbContext>()
                .AddQueryType<BaseQuery>()
                .AddProjections()
                .AddSorting()
                .AddFiltering()
                ;


            builder.Services.AddSwaggerServices();


            var app = builder.Build();

            await app.UpdateDatabase();

            app.UseSwaggerMiddlewares();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}