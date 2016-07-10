using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {

            this.Name = name;
            this.machines = new List<IMachine>();

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new ArgumentNullException("Machine cannot be null");
            }

            this.machines.Add(machine);

        }

        public string Report()
        {

            var sortedMachines = this.machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);

            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} {2}",
              this.Name, this.machines.Count == 0 ? "no" : this.machines.Count.ToString(),
              this.machines.Count == 1 ? "machine" : "machines"));

            foreach (var item in sortedMachines)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
