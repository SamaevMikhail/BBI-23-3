using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _10_lab
{
    interface IPublishing
    {
        static void GetForReview(Publication publication) { }
        static void Publish(Publication publication, string publisher) { }
    }
    public partial class PublishHouse : IPublishing
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Publication[] publications { get; init; }

        protected string HouseName; 
        public string houseName
        {
            get { return HouseName; }
            set { HouseName = value; }
        }


        private Publication[] publishedPublications;
        public Publication[] PublishedPublications { get { return publishedPublications; } set { publishedPublications = value; } }

        static int k = 0;


        //public PublishHouse()
        //{
        //    publishedPublications = new Publication[5];
        //}
        public PublishHouse() { }

        public PublishHouse(Publication[] publications, string HouseName)
        {
            this.publications = publications;
            this.HouseName = HouseName ;
            publishedPublications = new Publication[5];
        }

      

        public void GetForReview(Publication publication, string housen)
        {
            if (publication.Publisher == null)
            {
               
                publication.Publisher = housen;
            }
            else
            {
                Console.WriteLine("Рассматривается другим издательством");
            }
        }
      
        public void Publish(Publication publication)
        {
            if (k < 5)
            {

                publication.PublicationDate = DateTime.Now;
                publishedPublications[k]= publication;
                k++;
            }
            else
            {
                k = 0;
                Console.WriteLine("Достигнуто максимальное количество опубликованных статей.");
            }
        }
    }

}

