using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoDemo.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace ToDoDemo.Mvvm
{
    public abstract class ViewModelBase : BindableBase, INavigatable
    {
        public ViewModelBase()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                this.Dispatch = (App.Current as Common.BootStrapper).Dispatch;
                this.NavigationService = (App.Current as Common.BootStrapper).NavigationService;
            }
        }
        public Action<Action> Dispatch { get; private set; }
        public NavigationService NavigationService { get; private set; }
        public virtual void OnNavigatedTo(string parameter, NavigationMode mode, IDictionary<string, object> state) {
            /* nothing by default */
        }
        public virtual Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending) { return Task.FromResult<object>(null); }
        public virtual void OnNavigatingFrom(Services.NavigationService.NavigatingEventArgs args) { /* nothing by default */ }

        //public void OnNavigatedTo(string parameter, NavigationMode mode, Dictionary<string, object> state)
        //{
        //    throw new NotImplementedException();
        //}

        public void OnNavigatedFrom(Dictionary<string, object> state, bool suspending)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}