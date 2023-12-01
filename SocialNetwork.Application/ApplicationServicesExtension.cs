using SocialNetwork.Application.Helpers;
using SocialNetwork.Application.Services;
using SocialNetwork.Application.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JobResearchSystem.Application.Behaviors;
using MediatR;
using FluentValidation;

namespace SocialNetwork.Application
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ISMSService, SMSService>();

            services.AddScoped<IChatService, ChatService>();


            services.Configure<MailSettings>(configuration.GetSection(MailSettings.SectionKey));
            services.Configure<TwilioSettings>(configuration.GetSection(TwilioSettings.SectionKey));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
