internal class Program
{
    private static void Main(string[] args)
    {
        string personName, phoneNumber;
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        //1
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = "phones.txt";
        string filePath = Path.Combine(path, fileName);

        try
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File doesn't exist or path is incorrect");
            }

            string[] allInfo = File.ReadAllLines(filePath);

            foreach (string infoLine in allInfo)
            {
                string[] pair = infoLine.Split(' ');
                personName = pair[0].Trim();
                phoneNumber = pair[1].Trim();

                phoneBook[personName] = phoneNumber;
            }

            foreach (KeyValuePair<string, string> info in phoneBook)
            {
                Console.WriteLine($"{info.Key} phone number: {info.Value}");
            }

            string copyPhonesFileName = "Phones2.txt";
            string copyPhonesPath = Path.Combine(path, copyPhonesFileName);

            if (!File.Exists(copyPhonesPath))
            {
                File.Create(copyPhonesPath);
            }

             using (StreamWriter writer = File.CreateText(copyPhonesPath))
             {
                foreach (KeyValuePair<string, string> info in phoneBook)
                {
                    phoneNumber = info.Value;
                    writer.WriteLine(phoneNumber);
                }
             }
            using (StreamReader copyReader = File.OpenText(copyPhonesPath))
            {
                Console.WriteLine("\nOnly phone numbers: ");
                string copyInfo = copyReader.ReadToEnd();
                Console.WriteLine(copyInfo);
            }
            
            //2
            Console.Write("Enter a name for searching: ");
            string searchName = Console.ReadLine();

            foreach (KeyValuePair<string, string> info in phoneBook)
            {
                personName = info.Key;
                phoneNumber = info.Value;

                if (personName == searchName)
                {
                    Console.WriteLine(phoneNumber);
                }
            }

            //3
            string newFileName = "New.txt";
            string newFilePath = Path.Combine(path, newFileName);

            if (!File.Exists(newFilePath))
            {
                File.Create(newFilePath);
            }

            using(StreamWriter newWriter = File.CreateText(newFilePath))
            {
                foreach (KeyValuePair<string, string> info in phoneBook)
                {
                    personName = info.Key;
                    phoneNumber = info.Value;

                    if (phoneNumber.StartsWith("80"))
                    {
                        phoneNumber = "+380" + phoneNumber.Substring(2);
                    }

                    newWriter.WriteLine($"{personName} phone number : {phoneNumber}");
                }
            }

            using (StreamReader newReader = File.OpenText(newFilePath))
            {
                string infoNew = newReader.ReadToEnd();
                Console.WriteLine($"\nNew phone book:\n{infoNew}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}