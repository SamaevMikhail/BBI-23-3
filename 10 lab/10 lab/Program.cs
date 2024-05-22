using _10_lab;


public class Program
{
    public static void Main(string[] args)
    {
        Author[] authors1 = new Author[2]
        {
        new Author("Einstien", "Albert", 51),
        new Author("Volta", "Alessandro", 30)};
        Author[] authors2 = new Author[2]
{
        new Author("Faraday", "Michael", 22),
        new Author("Tesla", "Nikola", 43),
};
        Author[] authors3 = new Author[2]
{
        new Author("Hertz", "Heinrich", 18),
        new Author("Newton", "Isaac", 34)
};
      
        string[] KeyWords1 = new string[] { "science", "study" };
        string[] KeyWords2 = new string[] { "review", "article" };
        string[] KeyWords3 = new string[] { "research", "article" };
        Publication[] publicationsALL =
        {
         new CaseStudy("Case Study 1", authors1, KeyWords1),
         new ReviewArticle("Review Article 1", authors2, KeyWords2),
         new ResearchArticle("Research Article 1", authors3, KeyWords3),

         new CaseStudy("Case Study 2", authors1, KeyWords1),
         new ReviewArticle("Review Article 2", authors3, KeyWords2),
         new ResearchArticle("Research Article 2", authors2, KeyWords3),

         new CaseStudy("Case Study 3", authors2, KeyWords2),
         new ReviewArticle("Review Article 3", authors1, KeyWords1),
         new ResearchArticle("Research Article 3", authors3, KeyWords3),

         new CaseStudy("Case Study 4", authors2, KeyWords1),
         new ReviewArticle("Review Article 4", authors3, KeyWords2),
         new ResearchArticle("Research Article 4", authors1, KeyWords3),

         new CaseStudy("Case Study 5", authors3, KeyWords1),
         new ReviewArticle("Review Article 5", authors2, KeyWords2),
         new ResearchArticle("Research Article 5", authors3, KeyWords3),

         new CaseStudy("Case Study 6", authors3, KeyWords1),
         new ReviewArticle("Review Article 6", authors1, KeyWords2),
         new ResearchArticle("Research Article 6", authors2, KeyWords3),

         new CaseStudy("Case Study 7", authors1, KeyWords1),
         new ReviewArticle("Review Article 7", authors2, KeyWords2)
        };
        Publication[] publications1 = new Publication[10]
        {
         //возможно нужно разнообразить ключевые слова, для пункта 2.c (процитировать статьи...)
            publicationsALL[0],
            publicationsALL[1],
            publicationsALL[2],
            publicationsALL[3],
            publicationsALL[4],
            publicationsALL[5],
            publicationsALL[6],
            publicationsALL[7],
            publicationsALL[8],
            publicationsALL[9],

        };
        Publication[] publications2 = new Publication[10]
        {
         //возможно нужно разнообразить ключевые слова, для пункта 2.c (процитировать статьи...)
            publicationsALL[5],
            publicationsALL[6],
            publicationsALL[7],
            publicationsALL[8],
            publicationsALL[9],
            publicationsALL[10],
            publicationsALL[11],
            publicationsALL[12],
            publicationsALL[13],
            publicationsALL[14],

        };
        Publication[] publications3 = new Publication[10]
        {
         //возможно нужно разнообразить ключевые слова, для пункта 2.c (процитировать статьи...)
            publicationsALL[10],
            publicationsALL[11],
            publicationsALL[12],
            publicationsALL[13],
            publicationsALL[14],
            publicationsALL[15],
            publicationsALL[16],
            publicationsALL[17],
            publicationsALL[18],
            publicationsALL[19]
        };

        // Создаём массив с издательствами, отправляем публицкации
        PublishHouse[] publishHouses =
        {
            new PublishHouse(publications1, "First"),
            new PublishHouse(publications2, "Second"),
            new PublishHouse(publications3, "Third")
        };


        var json = new MyJsonSerializer();
        var xml = new MyXmlSerializer();
        var bin = new MyBinarySerializer();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //путь сохранения файлов
        string folderName = "Solution";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //raw data в binary
        string Name5 = "raw_data.bin";
        Name5 = Path.Combine(path, Name5);
        try
        {
            bin.WritePublishHouse(publicationsALL, Name5);

        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during BIN serialization: " + ex.Message);
        }

        //raw data в json
        string Name1 = "raw_data.json";
        Name1 = Path.Combine(path, Name1);
        try
        {
            json.WritePublishHouse(publicationsALL, Name1);

        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during Json serialization: " + ex.Message);
        }

        //raw data в xml
        string Name2 = "raw_data.xml";
        Name2 = Path.Combine(path, Name2);
        try
        {
            if (!File.Exists(Name2))
            {
                xml.WritePublishHouse(publicationsALL, Name2);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during XML serialization: " + ex.Message);
        }
        //int k1 = 0;
        //for (int i = 0; i < 5; i++)
        //{
        //    publishHouses[0].GetForReview(publishHouses[0].publications[i], publishHouses[0].houseName);
        //    if (publishHouses[0].publications[i].Publisher == publishHouses[0].houseName) k1++;
        //    if (k1 == 5) break;
        //}
        //k1 = 0;
        //for (int i = 0; i < 10; i++)
        //{
        //    publishHouses[1].GetForReview(publishHouses[1].publications[i], publishHouses[1].houseName);
        //    if (publishHouses[1].publications[i].Publisher == publishHouses[1].houseName) k1++;
        //    if (k1 == 5) break;
        //}
        //k1 = 0;
        //for (int i = 0; i < 10; i++)
        //{
        //    publishHouses[2].GetForReview(publishHouses[2].publications[i], publishHouses[2].houseName);
        //    if (publishHouses[2].publications[i].Publisher == publishHouses[2].houseName) k1++;
        //    if (k1 == 5) break;
        //}
        for (int i = 0; i < 5; i++)
        {
            publishHouses[0].GetForReview(publishHouses[0].publications[i], publishHouses[0].houseName);
            //publishHouses[1].GetForReview(publishHouses[1].publications[i], publishHouses[1].HouseName);
            //publishHouses[2].GetForReview(publishHouses[2].publications[i], publishHouses[2].HouseName);
            //    //   publishHouses[1].GetForReview(ref publications2[i]);
            //    //   publishHouses[2].GetForReview(ref publications3[i]);
        }
        for (int i = 0; i < publishHouses[1].publications.Length; i++)
        {
            publishHouses[1].GetForReview(publishHouses[1].publications[i], publishHouses[1].houseName);
        }
        for (int i = 0; i < publishHouses[2].publications.Length; i++)
        {
            publishHouses[2].GetForReview(publishHouses[2].publications[i], publishHouses[2].houseName);
        }
        // Публикация статей
        for (int i = 0; i < 5; i++)
        {
            publishHouses[0].Publish(publishHouses[0].publications[i]);
        }
        for (int i = 0; i < publishHouses[1].publications.Length; i++)
        {
            publishHouses[1].Publish(publishHouses[1].publications[i]);
        }
        for (int i = 0; i < publishHouses[2].publications.Length; i++)
        {
            publishHouses[2].Publish(publishHouses[2].publications[i]);
        }
        string Name3 = "data.json";
        Name3 = Path.Combine(path, Name3);
        try
        {
            if (!File.Exists(Name3))
            {
                json.WritePublishHouse(publishHouses, Name3);
            }
          

        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during TEST Json serialization: " + ex.Message);
        }

        //создаю массив с сорт. по автору и ключевым словам
        List<Publication> filteredPublications = new List<Publication>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < publishHouses[i].Filter(authors1).Length; j++) filteredPublications.Add(publishHouses[i].Filter(authors1)[j]);
            for (int j = 0; j < publishHouses[i].Filter(KeyWords1).Length; j++) filteredPublications.Add(publishHouses[i].Filter(KeyWords1)[j]);
        }

