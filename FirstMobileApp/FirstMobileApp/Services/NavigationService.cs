using FirstMobileApp.Models;
using FirstMobileApp.ViewModels;
using FirstMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FirstMobileApp.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateToNoteEditor(Note note)
        {
            var vm = App.Locator.NoteEditorViewModel;
            vm.LoadNote(note);

            Application.Current
                    .MainPage
                    .Navigation
                    .PushModalAsync(new NoteView { BindingContext = vm });
        }

        public void GoBack()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();

            var lastView = Application.Current.MainPage.Navigation.NavigationStack.Last();
            if (lastView is MainPage mainPage && mainPage.BindingContext is MainViewModel mainViewModel)
            {
                mainViewModel.LoadNotes();
            }
        }

        public void NavigatToNewNote()
        {
            var vm = App.Locator.NoteEditorViewModel;

            Application.Current
                .MainPage
                .Navigation
                .PushModalAsync(new NoteView { BindingContext = vm });
        }
    }
}