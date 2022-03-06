using FirstMobileApp.Models;

namespace FirstMobileApp.Services
{
    public interface INavigationService
    {
        void NavigateToNoteEditor(Note note);

        void NavigatToNewNote();

        void GoBack();
    }
}