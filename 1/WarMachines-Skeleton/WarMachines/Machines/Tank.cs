using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank : Machine, ITank
    {

        private bool defenseMode=true;

        public Tank(string name,double attackPoints, double defensePoints) : base(attackPoints, defensePoints, 100, name)
        {

            if (this.defenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }

        }

        public void ToggleDefenseMode()
        {
            if (this.defenseMode)
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }

            this.defenseMode = !this.defenseMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF") );

            return result.ToString().Trim();

            
        }
    }
}
