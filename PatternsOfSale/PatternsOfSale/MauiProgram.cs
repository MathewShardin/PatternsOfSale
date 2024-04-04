﻿using Microsoft.Extensions.Logging;
using PatternsOfSale.Models;
using Microsoft.Maui.LifecycleEvents;
using PatternsOfSale.ViewModels;
using PatternsOfSale.Views;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PatternsOfSale
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services
                .AddViewModels()
                .AddViews()
                .AddSingleton<GameManager>()
                .AddSingleton<GameTimer>();

            var app = builder.Build();
            GameTimer timer = app.Services.GetRequiredService<GameTimer>();
            GameManager manager = app.Services.GetService<GameManager>();

            timer.AddSubscriber(manager);

            // Launch the timer forever on a seprate thread
            Thread threadTimer = new Thread(() =>
            {
                while (true)
                {
                    while (manager.isGameRunning == true)
                    {
                        timer.SendTick();
                    }

                }
            });
            threadTimer.IsBackground = true;
            threadTimer.Start();

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            // Make sure to add "using Microsoft.Maui.LifecycleEvents;" in the top of the file 
            events.AddWindows(windowsLifecycleBuilder =>
            {
                windowsLifecycleBuilder.OnWindowCreated(window =>
                {
                    window.ExtendsContentIntoTitleBar = false;
                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                    switch (appWindow.Presenter)
                    {
                        case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                            overlappedPresenter.SetBorderAndTitleBar(false, false);
                            overlappedPresenter.Maximize();
                            break;
                    }
                });
            });
        });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            //return builder.Build();
            return app;
        }
    }
}
