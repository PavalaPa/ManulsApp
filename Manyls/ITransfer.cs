using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manyls {
    public interface ITransfer {
        string Name { get; set; }
        Eclosure Eclosure { get; set; }
        bool Transfer();
        void TransferEclosure(ITransfer someAnimal = null, Eclosure setEclosure = null, bool Exchange = true);
    }
}
