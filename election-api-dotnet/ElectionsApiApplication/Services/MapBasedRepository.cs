using ElectionsApiApplication.Models;
using System.Collections.Concurrent;

namespace ElectionsApiApplication.Services
{
    public class MapBasedRepository : IResultService
    {
        private readonly ConcurrentDictionary<int, ConstituencyResult> _results;

        public MapBasedRepository()
        {
            _results = new ConcurrentDictionary<int, ConstituencyResult> ();
        }

        public ConstituencyResult? GetResult(int id)
        {
            return _results.ContainsKey(id) ? _results[id] : null;
        }

        public void NewResult(ConstituencyResult result)
        {
            _results[result.Id] = result;
        }

        public ConcurrentDictionary<int, ConstituencyResult> GetAll()
        {
            return _results;
        }

        public void Reset()
        {
            _results.Clear();
        }
    }
}
