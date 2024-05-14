using System.IO;
using System.Xml.Serialization;
using Serializations;
using ProtoBuf;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
[Serializable]
[ProtoContract]
[ProtoInclude(6,typeof(Athlete))]
[XmlInclude(typeof(Athlete))]
public class Human
{
    protected string _name;
    protected int _wincount;
    protected double _drawcount;
    protected int _loosecount;
    protected double _finalscore;
    [ProtoMember(1)]
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    [ProtoMember(2)]
    public int Wincount
    {
        get { return _wincount; }
        set { _wincount = value; }
    }
    [ProtoMember(3)]
    public double Drawcount
    {
        get { return _drawcount; }
        set { _drawcount = value; }
    }
    [ProtoMember(4)]
    public int Loosecount
    {
        get { return _loosecount; }
        set { _loosecount = value; }
    }
    [ProtoMember(5)]
    public double Finalscore
    {
        get { return _finalscore; }
        set { _finalscore = value; }
    }
    public Human() { }
    public Human(string name, int wins, double draws, int looses)
    {
        _name = name;
        _wincount = wins;
        _drawcount = draws;
        _loosecount = looses;
        _finalscore = wins * 1 + draws / 2;
    }
    public virtual void Print()
    {
        // name не больше 5 символов иначе вывод ломаесться
        Console.WriteLine("{0,-5} | {1,-3} | {2,-3} | {3,-7} | {4,-3}", _name, _wincount, _drawcount, _loosecount, _finalscore);
    }
}
[ProtoContract]
public class Athlete : Human
{
    static int _id = 0;
    [ProtoMember(6)]
    public int ID { get; set; }
    public Athlete() { }
    public Athlete(string name, int wins, double draws, int looses) : base(name, wins, draws, looses)
    {
        _id++;
        ID = _id;
    }
    public override void Print()
    {
        Console.WriteLine("{5,-3} | {0,-5} | {1,-3} | {2,-3} | {3,-7} | {4,-3}", _name, _wincount, _drawcount, _loosecount, _finalscore, ID);
    }

}

public class Program
{

    static void Sort(Human[] participants)
    {
        int i = 1;
        int j = i + 1;
        while (i < participants.Length)
        {
            if (participants[i].Finalscore < participants[i - 1].Finalscore)
            {
                i = j;
                j++;
            }
            else
            {
                Human temp = participants[i];
                participants[i] = participants[i - 1];
                participants[i - 1] = temp;
                i--;
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        Human[] participants = new Athlete[6]
        {
            new Athlete("Kolin", 3,2,5),
            new Athlete("Dima", 4,0,6),
            new Athlete("Lima", 8,2,0),
            new Athlete("Mila", 5,2,3),
            new Athlete("Glina", 6,3,1),
            new Athlete("Isaac", 3,3,4)
        };

        Console.WriteLine("Список участников");
        Console.WriteLine("Имя   Победы Ничьи Поражения Результат");
       
        Sort(participants);
        string[] filesName =
        {
            "participant.json",
            "participant.xml",
            "participant.bin"

        };
        MySerializer[] Ser =
        {
            new MyJsonSerilazer(),
            new MyXmlSerilazer(),
            new MyBinSerilazer()

        };
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string floder = "Lab9_2";
        path = Path.Combine(path, floder);
        if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
        string[] Seral =
        {
            "Json Ser",
            "Xml Ser",
            "Bin Ser"
        };

        for (int i = 0; i < filesName.Length; i++)
        {
            Ser[i].Write(participants, Path.Combine(path, filesName[i]));
        }
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(Seral[i]);
            var part = Ser[i].Read<Human[]>(Path.Combine(path, filesName[i]));
            foreach (var p in part)
            {
                p.Print();
            }
            Console.WriteLine();

        }
    }



}