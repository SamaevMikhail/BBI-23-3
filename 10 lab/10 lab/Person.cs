using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _10_lab
{
    [ProtoContract]
    [ProtoInclude(4, typeof(Author))]
    public class Person
    {

        protected string Surname;
        protected string Name;
        protected int Age;
        [ProtoMember(1)]
        public string surname
        {
            get { return Surname; }
            set { Surname = value; }
        }
        [ProtoMember(2)]
        public string name
        {
            get {return Name; }
            set { Name = value; }
        }
        [ProtoMember(3)]
        public int age
        {
            get {return Age;}
            set { Age = value; }
        }
        public Person()
        {
 
        }
        public Person(string surname, string name, int age)
        {
            Surname = surname;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Person: {Surname} {Name}, Age: {Age}";
        }
    }
    [ProtoContract]
    public class Author : Person
    {
        private string ORCID;
        private static int orcid;
        [ProtoMember(4)]
        public string OrcId { get { return ORCID; } set { ORCID = value; } }
        public Author()
        {
        }
        public Author(string Surname, string Name, int Age) : base(Surname, Name, Age)
        {
            ORCID = CreateORCID();
        }
        private string CreateORCID()
        {
            Random rand= new Random();
            string orcidS = "";
           
            for (int i = 0; i < 4; i++)
            {
                for (int j =0; j<4; j++)
                {
                    orcid = rand.Next(0, 9);
                    orcidS += orcid.ToString();
                }
               
                orcidS += "-";
            }
            
            return orcidS.Substring(0,orcidS.Length-1) ;
        }
        public override string ToString()
        {
            return $" {Surname} {Name}, Age: {Age}, ORCID: https://orcid.org/{ORCID} ";
        }
    }
}
