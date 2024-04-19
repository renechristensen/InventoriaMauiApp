﻿using CommunityToolkit.Maui;
using InventoriaMauiApp.Services;
using Microsoft.Extensions.Logging;
using Polly.Extensions.Http;
using Polly;

namespace InventoriaMauiApp
{
    public static class MauiProgram
    {
        // ngrok url, remember to replace it with new ones
        public static string baseUrl = "https://deep-wealthy-roughy.ngrok-free.app";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            // add httpclients for each service
            RegisterHttpClients(services);
            // add viewmodels
            RegisterViewModels(services);
            //add pages
            RegisterPages(services);
        }
        private static void RegisterHttpClients(IServiceCollection services)
        {
            var retryPolicy = GetRetryPolicy();

            var httpClientConfig = new Action<HttpClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            //services.AddHttpClient<IUserService, UserService>(httpClientConfig)
            //        .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            //        .AddPolicyHandler(retryPolicy);
        }
        private static void RegisterViewModels(IServiceCollection services)
        {
            var viewModels = new List<Type>
            {
                //typeof(UserLoginViewModel)
            };

            viewModels.ForEach(viewModelType => services.AddTransient(viewModelType));
        }

        private static void RegisterPages(IServiceCollection services)
        {
            var pages = new List<Type>
            {
                //typeof(LoginPage)
            };

            pages.ForEach(pageType => services.AddTransient(pageType));
        }
        // add in polly to help configure http client factory
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}
