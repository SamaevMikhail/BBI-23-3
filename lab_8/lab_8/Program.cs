
abstract class Task
{
    public Task(string text) { }
    protected abstract string ParseText(string text); 
    protected virtual Dictionary<string, int> CreateRusLetterDict()
    {
        return new Dictionary<string, int>();
    }
    protected bool CheckTextOnLanguage(string text)
    {
        var uFirsLetter = text[0].ToString().ToLower().ToCharArray();
        if ((int)uFirsLetter[0] > 96 && (int)uFirsLetter[0] < 124)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected virtual Dictionary<string, int> CreateEngLetterDict()
    {
        return new Dictionary<string, int>();
    }
    protected string[] CreateCode()
    {
        string[] code = new string[10];
        int c = 0;
        for (int i = 65; i < 75; i++)
        {
            code[c] = char.ToUpper((char)i).ToString();
            c++;
            if (c == 10)
            {
                break;
            }
        }
       
        return code;
    }
}



class Task_8 : Task
{
    string text;
    public Task_8(string text) : base(text) { this.text = text; }
    public override string ToString()
    {
        text = ParseText(text);
        return text;
    }
    protected override string ParseText(string text)//Превращает текс в строки по 50 символов.
    {
        int start = 0;
        string result = "";
        int i = 50;
        for (int j = i; j < text.Length; j += i)
        {
            string s = "";
            int k;
            for (k = j; j >= start; k--)
            {
                if (text[k] == ' ')
                {
                    break;
                }
                s += " ";
            }
            string line = text.Substring(start, k - start) + s;
            start = k + 1;
            j = start;
            result += line + "\n";
            // Console.WriteLine("i = {0}, k = {1}, j = {2}, start = {3}", i, k, j, start); //
            // Console.WriteLine(line); //
        }

        return result;

    }
}
class Task_9 : Task 
{
    string text;
    public Task_9(string text) : base(text) { this.text = text; }
    public override string ToString()
    {
       
        return ParseText(text);
    }
    protected string[] First10KeysToArray(Dictionary<string, int> a) 
    {
        return a.Take(10).Select(x => x.Key).ToArray();
    }
    protected override Dictionary<string, int> CreateRusLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 1072; i < 1105; i++)
        {
            for (int j = 1072; j < 1105; j++)
            {
                int n1 = i;
                int n2 = j;
                if (i == 1104) { n1 += 1; }
                if (j == 1104) { n2 += 1; }
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }
        return letterComb;
    }
    protected override Dictionary<string, int> CreateEngLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 97; i < 123; i++)
        {
            for (int j = 97; j < 123; j++)
            {
                int n1 = i;
                int n2 = j;
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }
       
        return letterComb;
    }
   
    protected override string ParseText(string text)
    {
        Dictionary<string, int> letterComb= new Dictionary<string, int>();
       
        if (CheckTextOnLanguage(text))
        {
            letterComb = CreateEngLetterDict();
        }
        else
        {
           letterComb = CreateRusLetterDict();
        }
        
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (letterComb.ContainsKey(text[i].ToString() + text[i + 1].ToString()))
            {
                letterComb[text[i].ToString() + text[i + 1].ToString()]++;
            }
        }

        var sortedLetterComb = letterComb.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        //foreach (var l in sortedLetterComb)
        //{
        //    if (l.Value > 1)
        //    {
        //        Console.WriteLine(l.Value + " " + l.Key);
        //    }

        //}
        string[] ke = First10KeysToArray(sortedLetterComb);
       
        string[] code = CreateCode();

        

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(ke[i], code[i]);
        }
        //Console.WriteLine(text);
        return text;
    }

}
class Task_10 : Task 
{
    string text;
    public Task_10(string text) : base(text) { this.text = text; }
    public override string ToString()
    {

        return ParseText(text);
    }
    protected override string ParseText(string text) //Декодирует текст, который получен в результате кодировки в Task_9, определенным кодом
    {

        string[] ke = { "ПЕ", "во", "е ", "кр", "тос", "вт", "ое", "пу", "те", "ше" };//ТУт пишется символы на которые надо заменить.
        string[] code = CreateCode();

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(code[i], ke[i]);
        }

        return text; 
    }

}
class Task_12 : Task
{
    string text;
  
    public Task_12(string text) : base(text)
    {
        this.text = text;
    }
    private Dictionary<string, string> GenerateEnglishCodeTable()
    {
        string[] words = { "the", "be", "to", "of", "and", "a", "in", "that", "have", "I" };
        string[] codes = { "@", "#", "$", "%", "&", "*", "(", ")", "!", "?" };

        Dictionary<string, string> codeTable = new Dictionary<string, string>();
        for (int i = 0; i < words.Length; i++)
        {
            codeTable[words[i]] = codes[i];
        }

        return codeTable;
    }

    private Dictionary<string, string> GenerateRussianCodeTable()
    {
        string[] words = { "я", "это", "что", "ты", "был", "и", "себя", "мама", "в", "иметь" };
        string[] codes = { "@", "#", "$", "%", "&", "*", "(", ")", "!", "?" };

        Dictionary<string, string> codeTable = new Dictionary<string, string>();
        for (int i = 0; i < words.Length; i++)
        {
            codeTable[words[i]] = codes[i];
        }

        return codeTable;
    }
    public override string ToString()
    {
        return ParseText(text);
    }

