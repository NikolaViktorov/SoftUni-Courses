using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class RiderRepository : IRepository<IRider>
    {
        public List<IRider> Models { get; private set; }
        public RiderRepository()
        {
            Models = new List<IRider>();
        }

        public void Add(IRider model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return Models.ToList();
        }

        public IRider GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRider model)
             => Models.Remove(model);
    }
}
