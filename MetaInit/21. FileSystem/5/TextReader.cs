namespace FileSystem;

public class TextReader
{
    private string _path;
    
    public TextReader(string path)
    {
        _path = path;
    }

    public void Write(string text)
    {
        try
        {
            using (var sw = new StreamWriter(_path,false,System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
            using (var sw = new StreamWriter(_path,true,System.Text.Encoding.Default))
            {
                sw.WriteLine("Дозапись");
                sw.Write(4.5);
            }
            Console.WriteLine("Запись выполнена");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async void WriteAsync(string text)
    {
        try
        {
            await using (var sw = new StreamWriter(_path,false,System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(text);
            }
            await using (var sw = new StreamWriter(_path,true,System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync("Дозапись");
                sw.Write(4.5);
            }
            Console.WriteLine("Запись выполнена");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public void Read()
    {
        try
        {
            using var sr = new StreamReader(_path);
            Console.WriteLine(sr.ReadToEnd());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async void ReadAsync()
    {
        try
        {
            using var sr = new StreamReader(_path);
            Console.WriteLine(await sr.ReadToEndAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ReadLineByLine()
    {
        try
        {
            using var sr = new StreamReader(_path, System.Text.Encoding.Default);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async void ReadLineByLineAsync()
    {
        try
        {
            using var sr = new StreamReader(_path, System.Text.Encoding.Default);
            string? line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}