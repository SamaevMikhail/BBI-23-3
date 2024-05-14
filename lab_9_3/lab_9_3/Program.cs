using System.IO;
using System.Xml.Serialization;
using Serializations;
using ProtoBuf;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
[Serializable]
[ProtoContract]
[XmlInclude(typeof(SkierMan))]
[XmlInclude(typeof(SkierWoman))]
[ProtoInclude(100, typeof(SkierMan))]
[ProtoInclude(101, typeof(SkierWoman))]

public class Athlete
{
    protected string _name;
    protected int _score;
    [ProtoMember(1)]
    public string Name
    {
        get{ return _name; }
        set { _name = value; }
    }
    [ProtoMember(2)]
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public Athlete() { }
    public Athlete(string name, int score)
    {
        _name = name;
        _score = score;
    }
    public virtual void Print()
    {
        Console.WriteLine("{0,-7} | {1,-3} | ", _name, _score);
    }
    public static void MergeSort(Athlete[] a)
    {
        if (a.Length <= 1) return;
        int m = a.Length / 2;
        Athlete[] b = new Athlete[m];
        Athlete[] c = new Athlete[a.Length - m];
        for (int i = 0; i < b.Length; i++)
        {
            b[i] = a[i];
        }
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = a[m + i];
        }
        int l = 0;
        int j = 0;
        int k = 0;
        MergeSort(b);
        MergeSort(c);
        while (l < c.Length && j < b.Length)
        {
            if (c[l].Score < b[j].Score)
            {
                a[k] = c[l];
                k++;
                l++;
            }
            else
            {
                a[k] = b[j];
                k++;
                j++;
            }
        }
        while (l < c.Length)
        {
            a[k] = c[l];
            k++;
            l++;
        }
        while (j < b.Length)
        {
            a[k] = b[j];
            k++;
            j++;
        }
    }
}
[Serializable]
[ProtoContract]
public class SkierMan : Athlete
{
    public SkierMan() { }
    public SkierMan(string name, int score) : base(name, score)
    {

    }
    public override void Print()
    {
        Console.WriteLine("Лыжники {0,-7} | {1,-3} |  ", _name, _score);
    }
}
[Serializable]
[ProtoContract]
public class SkierWoman : Athlete
{
    public SkierWoman() { } 
    public SkierWoman(string name, int score) : base(name, score) { }
    public override void Print()
    {
        Console.WriteLine("Лыжницы {0,-7} | {1,-3}  ", _name, _score);
    }
}
public class Program
{
    static void ArrayPrint(Athlete[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].Print();
        }
        Console.WriteLine();
    }
    public static void Main(string[] args)
    {
        SkierWoman[] womanGr1 = new SkierWoman[5] {
            new SkierWoman("Лена",30),
            new SkierWoman("Анна",25),
            new SkierWoman("Дина",40),
            new SkierWoman("Ольга",30),
            new SkierWoman("Данна",27)
        };
        SkierWoman[] womanGr2 = new SkierWoman[5] {
            new SkierWoman("Елизавета",28),
            new SkierWoman("Варвара",29),
            new SkierWoman("Анастасия",44),
            new SkierWoman("София",34),
            new SkierWoman("Ксения",32)
        };
        SkierMan[] manGr1 = new SkierMan[5] {
            new SkierMan("Андрей",25),
            new SkierMan("Артем",28),
            new SkierMan("Илья",40),
            new SkierMan("Даниил",32),
            new SkierMan("Михаил",30)
        };
        SkierMan[] manGr2 = new SkierMan[5] {
            new SkierMan("Виталий",30),
            new SkierMan("Амир",32),
            new SkierMan("Армен",38),
            new SkierMan("Григорий",40),
            new SkierMan("Глеб",30)
        };


        SkierWoman[] women = new SkierWoman[10];
        for (int i = 0; i < 5; i++)
        {
            women[i] = womanGr1[i];
            women[i + 5] = womanGr2[i];
        }
        SkierMan[] men = new SkierMan[10];

        for (int i = 0; i < 5; i++)
        {
            men[i] = manGr1[i];
            men[i + 5] = manGr2[i];
        }
        Athlete.MergeSort(men);
        Athlete.MergeSort(women);
        Athlete[] athletes = new Athlete[20];
        for (int i = 0; i < 10; i++)
        {
            athletes[i] = men[i];
            athletes[i + 10] = women[i];

        }

        Athlete.MergeSort(athletes);
        string[] Seral =
        {
            "Json Ser",
            "Xml Ser",
            "Bin Ser"
        };
        string[] filesName =
        {
            "man.json",
            "man.xml",
            "man.bin",
            "woman.json",
            "woman.xml",
            "woman.bin",
            "athlets.json",
            "athlets.xml",
            "athlets.bin"

        };
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string floderName = "lab_9_3";
        path = Path.Combine(path, floderName);
        if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
        MySerializer[] Ser =
        {
            new MyJsonSerilazer(),
            new MyXmlSerilazer (),
            new MyBinSerilazer ()
        };
        for (int i = 0; i < Ser.Length; i++)
        {
            Ser[i].Write(men, Path.Combine(path, filesName[i]));
            Ser[i].Write(women, Path.Combine(path, filesName[i+3]));
            Ser[i].Write<Athlete[]>(athletes, Path.Combine(path, filesName[i+6]));
        }
        for (int i=0; i < Ser.Length; i++)
        {
            Console.WriteLine(Seral[i]);
            var mn = Ser[i].Read<SkierMan[]>(Path.Combine(path, filesName[i]));
            var wmn = Ser[i].Read<SkierWoman[]>(Path.Combine(path, filesName[i+3]));
            var ath = Ser[i].Read<Athlete[]>(Path.Combine(path, filesName[i+6]));
            foreach (var f in mn) 
            {
                f.Print();
            }
            Console.WriteLine();
            foreach (var f in wmn)
            {
                f.Print();
            }
            Console.WriteLine() ;
            foreach (var f in ath)
            {
                Console.WriteLine($"{f}");
                f.Print();
            }
        }
    }





}