using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manyls {
    public class Feeding : IFeeding, ICurrentActions {
        public DateTime ActionTime { get ; set ; }

        public string FeedingManul(DateTime timeOfFeeding)
        {
            return $"{timeOfFeeding} происходила кормежка манула ";
        }
    }
    public class Cleening : ICleaningEnclosure, ICurrentActions {
        public DateTime ActionTime { get; set; }
        public string Name { get; set; }
        public string CleaningEnclosure(DateTime timeOfCleaning)
        {
            return $"{timeOfCleaning} происходила уборка вольера манула ";
        }

        void ICleaningEnclosure.CleaningEnclosure(DateTime timeOfCleaning)
        {
            throw new NotImplementedException();
        }
    }
    public class Rest : IRestDay, ICurrentActions {
        public DateTime ActionTime { get; set; }

        public string FeedingManul(DateTime timeOfFeeding)
        {
            return $"{timeOfFeeding} несколько раз поили манула ";
        }

        public string RestDay(DateTime? timeOfFeeding)
        {
            return $"{timeOfFeeding} происходил отдых от еды у манула ";
        }
    }
}
