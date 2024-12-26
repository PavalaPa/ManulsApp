using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Manyls {
    public class MedicalHistory {
        // Поля и свойства класса
        public string veterinaryСlinic;
        public List<string> AttendingPhysicians;
        public Dictionary<DateTime, string> OngoingDiseases;

        // Конструкторы
        
        public MedicalHistory() { }

        public MedicalHistory(string clinic, List<string> attendingPhys) 
        {
            this.veterinaryСlinic = clinic;
            this.AttendingPhysicians = attendingPhys;
        }
        // Методы класса

    }
}