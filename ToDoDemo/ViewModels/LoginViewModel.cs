using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoDemo.Models;
using Parse;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace ToDoDemo.ViewModels {
    public class LoginViewModel : Mvvm.ViewModelBase {
        public LoginViewModel() {

        }
        public User CurrentUser { get; set; }
        public ObservableCollection<Mission> ToDoCollection { get; set; }

        private void SignUp() {
            ParseUser userToSignUp = new ParseUser() {
                Username = CurrentUser.Username,
                Password = CurrentUser.Password
            };
            userToSignUp.SignUpAsync();
        }
        private Mvvm.Command _Login;
        public Mvvm.Command Login {
            get { return _Login ?? (_Login = new Mvvm.Command(LoginSuccess)); }
        }
        private void LoginSuccess() {
            int yo = 4;
           // Window.Current.Content = new Views.Shell(currentPage.Frame);
        }

        public Mvvm.Command<TextBox> _KeyDown;
        public Mvvm.Command<TextBox> TextTestKeyDown {
            get { return _KeyDown ?? (_KeyDown = new Mvvm.Command<TextBox>((param) => TotallyKeyedUp(param))); }
        }

        public void TotallyKeyedUp(TextBox sender) {
            var yo = sender;
        }

    }
}
