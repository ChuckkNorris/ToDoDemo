using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDemo.Models;

namespace ToDoDemo.ViewModels {
    public class LoginViewModel {
        public string Username { get; set; }
        public string Password { get; set; }
        public ObservableCollection<ToDo> ToDoCollection { get; set; }


    }
}
