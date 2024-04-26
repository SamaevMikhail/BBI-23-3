using System.Text.Json;
using System.Text.Json.Serialization;
class Task
{
    protected string text;
    public Task(string text)
    {
        this.text = text;
    }
}
class Task1 : Task 
{
    [JsonConstructor]
    public Task1(string text) : base(text)
    { }
   
   
   

    public override string ToString()
    {
        return DeleteAllPuctuationDel(text);
    }
    private string DeleteAllPuctuationDel(string text)
    {
        var splitText = text.Split(".,;:?!-".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        string newText = "";
        foreach (var v in splitText)
        {
            newText += v;
        }

        return newText;
    }
}
class Task2 : Task
{
    [JsonConstructor]
    public Task2(string text):base(text) { }
    public override string ToString()
    {
        string numString = "";
        double[] floatNumArr = FindAllNumInText(text);
        foreach(var i in floatNumArr)
        {
            numString += i + ", ";
        }
        
        return numString;
    }
    private double[] FindAllNumInText(string text)
    {
        var splitText = text.Split(" ;:?!№".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        List<double> numbersInText = new List<double>();
        for (int i =0; i<splitText.Length; i++)
        {
            if (splitText[i].Length<2 && splitText[i][0] == '-')
            {
                if (char.IsDigit(splitText[i][1]) )
                {
                    numbersInText.Add(Convert.ToDouble(splitText[i]));
                }
            }
            if (char.IsDigit(splitText[i][0])  )
            {
                numbersInText.Add(Convert.ToDouble(splitText[i]));
            }

        }
        return numbersInText.ToArray();
    }
}
class JsonManager
{
    public static void Write<T>(T obj, string path)
    {
        using (FileStream fs= new FileStream(path, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<T>(fs,obj);
        }
    }
    public static T Read<T>(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
            
        }
        return default(T);
    }
}

class CrW2 
{
    public static void Main()
    {
        string text = "dsffds 1 1,6 3244324 fdhghfh -4 cnjg  №12";
        Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
        string path = @"C:\Users\m2306631\Downloads";
        string dirName = "Solution";
        path = Path.Combine(path, dirName);
        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string file1Name = "task_1.json";
        string file2Name = "task_2.json";
        string file1Path = Path.Combine(path, file1Name);
        string file2Path = Path.Combine(path, file2Name);
        //if (!File.Exists(file1Path))
        //{
        //    File.Create(file1Path).Close();

        //}
        if (!File.Exists(file1Path)) 
        {
            JsonManager.Write<Task1>((Task1)tasks[0], file1Path);
        }
        else
        {
            var file1 = JsonManager.Read<Task1>(file1Path);
            Console.WriteLine(file1.ToString());
        }
        if (!File.Exists(file2Path))
        {
            JsonManager.Write<Task2>((Task2)tasks[1], file2Path);
        }
        //else
        //{
        //    var file2 = JsonManager.Read<Task2>(file2Path);
        //    Console.WriteLine(file2.ToString());
        //}
    }
}

