using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manyls {
    public interface IRestDay : IFeeding {
        string RestDay(DateTime? timeOfFeeding);
    }
}