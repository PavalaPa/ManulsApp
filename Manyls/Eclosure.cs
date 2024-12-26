using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Manyls {
    public class Eclosure {
        static int nextId;
        int _id;
        public string Zoo { get; set; }
        public int ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public Eclosure(Zoo zoo) 
        {
            ID = Interlocked.Increment(ref nextId);
            Zoo = zoo.Name;
        }
    }
}
