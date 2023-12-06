class Program
{
    static void Main(string[] args)
    {
        string path = @"\luft"; // Необходимо указать путь к каталогу
        DirectoryInfo dirInfo = new(path);
        Console.WriteLine($"Указанный каталог {dirInfo.Name} имеет размер {GetSize(dirInfo)} байт");

        static long GetSize(DirectoryInfo dirInfoParam)
        {
            long size = 0;
            foreach(var fi in dirInfoParam.GetFiles())
            {
                Console.WriteLine($"Файл {fi.Name} имеет размер {fi.Length} байт");
                size += fi.Length;
            }
            foreach(var di in dirInfoParam.GetDirectories())
            {
                size += GetSize(di);
            }
            return size;
        }
    }
}
