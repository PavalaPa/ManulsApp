using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manyls {
    public class Zoo {
        //Constructor
        public Zoo() { }
        public Zoo(string name) 
        { 
            Name = name; 
        }
        //Properties
        private int m_id = -1;
        public int ID { get { return m_id; } set { m_id = value; } }
        public string Name;
        public static int HowManyManulas = 0;
    }
}