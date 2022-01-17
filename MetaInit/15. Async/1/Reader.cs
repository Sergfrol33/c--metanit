using System;
using System.IO;

namespace Async
{
    public class Reader
    {
        public async void ReadWriteAsync()
        {
            const string s = "Hello world!";
            // hello.txt - файл, который будет записываться и считываться
            await using (StreamWriter writer = new("hello.text", false))
            {
                await writer.WriteLineAsync(s); // асинхронная запись в файл   
            }
            using (StreamReader reader = new("hello.text"))
            {
                string result = await reader.ReadToEndAsync(); // асинхронное чтение из файла
                Console.WriteLine(result);
            }
        }
    }
}