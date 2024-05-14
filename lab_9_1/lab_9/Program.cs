using System.IO;
using System.Xml.Serialization;
using ProtoBuf;
using Serializations;
using System.Xml.Linq;
using System.Text.Json;
using System.Diagnostics;
using System.Reflection.Emit;
[Serializable]
[ProtoContract]
public class Participant
{
    public string _surname;
    public string _community;
    public int _result1;
    public int _result2;
    public int _finalresult;
    [ProtoMember(6)]
    [XmlElement("disqualification")]
    public bool _disqualification {get; set;}
    [ProtoMember(1)]
    public string Surname
    {
        get { return _surname; }
        set { _surname = value ?? string.Empty ; }
    }
    [ProtoMember(2)]
    public string Community
    {
        get { return _community; }
        set { _community = value ?? string.Empty;  }
    }
    [ProtoMember(3)]
 
    public int Result1
    {
        get { return _result1; }
        set { _result1 = value; }
    }
    [ProtoMember(4)]
    public int Result2
    {
        get { return _result2; }
        set { _result2 = value; }
    }
    [ProtoMember(5)]
    public int FinalResult
    {
        get { return _finalresult; }
        set { _finalresult = value; }
    }
    public Participant() { }
    public Participant(string surname, string community, int result1, int result2)
    {
        _surname = surname;
        _community = community;
        _result1 = result1;
        _result2 = result2;
        _finalresult = result1 + result2;
        _disqualification = false;
    }
    public void Disqualification()
    {
        if (!_disqualification)
        {
            _disqualification = true;
        }
    }
    public void Print()
    {
        if (!_disqualification)
        {
            Console.WriteLine("{0,-7} | {1,-8} | {2,-16} | {3,-2} ", _surname, _community, _result1, _result2);
        }

    }
    public static void Sort(Participant[] participants)
    {
        int d = participants.Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < participants.Length; i++)
            {
                int j = i;
                int x = participants[i]._finalresult;
                while (j >= d && participants[j - 1]._finalresult > x)
                {
                    Participant temp = participants[j];
                    participants[j] = participants[j - 1];
                    participants[j - 1] = temp;
                    j -= d;
                }

            }
            d /= 2;
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Participant[] participants = new Participant[5]
        {
            new Participant("Lenon", "pus", 20,21),
            new Participant("Leontev", "dus", 19,18),
            new Participant("Kirilov", "bus", 23,18),
            new Participant("Korotki", "sus", 17,19),
            new Participant("Bolshoi", "gus", 24,10)
        };
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
        string floder = "Lab9";
        path = Path.Combine(path, floder);
        if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }


        Participant.Sort(participants);
        string[] Seral =
        {
            "Json Ser",
            "Xml Ser",
            "Bin Ser"
        };
        Console.WriteLine("Места");
        Console.WriteLine("Фамилия | Общество | Первый Результат | Второй Результат");
        participants[2].Disqualification();
        participants[0].Disqualification();
        for (int i = 0; i < filesName.Length; i++)
        {
            Ser[i].Write(participants, Path.Combine(path, filesName[i]));
        }
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(Seral[i]);
            var part = Ser[i].Read<Participant[]>(Path.Combine(path, filesName[i]));
            foreach (var p in part)
            {
                p.Print();
            }
            Console.WriteLine();

        }




    }

}