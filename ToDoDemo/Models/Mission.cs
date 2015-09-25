using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDemo.Helpers;

namespace ToDoDemo.Models {
    public class Mission : Mvvm.BindableBase {
        // Title of the ToDo item
        private string _Title;
        public string Title {
            get { return _Title; }
            set { SetField(ref _Title, value); }
        }

        // The ToDo item's description
        private string _Description;
        public string Description {
            get { return _Description; }
            set { SetField(ref _Description, value); }
        }

        // The web url associated to each ToDo item
        private Uri _Link;
        public Uri Link {
            get { return _Link; }
            set { SetField(ref _Link, value); }
        }
    }
}
