using CommunityMauiMediaElement.ViewModels;
using CommunityMauiMediaElement.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CommunityMauiMediaElement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<MyPage>();
            builder.Services.AddTransient<MyViewModel>();

            return builder.Build();
        }
    }
}
