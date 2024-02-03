using System.Diagnostics;
using TechTalk.SpecFlow;

namespace BankSystem.Tests.Utilities
{
    [Binding]
    public class Utils
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();

            // Generate random uppercase alphabets (A-Z) ASCII values: 65-90
            char[] letters = Enumerable.Range(65, 26).Select(x => (char)x).ToArray();

            // Shuffle the array to get a random order
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                char temp = letters[i];
                letters[i] = letters[j];
                letters[j] = temp;
            }

            // Take the first 'length' characters
            string randomString = new string(letters.Take(length).ToArray());

            return randomString;
        }

        public static string GetFormattedTimestamp()
        {
            DateTime now = DateTime.Now;
            return now.ToString("yyyyMMdd_HHmmss");
        }

        public static void GenerateLivingDocReport()
        {
            string testAssemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BankSystem.Tests.dll");
            string outputFilePath = Path.Combine("..", "..", "..", "Reports", $"Report_{GetFormattedTimestamp()}.html");

            string command = $"livingdoc test-assembly {testAssemblyPath} -t TestExecution.json --output {outputFilePath}";

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", $"/c {command}");
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;

            Process process = new Process { StartInfo = psi };
            process.Start();
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            Console.WriteLine($"Command Output: {output}");
            Console.WriteLine($"Command Error: {error}");
        }
    }
}
