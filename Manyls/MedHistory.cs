using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manyls {
    public class MedHistory {
        public MedHistory() { }
        public MedHistory(string name) { this.veterinaryСlinic = name; }
        // Поля и свойства класса
        public string veterinaryСlinic;
        public List<string> AttendingPhysicians;
        public Dictionary<DateTime, string> OngoingDiseases;
    }
}
