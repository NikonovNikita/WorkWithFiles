using System.Runtime.Serialization.Formatters.Binary;
namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string datFilePath = @"\Users\Никонов\OneDrive\Рабочий стол\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(datFilePath, FileMode.Open))
            {
                try
                {
                    var students = (Student[])formatter.Deserialize(fileStream);
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Name}\n{student.Group}\n{student.DayOfBirth}");
                        Console.WriteLine("\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
