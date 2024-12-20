using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manyls {
    public class EmployeeEvents:EventArgs {
        public string Message { get; }
        public string Name { get; }

        public EmployeeEvents(string message, string name)
        {
            Message = message;
            Name = name;
        }
    }
}
