using System;
namespace Manyls {
    public interface IRestDay : IFeeding {
        string RestDay(DateTime? timeOfFeeding);
    }
}