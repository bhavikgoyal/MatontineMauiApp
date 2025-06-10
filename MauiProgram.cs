﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Maui.TouchEffect.Hosting;

namespace MatontineDigitalApp;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        .UseMauiTouchEffect()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
          fonts.AddFont("MaterialIconsRegular.ttf", "Material");
        });

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }
}