using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ToDoDemo.Services.NavigationService
{
    public interface INavigatable
    {
        void OnNavigatedTo(string parameter, NavigationMode mode, IDictionary<string, object> state);
        void OnNavigatedFrom(Dictionary<string, object> state, bool suspending);
        void OnNavigatingFrom(NavigatingEventArgs args);
        Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending);
    }
}
