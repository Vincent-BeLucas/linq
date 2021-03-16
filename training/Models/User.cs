using System;
using System.Collections.Generic;
using System.Text;

namespace training.Models
{
    public class User
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public string HomeCountry { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
