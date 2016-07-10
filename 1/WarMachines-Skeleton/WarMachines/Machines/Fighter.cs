using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter
    {
        private bool stealthMode;


        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(attackPoints,defensePoints,200,name)
        {

            this.StealthMode = stealthMode;           

        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            private set
            {
                this.stealthMode = value;
            }
        }
        

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }


        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return result.ToString();
        }

    }
}
