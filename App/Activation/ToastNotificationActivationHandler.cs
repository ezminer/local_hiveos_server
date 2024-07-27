﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Extensions.Configuration;

using MyApp.Contracts.Activation;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;

namespace MyApp.Activation
{
  
    public class ToastNotificationActivationHandler : IActivationHandler
    {
        public const string ActivationArguments = "ToastNotificationActivationArguments";

        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;

        public ToastNotificationActivationHandler(IConfiguration config, IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _config = config;
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public bool CanHandle()
        {
            return !string.IsNullOrEmpty(_config[ActivationArguments]);
        }

        public async Task HandleAsync()
        {
            if (App.Current.Windows.OfType<IShellWindow>().Count() == 0)
            {
                // Here you can get an instance of the ShellWindow and choose navigate
                // to a specific page depending on the toast notification arguments
            }
            else
            {
                App.Current.MainWindow.Activate();
                if (App.Current.MainWindow.WindowState == WindowState.Minimized)
                {
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                }
            }

            await Task.CompletedTask;
        }
    }
}
