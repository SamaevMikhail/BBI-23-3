using ProtoBuf;
using System;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
namespace _10_lab
{
    public interface ICitation
    {
        string GenerateCitation();
    }
    [XmlInclude(typeof(ResearchArticle))]
    [XmlInclude(typeof(ReviewArticle))]
    [XmlInclude(typeof(CaseStudy))]

    [ProtoContract]
    [ProtoInclude(6, typeof(ResearchArticle))]
    [ProtoInclude(7, typeof(ReviewArticle))]
    [ProtoInclude(8, typeof(CaseStudy))]
    public class Publication 
    {
        [JsonIgnore]
        protected static int citations = 0;
        protected string Title;
        [ProtoMember(1)]
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }
        protected Author[] Authors;
        [ProtoMember(2)]
        public Author[] authors
        {
            get { return  Authors; } 
            set { Authors = value; }
        }
        protected string[] KeyWords { get; set; }
        [ProtoMember(3)]
        public string[] keyWords
        {
            get { return KeyWords; }
            set { KeyWords = value; }
        }

     
        protected string publisher;
        [ProtoMember(4)]
        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher=value;
            }
        }

        protected DateTime publicationDate;

        /* public string Publisher
         {
             get { return publisher; }
             set { publisher = value; }
         }*/
        [ProtoMember(5)]
        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }
        public Publication(){ }
        
        public Publication(string title, Author[] authors, string[] keyWords)
        {
            Title = title;
            Authors = authors;
            KeyWords = keyWords;
        }

        public override string ToString()
        {
            string authors = " ";
            for (int i = 0; i<Authors.Length; i++)
            {
                authors+= Authors[i].ToString() + "\n";
            }

            string keyWords = string.Join(", ", KeyWords);

            string newPub = "Title:" + Title + "\nAuthors:" + authors + "\nKeywords:" + keyWords + "\nPublisher:" + publisher + "\nPublication Date:" + publicationDate.ToShortDateString();
            return newPub;
        }
        
        public int CompareTo(Publication other)
        {
            return string.Compare(Title, other.Title);
        }
        
        public virtual string GenerateCitation() { return null; }

    }

    [ProtoContract]
    public class ResearchArticle : Publication
    {

        public ResearchArticle() { }
        public ResearchArticle(string Title, Author[] Authors, string[] KeyWords) : base(Title, Authors, KeyWords) { }

        public override string GenerateCitation()
        {
            if (Publisher != null)
            {
                citations++;
                string authors = string.Join(",", Authors.ToString());
                return $"ResearchArticle:\t\" {Title}\"\n {authors}\n{Publisher} ";
            }
            else { return "The article is not published. Publisher = null"; }

        }

    }

    [ProtoContract]
    public class ReviewArticle : Publication
    {

        public ReviewArticle() { }
     
        public ReviewArticle(string Title, Author[] Authors, string[] KeyWords) : base(Title, Authors, KeyWords) { }
        public override string GenerateCitation()
        {
            if (Publisher != null)
            {
                citations++;
                string authors = string.Join(",", Authors.ToString());
                return $"Review Article:\t\" {Title}\"\n {authors}\n{Publisher} ";
            }
            else { return "The article is not published. Publisher = null"; }
        }

    }

    [ProtoContract]
    public class CaseStudy : Publication
    {


        public CaseStudy() { }
       
        public CaseStudy(string Title, Author[] Authors, string[] KeyWords) : base(Title, Authors, KeyWords) { }
        public override string GenerateCitation()
        {
            if (Publisher != null)
            {
                citations++;
                string authors = string.Join(",", Authors.ToString());
                return $"CaseStudy:\t\" {Title}\"\n {authors}\n{Publisher} ";
            }
            else { return "The article is not published. Publisher = null"; }
        }
    }

}