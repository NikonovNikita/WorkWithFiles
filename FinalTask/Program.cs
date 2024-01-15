using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string datFilePath = @"\Users\Никонов\OneDrive\Рабочий стол\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            string dirPath = "\\Users\\Никонов\\OneDrive\\Рабочий стол\\Students";
            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            try
            {
                using(FileStream fileStream = new FileStream(datFilePath, FileMode.Open))
                {
                    var students = (Student[])formatter.Deserialize(fileStream);
                    Console.WriteLine($"Файл {fileStream.Name} успешно десериализован");

                    var sortedGroups = Sort(ref students);

                    foreach (var groupNumber in sortedGroups)
                    {
                        File.Create(Path.Combine(dirPath, groupNumber + ".txt")).Close();
                    }

                    foreach (var student in students)
                    {
                        for (int i = 0; i < sortedGroups.Length; i++)
                        {
                            if (student.Group == sortedGroups[i])
                            {
                                using (StreamWriter writer = File.AppendText(Path.Combine(dirPath, sortedGroups[i] + ".txt")))
                                {
                                    writer.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}");
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static string[] Sort(ref Student[] students)
        {
            string[] groups = new string[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                int counter = 0;

                for (int j = 0; j < groups.Length; j++)
                {
                    if (students[i].Group == groups[j])
                        counter++;
                }

                for (int k = 0; k < groups.Length; k++)
                {
                    if (counter == 0 && groups[k] == null)
                    {
                        groups[k] = students[i].Group;
                        break;
                    }
                }
            }

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] == null)
                    Array.Resize(ref groups, i);
            }

            return groups;
        }
    }
}
