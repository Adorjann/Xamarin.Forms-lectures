using FirstMobileApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstMobileApp.Services
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainViewModel MainViewModel => _serviceProvider.GetService<MainViewModel>();

        public NoteEditorViewModel NoteEditorViewModel => _serviceProvider.GetService<NoteEditorViewModel>();
    }
}