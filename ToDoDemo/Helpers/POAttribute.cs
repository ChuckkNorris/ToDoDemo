using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDemo.Helpers {
    public class POAttribute : Attribute {
        public POAttribute(string columnName) {
            ColumnName = columnName;
        }
        public string ColumnName { get; set; }
    }
}