    protected override string ParseText(string text)
    {
        Dictionary<string, string> codeTable = new Dictionary<string, string>();
        if (CheckTextOnLanguage(text))
        {
            codeTable = GenerateEnglishCodeTable();
        }
        else 
        {
            codeTable=GenerateRussianCodeTable();
        }

        string[] wordsInText = text.Split(' ');
        for (int i = 0; i < wordsInText.Length; i++)
        {
            if (codeTable.ContainsKey(wordsInText[i]))
            {
                wordsInText[i] = codeTable[wordsInText[i]];
            }
        }

        string decodedText = string.Join(" ", wordsInText);
        Console.WriteLine(decodedText); 
        Console.WriteLine();
        foreach (var pair in codeTable)
        {
            decodedText = decodedText.Replace(" " + pair.Value + " ", " " + pair.Key + " ");
        }
        return decodedText;
    }
}
class Task_13 : Task 
{
    string text;

    public Task_13(string text) : base(text)
    {
        this.text = text;
    }
    public override string ToString()
    {
        return ParseText(text);
    }
    protected override Dictionary<string, int> CreateRusLetterDict() 
    {
        Dictionary<string, int> rusLetters = new Dictionary<string, int>();
        for (int j = 1072; j < 1105; j++)
        {
            int n2 = j;
            if (j == 1104) { n2 += 1; }
            char second = (char)n2;
            rusLetters.Add(second.ToString(), 0);//Добавление в словарь всех русских букв

        }
        return rusLetters;
    }
    protected override Dictionary<string, int> CreateEngLetterDict()
    {
        Dictionary<string, int> engLetters = new Dictionary<string, int>();
        for (int j = 97; j < 123; j++)
        {
            int n2 = j;
            char second = (char)n2;
            engLetters.Add(second.ToString(), 0);//Добавление в словарь всех русских букв

        }
        return engLetters;
    }
    protected override string ParseText(string text)// Считает процент слов с какой то определенной буквы
    {
        Dictionary<string, int> letters = new Dictionary<string, int>() ;
        if (CheckTextOnLanguage(text))
        {
            letters = CreateEngLetterDict();
        }
        else
        {
            letters = CreateRusLetterDict();
        }
        string[] wordsInText = text.Split(" ");
        int wordsCount = wordsInText.Length;
        for (int i = 0; i < wordsCount; i++)
        {
            if (letters.ContainsKey(wordsInText[i][0].ToString().ToLower()))
            {
                letters[wordsInText[i][0].ToString().ToLower()]++; //Подсчет сколько раз появилась буква.
            }
        }
        foreach (var letter in letters)
        {
            double percent = (letter.Value * 100) / wordsCount; //Подсчет процента слов которые начинаются с каждой буквы
            letters[letter.Key] = Convert.ToInt32(percent); // Замена значений на проценты
            

        }
       
        foreach(var letter in letters)
        {
            if (letter.Value >= 2)  // Выводит только буквы у которых процент больше 2-ух
            {
                Console.WriteLine($"Буква {letter.Key} {letter.Value:f2}%");
            }
        }
        return "";
    }
}
class Task_15 : Task
{
    string text;
    public Task_15(string text) : base(text) { this.text = text; }
    public override string ToString()
    {

        return ParseText(text);
    }
    protected override string ParseText(string text) //Считает сумму чисел в строке
    {
        string[] wordsInText = text.Split(" ".ToCharArray());
    
        double sum = 0;
        for (int i = 0; i < wordsInText.Length; i++)
        {
            if (char.IsDigit(wordsInText[i][0]))
            {
                for (int j = wordsInText[i].Length-1; j > 0; j--)
                {
                    if (char.IsDigit(wordsInText[i][j]))
                    {
                        
                        sum += Convert.ToDouble(wordsInText[i].Substring(0, j +1));
                       
                        break;
                    }
                }
            }
           
        }
        return sum.ToString();
    }
}





class Program
{
    public static void Main()
    {
        string text = File.ReadAllText(@"C:\Users\user\Documents\Учеба\Прога\text3.txt");

        Task_8 task8 = new Task_8(text);
        Console.WriteLine("\t Задание 8");
        Console.WriteLine(task8);
        Console.WriteLine("\n \t Задание 9");
        Task_9 task9 = new Task_9(text);
        Console.WriteLine(task9);
        Console.WriteLine("\n\t Задание 10");
        Task_10 task10 = new Task_10(task9.ToString());
        Console.Write(task10);
        Console.WriteLine("\n \t Задание 12");
        Task_12 task12 = new Task_12(text);
        Console.WriteLine(task12.ToString());
        Console.WriteLine("\n \t Задание 13");
        Task_13 task13 = new Task_13(text);
        Console.WriteLine(task13);
        Console.WriteLine("\n \t Задание 15");
        Task_15 task15 = new Task_15(text);
        Console.WriteLine(task15);


    }

}
