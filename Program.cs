namespace WordsCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\SkillFactory\\module3\\WordsCounter\\Text1.txt";
            string text = File.ReadAllText(path);

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var wordsDict = new Dictionary<string, int>();
            foreach (var item in words)
            {
                if (!wordsDict.ContainsKey(item))
                    wordsDict.Add(item, 1);
                wordsDict[item]++;
            }

            //Сортируем содержимое словаря по убыванию значений
            var topTenWords = wordsDict.OrderByDescending(x => x.Value).Take(10);

            Console.WriteLine("Перечень десяти слов, которые чаще всего встречаются в тексте:");
            foreach (var item in topTenWords)
                Console.WriteLine($"{item.Key}: {item.Value}");

        }
    }
}