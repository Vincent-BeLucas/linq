using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using training.Models;

namespace training.Exemples
{
    public class LinqOperator
    {
        public static void GroupByOperator()
        {
           
            var sel = ListUseAnimal().AsQueryable();
            
            var osel=sel.OrderByTest("Age");
            foreach (var item in osel)
            {
                Console.WriteLine(item.Age);
            }
        }

        public static Func<User, bool> UpdateName(User user)
        {
            user.Name = String.Join(" ", "coucou : ", user.Name);
            return x => x.Age == 19;
        }

        public static void ProjectionOperator()
        {
            List<User> users = ListUseAnimal();
            //query syntaxe
            var selQuery = from user in users
                           from animals in user.Animals
                           orderby user.Age, animals.Name
                           select new { user.Age, animals.Name };

            selQuery.ToList().ForEach(x => { Console.WriteLine("QS : " + x.Name); });

            //method syntaxe :
            var selMethod = users
                 .SelectMany(x => x.Animals,
                (user, animal) =>
                new { user.Age, AnimalName = animal.Name })
                 .OrderBy(x => x.Age).ThenBy(x => x.AnimalName);

            selMethod.ToList().ForEach(x => { Console.WriteLine("MS : " + x.Age + " " + x.AnimalName); });
        }

        public static void ConversionOperator()
        {
            // vigilence sur l'unicité de la clé
            Dictionary<string, User> dictionary = ListUseAnimal().ToDictionary(p => p.Name);
            foreach (KeyValuePair<string, User> kvp in dictionary)
            {
                Console.WriteLine("Key {0}: home : {1}, Name : {2} ", kvp.Key, kvp.Value.HomeCountry, kvp.Value.Age);
            }
        }

        public static void ElementOperator()
        {
            // exeption si non trouvé 
            //User user = ListUser().First(x => x.Age == 1);

            var sel = ListUseAnimal().OrderBy(x => x.Age).Take(2);
            sel.ToList().ForEach(x => { Console.WriteLine(x.Age); });
        }






        private static List<User> ListUseAnimal()
        {
            return new List<User>()
        {
        new User { Name = "John Doe", Age = 42, HomeCountry = "USA",
            Animals=new List<Animal>(){new Animal(){Name="ChriChri", Species="cat"},new Animal(){Name="Kev", Species="fish"  } } },
        new User { Name = "Jane Doe", Age = 19, HomeCountry = "USA" ,
        Animals=new List<Animal>(){new Animal(){Name="Beber", Species="dog"},new Animal(){Name="Phil", Species="snake"  } } },
        new User { Name = "Joe Doe", Age = 19, HomeCountry = "Germany" ,
        Animals=new List<Animal>(){new Animal(){Name="toto", Species="bird"} } },
        new User { Name = "Jenna Doe", Age = 25, HomeCountry = "Germany" ,
        Animals=new List<Animal>(){new Animal(){Name="Mimi", Species="spider"},new Animal(){Name="Mitch", Species="chicken"  } } },
        new User { Name = "James Doe", Age = 8, HomeCountry = "USA" ,
        Animals=new List<Animal>()},
        };
        }

    }
}



