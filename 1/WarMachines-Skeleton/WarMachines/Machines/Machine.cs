using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Machine : IMachine
    {
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private string name;
        private IPilot pilot;

        private IList<string> targets;


        public Machine(double attackPoints, double defensePoints, double healthPoints, string name)
        {
            this.targets = new List<string>();

            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Name = name;
            
        }


        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack ponts must be positive number.");
                }

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense ponts must be positive number.");
                }

                this.defensePoints = value;
            }

        }

    

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense ponts must be positive number.");
                }

                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }

            
        }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentException("Target cannot be null or empty");
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            //string type = this.GetType().ToString().Split('.')[2];

            //var count = this.targets.Count;
            //var separated = string.Join(", ", this.targets);

            var targetAsString = this.targets.Count > 0 ? string.Join(", ", this.targets) : "None";

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", targetAsString));


            return result.ToString().Trim();

        }
    }
}
