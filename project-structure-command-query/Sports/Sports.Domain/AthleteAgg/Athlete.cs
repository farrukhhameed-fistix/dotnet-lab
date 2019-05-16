using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Domain
{
    public class Athlete
    {
        public Athlete(Guid id,  string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
