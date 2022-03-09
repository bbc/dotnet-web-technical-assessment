using ElectionsApiApplication.Models;
using System.Collections.Concurrent;

namespace ElectionsApiApplication.Services
{
    public interface IResultService
    {
        ConstituencyResult? GetResult(int id);
        void NewResult(ConstituencyResult result);
        ConcurrentDictionary<int, ConstituencyResult> GetAll();
        void Reset();
    }
}
