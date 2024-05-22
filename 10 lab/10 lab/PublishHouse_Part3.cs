using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lab
{
    public partial class PublishHouse
    {
        public override string ToString()
        {
            string p = "";
            for (int i = 0; i < publishedPublications.Length; i++)
            {
                p+= publishedPublications[i].ToString()+"\n";
            }
            return $"{HouseName}\n {p}";
        }
    }
}
