using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Manyls {
    public class MedicalHistory : NewPallasCat {
        // Поля и свойства класса
        public string veterinaryСlinic;
        public List<string> AttendingPhysicians;
        public Dictionary<DateTime, string> OngoingDiseases;

        // Конструкторы
        public MedicalHistory() : base() { }

        public MedicalHistory(string name, DateTime birthDay, bool isFem, string clinic, List<string> attendingPhys) : base(name, birthDay, isFem) 
        {
            this.veterinaryСlinic = clinic;
            this.AttendingPhysicians = attendingPhys;
        }
        public MedicalHistory(string name, DateTime birthDay, string zoo, string pathFoto, bool isFem, string clinic, List<string> attendingPhys) : base(name, birthDay, zoo, pathFoto, isFem) 
        {
            this.veterinaryСlinic = clinic;
            this.AttendingPhysicians = attendingPhys;
        }
        // Методы класса

    }
}