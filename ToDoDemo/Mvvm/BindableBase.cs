using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoDemo.Mvvm
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// This is the event which notifies the UI that a property's value has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// When a property's value is changed, this updates any UI Elements which are bound to the property
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged([CallerMemberName]string propertyName = null) {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;
            (App.Current as Common.BootStrapper).Dispatch(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

        /// <summary>
        /// Set field automatically updates the underlying variable by reference and triggers the Property
        /// changed event with one method call
        /// </summary>
        /// <typeparam name="T">The property type</typeparam>
        /// <param name="storage">The underlying private variable which is the source of a property value</param>
        /// <param name="value">The value to set the private variable to</param>
        /// <param name="propertyName">The string name of the property. This is not required since 
        /// CallerMemberName passes the property name which is obtained during compilation
        /// </param>
        public void SetField<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if (!object.Equals(storage, value))
            {
                storage = value;
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
