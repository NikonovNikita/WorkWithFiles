class Program
{
    static void Main(string[] args)
    {
        string path = @"\luft"; // Необходимо указать путь
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (dirInfo.Exists)
        {
            try
            {
                Console.WriteLine($"Каталог {dirInfo.Name} содержит в себе:");
                DirectoryGetInfo(dirInfo);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }
        else { Console.WriteLine("Не удалось найти указанный каталог :("); }
    }
    static void DirectoryGetInfo(DirectoryInfo dirInfoParam)
    {
            foreach (var di in dirInfoParam.GetDirectories())
            {
                Console.WriteLine($"Папка: {di.Name}\tВремя последнего использования: {di.LastAccessTime}");  
                DirectoryGetInfo(di);
                var tempTime = DateTime.Now;    
                if(tempTime - di.LastAccessTime >= TimeSpan.FromMinutes(30))
                {
                    di.Delete();
                    Console.WriteLine($"Папка {di.Name} удалена");
                }
            }
            foreach (var fi in dirInfoParam.GetFiles())
            {
                Console.WriteLine($"Файл: {fi.Name}\tВремя последнего использования: {fi.LastAccessTime}");
                var tempTime = DateTime.Now;
                if(tempTime - fi.LastAccessTime >= TimeSpan.FromMinutes(30))
                {
                    fi.Delete();
                    Console.WriteLine($"Файл {fi.Name} удален");
                }
            }

    }
}