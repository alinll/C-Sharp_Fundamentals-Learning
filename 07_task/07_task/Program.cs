internal class Program
{
    private static void Main(string[] args)
    {
        //1
        string fileName = "data.txt";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(path, fileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine($"{filePath} is created");
        }

        using (StreamWriter writer = File.CreateText(filePath))
        {
            Console.WriteLine("Enter text to file:");
            string text = Console.ReadLine();
            writer.WriteLine(text);
            Console.WriteLine($"In {filePath} added content :\n{text}");
        }

        string copyFileName = "rez.txt";
        string copyFilePath = Path.Combine(path, copyFileName);

        using (StreamReader reader = File.OpenText(filePath))
        {
            string allContent = reader.ReadToEnd();
            Console.WriteLine($"All content from {filePath} :\n{allContent}");

            File.WriteAllText(copyFilePath, allContent);
            Console.WriteLine($"In {copyFilePath} added content");
        }

        using (StreamReader copyReader = File.OpenText(copyFilePath))
        {
            string allCopyContent = copyReader.ReadToEnd();
            Console.WriteLine($"Content in {copyFilePath} :\n{allCopyContent}");
        }

        //2
        string fileName2 = "DirectoryC.txt";
        string fileName2Path = Path.Combine(path, fileName2);

        if (!File.Exists(fileName2Path))
        {
            File.Create(fileName2Path).Close();
            Console.WriteLine($"{fileName2Path} is created");
        }

        string discPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
        string discName = "D:";

        DirectoryInfo driveInfo = new DirectoryInfo(Path.Combine(discPath, discName));

        try
        {
            if (!Directory.Exists(discName))
            {
                throw new Exception($"{discName} doesn't exist");
            }
            using (StreamWriter writer = File.CreateText(fileName2Path))
            {
                writer.WriteLine($"{driveInfo} has such directories:");

                foreach (var directories in driveInfo.GetDirectories())
                {
                    writer.WriteLine($"{directories.Name}");
                }

                writer.WriteLine($"\n{driveInfo} has such files:");

                foreach (var files in driveInfo.GetFiles())
                {
                    writer.WriteLine($"{files.Name} size: {files.Length / 1024.0 / 1024}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        using (StreamReader reader = File.OpenText(fileName2Path))
        {
            string allContent = reader.ReadToEnd();
            Console.WriteLine(allContent);
        }

        //3
        string directoryPath = @"C:\Users\Aser\OneDrive\Робочий стіл\test";

        try
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new Exception($"{directoryPath} doesn't exist");
            }
            
            using (StreamReader reader = File.OpenText(directoryPath))
            {
                string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt");
                foreach (var files in txtFiles)
                {
                    string allContent = reader.ReadToEnd();
                    Console.WriteLine(allContent);
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}