using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class PublishHouse
    {
        public Publication[] Filter(Author[] authors)
        {
            int c = 0;
            foreach (var pub in PublishedPublications)
            {
                for (int i = 0; i < pub.authors.Length; i++)
                {
                    if (pub.authors[i].OrcId == authors[i].OrcId)
                    {
                        c++;
                        break;
                    }
                }
            }
            Publication[] ret = new Publication[c];
            int k = 0;
            foreach (var pub in PublishedPublications)
            {
                for (int i = 0; i < pub.authors.Length; i++)
                {
                    if (pub.authors[i].OrcId == authors[i].OrcId)
                    {
                        ret[k] = pub;
                        k++;
                        break;
                    }
                }
            }
            return ret;

        }

        public Publication[] Filter(string[] keywords)
        {
            int c = 0;
            foreach (var pub in PublishedPublications)
            {
                int count = 0;
                for (int i = 0; i < pub.keyWords.Length; i++)
                {
                    if (pub.keyWords[i] == keywords[i])
                    {
                        count++;
                    }
                    if (count == 2)
                    {
                        c++;
                        break;
                    }
                }
            }
            Publication[] ret = new Publication[c];
            int k = 0;
            foreach (var pub in PublishedPublications)
            {
                int count = 0;
                for (int i = 0; i < pub.keyWords.Length; i++)
                {
                    if (pub.keyWords[i] == keywords[i])
                    {
                        count++;
                    }
                    if (count == 2)
                    {
                        ret[k] = pub;
                        k++;
                        break;
                    }
                }
            }
            return ret;

        }
    }
}