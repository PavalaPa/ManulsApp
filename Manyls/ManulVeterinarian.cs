using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manyls {
    public class ManulVeterinarian : Employee {
        public ManulVeterinarian(string name, DateTime bday, string zoo, DateTime startWorking) : base(name, bday, zoo, startWorking)
        {
        }

        public override List<NewPallasCat> Wards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string PathName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void WriteToFile(string resum = "Резюме отсутствует.", string path = null)
        {
            throw new NotImplementedException();
        }
    }
}