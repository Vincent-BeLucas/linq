using System;
using System.Collections.Generic;
using System.Text;

namespace training.Models
{
    public class Personn
    {
        public string Name { get; set; }
        public string NickName { get; set; }

        public override string ToString()
        {
            return Name + " " + NickName;
        }

    }
}
