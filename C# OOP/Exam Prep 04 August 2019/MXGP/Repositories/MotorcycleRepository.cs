using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        public List<IMotorcycle> Models { get; private set; }
        public MotorcycleRepository()
        {
            Models = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            Models.Add(model);
        }
          
        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return Models.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IMotorcycle model)
             => Models.Remove(model);
            
    }
}
