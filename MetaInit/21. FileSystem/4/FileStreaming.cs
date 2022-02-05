using System.Text;

namespace FileSystem;

public class FileStreaming
{
    public void ReadAndWrite()
    {
        var path = @"C:\SomeDir2";
        DirectoryInfo directoryInfo = new(path);

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        Console.WriteLine("Введите строку для записи в файл:");
        var text = Console.ReadLine();

        //запись в файл
        using (FileStream fstream = new(@$"{path}\note.txt", FileMode.OpenOrCreate))
        {
            // преобразуем строку в байты
            var array = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.Write(array, 0, array.Length);
        }

        //чтение из файла
        using (var fstream = System.IO.File.OpenRead(@$"{path}\note.txt"))
        {
            //преобразуем строку в байты
            var array = new byte[fstream.Length];
            //считаем данные
            fstream.Read(array,0,array.Length);
            //декодируем байты в строку
            var textFromFile = Encoding.Default.GetString(array);
            Console.WriteLine($"Текст из файла {textFromFile}");
        }
    }
    public async void ReadAndWriteAsync()
    {
        var path = @"C:\SomeDir2";
        DirectoryInfo directoryInfo = new(path);

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        Console.WriteLine("Введите строку для записи в файл:");
        var text = Console.ReadLine();

        //запись в файл
       await using (FileStream fstream = new(@$"{path}\note.txt", FileMode.OpenOrCreate))
        {
            // преобразуем строку в байты
            var array = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
           await fstream.WriteAsync(array, 0, array.Length);
        }

        //чтение из файла
        await using (var fstream = System.IO.File.OpenRead(@$"{path}\note.txt"))
        {
            //преобразуем строку в байты
            var array = new byte[fstream.Length];
            //считаем данные
            await fstream.ReadAsync(array,0,array.Length);
            //декодируем байты в строку
            var textFromFile = Encoding.Default.GetString(array);
            Console.WriteLine($"Текст из файла {textFromFile}");
        }
    }

    public void Seek()
    {
        var text = "hello world";
        
        //запись в файл
        using (FileStream fstream = new FileStream(@"D:\note.dat",FileMode.OpenOrCreate))
        {
            //преобразуем строку в байты
            var input = Encoding.Default.GetBytes(text);
            //запись массив байтов в файл
            fstream.Write(input,0 ,input.Length);
            Console.WriteLine("Текст записан в файл");
            
            //перемещаем указатель в конец файла, до конца файла - пять байт
            fstream.Seek(-5,SeekOrigin.End); //минус пять символов с конца потока
            
            //считываем четыре символа с текущей позиций 
            var output = new byte[4];
            fstream.Read(output, 0, output.Length);
            //декодируем байты в строку
            var textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}"); //worl
            
            //заменим в файле слово world на слово house
            var replaceText = "house";
            fstream.Seek(-5, SeekOrigin.End); //минус 5 символов с конца потока
            input = Encoding.Default.GetBytes(replaceText);
            fstream.Write(input,0,input.Length);
            
            //считываем весь файл
            //возвращаем указатель в начало файла
            fstream.Seek(0,SeekOrigin.Begin);
            output = new byte[fstream.Length];
            fstream.Read(output,0,output.Length);
            //декодируем байты в строку
            textFromFile = Encoding.Default.GetString(output);
            Console.WriteLine($"Текст из файла: {textFromFile}"); //hello house

        }
    }
}