namespace Task2
{
    public class Program
    {
        static void Main()
        {
            GetInfo();
        }
        public static long GetInfo()
        {
            string path = @"\luft"; // Необходимо указать путь к каталогу
            DirectoryInfo dirInfo = new(path);
            long returnSize;
            if (dirInfo.Exists)
            {
                try
                {
                    returnSize = GetSize(dirInfo);
                    Console.WriteLine($"\nУказанный каталог {dirInfo.Name} имеет размер {returnSize} байт");
                    return returnSize;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Возникла ошибка во время работы программы: {ex.Message}");
                    return returnSize = 0;
                }
            }
            else
            {
                Console.WriteLine($"Каталога по указанному пути - {path} - не существует");
                return returnSize = 0;
            }
        }
        static long GetSize(DirectoryInfo dirInfoParam)
        {
            long size = 0;
            foreach (var fi in dirInfoParam.GetFiles())
            {
                size += fi.Length;
            }
            foreach (var di in dirInfoParam.GetDirectories())
            {
                size += GetSize(di);
            }
            return size;
        }
    }
}