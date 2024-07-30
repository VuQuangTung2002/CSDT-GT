using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace su_dung_set
{
    public class use_set
    {
        public static void Main(string[] args)
        {
            List<int> ds = new List<int>
            {
                1,2,2,1,2,3,3,5,5
            };
            //HashSet<int> dsne = new HashSet<int>(ds);
            //foreach(var x in  dsne)
            //{
            //    Console.WriteLine($"{x}");
            //}
            List<int> ds2 = ds.Distinct().ToList();
            foreach(var x in ds2)
            {
                Console.WriteLine(x);
            }
        }
    }
}
