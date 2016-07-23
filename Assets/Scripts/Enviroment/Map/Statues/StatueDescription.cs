using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    public class StatueDescription : Attribute
    {
        public string Description { get; private set; }

        public StatueDescription(string description)
        {
            Description = description;
        }
    }
}
