using System;
using System.IO;
using System.Text.RegularExpressions;

namespace StringExtract
{
    class Program
    {
        static void Main(string[] args)
       {

            string filePath = "example.txt";
            string fileContent = null;

            try
            {
                // ファイルの内容を読み込む
                fileContent = File.ReadAllText(filePath);

                // 読み込んだ文字列を表示
                Console.WriteLine("ファイルの内容:");
                Console.WriteLine(fileContent);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"ファイル '{filePath}' が見つかりません。");
            }
   
            // 元の文字列
            string inputString = "This is a \"sample\" string with \"multiple\" occurrences of \"quoted\" text.";

            // 正規表現パターンでダブルクオートで囲まれた文字列を抽出
            string pattern = "\"(.*?)\"";
            MatchCollection matches = Regex.Matches(fileContent, pattern);

            // 抽出した文字列をファイルに出力
            string outputPath = "output.txt";
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (Match match in matches)
                {
                    string extractedString = match.Groups[1].Value;
                    writer.WriteLine(extractedString);
                }
            }

            Console.WriteLine("抽出が完了しました。出力ファイルパス：" + outputPath);
        }
    }
}
