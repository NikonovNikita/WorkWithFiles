namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            string path = @"\luft"; // Необходимо указать путь
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                try
                {
                    long originalSize = GetInfoAboutSize(dirInfo);
                    DirectoryDeleter(dirInfo);
                    long currentSize = GetInfoAboutSize(dirInfo);
                    Console.WriteLine($"\nИсходный размер каталога: {originalSize} байт");
                    Console.WriteLine($"Освобождено: {originalSize - currentSize} байт");
                    Console.WriteLine($"Текущий размер каталога: {currentSize} байт");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Исключение: {ex.Message}");
                }
            }
            else { Console.WriteLine("Не удалось найти указанный каталог :("); }
        }
        static void DirectoryDeleter(DirectoryInfo dirInfoParam)
        {
            foreach (var di in dirInfoParam.GetDirectories())
            {
                DirectoryDeleter(di);
                var tempTime = DateTime.Now;
                if (tempTime - di.LastAccessTime >= TimeSpan.FromMinutes(30))
                {
                    di.Delete();
                }
            }
            foreach (var fi in dirInfoParam.GetFiles())
            {
                var tempTime = DateTime.Now;
                if (tempTime - fi.LastAccessTime >= TimeSpan.FromMinutes(30))
                {
                    fi.Delete();
                }
            }
        }
        public static long GetInfoAboutSize(DirectoryInfo dirInfo)
        {
            long returnSize;
            try
            {
                returnSize = GetSize(dirInfo);
                return returnSize;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка во время работы программы: {ex.Message}");
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