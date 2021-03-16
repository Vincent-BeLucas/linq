using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using training.Models;

namespace training.Exemples
{
    public static class Extensions
    {
        public static List<User> ChangeAge(this List<User> collection, Predicate<string> pred)
        {
            Func<int, int> dogage = x => x / 8;
            pred
            var sel = collection.Where(func);
            sel.Select(x => dogage(x.Age));
            return sel.ToList();

        }
    }
}
