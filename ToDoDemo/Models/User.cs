using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDemo.Models {
    public class User : Mvvm.BindableBase {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
