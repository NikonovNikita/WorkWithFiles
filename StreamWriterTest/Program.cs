using System;
using System.IO;
class FileWriter
{
    public static void Main()
    {
        string filePath = "\\Users\\Никонов\\OneDrive\\Рабочий стол\\Students\\jopa.txt"; // Укажем путь 
        if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
        {
            //   Если не существует - создаём и записываем в строку
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // Откроем файл и прочитаем его содержимое

    }
}
