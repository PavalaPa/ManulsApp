using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manyls {
    public class MedHistory {
        public MedHistory() { }
        public MedHistory(string name) { this.veterinaryСlinic = name; }
        public MedHistory(string veterinaryСlinic, Dictionary<DateTime, string> ongoingDiseases) : this(veterinaryСlinic)
        {
            OngoingDiseases = ongoingDiseases;
        }

        // Поля и свойства класса
        public string veterinaryСlinic;
        public Dictionary<DateTime, string> OngoingDiseases;
    }
}
