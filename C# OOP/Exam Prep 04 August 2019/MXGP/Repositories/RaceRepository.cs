using MXGP.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        public List<IRace> Models { get; }
        public RaceRepository()
        {
            Models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.ToList();
        }

        public IRace GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
             => Models.Remove(model);
    }
}