        Publication[] FilteredPublications = filteredPublications.ToArray();
        List<Publication> filteredPublications2 = new List<Publication>();
        for (int i = 0; i < FilteredPublications.Length - 1; i++)
        {
            for (int j = i + 1; j < FilteredPublications.Length; j++)
            {
                if (FilteredPublications[i] == FilteredPublications[j])
                {
                    filteredPublications2.Add(FilteredPublications[i]);
                    break;
                }
            }
        }

        //сереализация сортированного в xml
        string Name4 = "data.xml";
        Name4 = Path.Combine(path, Name4);
        try
        {
            if (!File.Exists(Name4))
            {
                xml.WritePublishHouse(filteredPublications2.ToArray(), Name4);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during XML serialization: " + ex.Message);
        }
        //десереализация данный raw_data.bin )
        Console.WriteLine("\n\nДанные из raw_data.bin\n");
        try
        {
            if (File.Exists(Name5))
            {
                var t1 = bin.ReadPublishHouse<Publication[]>(Name5);
                for (int i = 0; i < t1.Length; i++)
                {
                    Console.WriteLine(t1[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during BIN serialization: " + ex.Message);
        }

        //десереализация данный raw_data.json (ОШИБКА)
        Console.WriteLine("_________________________________________________________________\n\nДанные из raw_data.json\n");
        try
        {
            if (File.Exists(Name1))
            {
                var t1 = json.ReadPublishHouse<Publication[]>(Name1);
                for (int i = 0; i < t1.Length; i++)
                {
                    Console.WriteLine(t1[i]);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during JSon serialization: " + ex.Message);
        }




        //десереализация данный raw_data.xml
        Console.WriteLine("______________________________________________________________\n\nДанные из raw_data.xml\n");
        try
        {
            if (File.Exists(Name2))
            {
                var t1 = xml.ReadPublishHouse<Publication[]>(Name2);
                for (int i = 0; i < t1.Length; i++)
                {
                    Console.WriteLine(t1[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during XML serialization: " + ex.Message);
        }

        ////десереализация данный data.json (ОШИБКА) (опубликованные статьи в издательствах)
        Console.WriteLine("_________________________________________________________________\n\nДанные из data.json\n");
        try
        {
            if (File.Exists(Name3))
            {
                var t1 = json.ReadPublishHouse<PublishHouse[]>(Name3);
                for (int i = 0; i < t1.Length; i++)
                {
                    Console.WriteLine(t1[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during JSON serialization: " + ex.Message);
        }

        ////десереализация данный data_xml (по автору и 2 словам)
        Console.WriteLine("_________________________________________________________________\n\nДанные из data.xml\n");
        try
        {
            if (File.Exists(Name4))
            {
                var t1 = xml.ReadPublishHouse<Publication[]>(Name4);
                for (int i = 0; i < t1.Length; i++)
                {
                    Console.WriteLine(t1[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occurred during XML serialization: " + ex.Message);
        }


    }
}
