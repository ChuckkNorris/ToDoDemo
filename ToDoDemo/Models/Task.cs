using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDemo.Helpers;

namespace ToDoDemo.Models {
    public class Task {
        [POAttribute(columnName: "title")]
        public string Title { get; set; }

        [POAttribute(columnName: "content")]
        public string Content { get; set; }

        [POAttribute(columnName: "link")]
        public Uri Link { get; set; }
    }
}
