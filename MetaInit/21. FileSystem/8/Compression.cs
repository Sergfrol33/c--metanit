using System.IO.Compression;


namespace FileSystem;

public class Compression
{
    public void GZipCompression()
    {
        var sourceFile = @"C:\SomeDir\hta.txt"; //исходный файл
        var compressedFile = @"C:\SomeDir\hta.gz"; //сжатый файл
        var targetFile = @"C:\SomeDir\hta_new.txt"; //восстановленный файл
        
        //создание сжатого файла
        Compress(sourceFile,compressedFile);
        //чтение из сжатого файла
        Decompress(compressedFile,targetFile);
    }

    private void Compress(string sourceFile, string compressedFile)
    {
        //поток для чтения исходного файла
        using var sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
        //поток для записи сжатого файла
        using var targetStream = System.IO.File.Create(compressedFile);
        //поток архивации
        using var compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
        sourceStream.CopyTo(compressionStream); //копируем байты из одноого потока в другогй
        Console.WriteLine(
            $"Сжатие файла {sourceFile} завершено. Исходный размер: {sourceStream.Length.ToString()} сжатый размер: {compressionStream.Length.ToString()}");
    }

    private void Decompress(string compressedFile, string targetFile)
    {
        // поток для чтения из сжатого файла
        using FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);
        // поток для записи восстановленного файла
        using FileStream targetStream = System.IO.File.Create(targetFile);
        // поток разархивации
        using GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
        decompressionStream.CopyTo(targetStream);
        Console.WriteLine($"Восстановлен файл: {targetFile}");
    }

    public void ZipCompression()
    {
        var sourceFolder = @"C:/SomeDir/"; //исходный файл
        var zipFile = @"C:\SomeDir.zip"; //сжатый файл
        var targetFolder =  @"C:/newDir"; //папка, куда распаковывать
        
        ZipFile.CreateFromDirectory(sourceFolder,zipFile);
        Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
        ZipFile.ExtractToDirectory(zipFile,targetFolder);
        
        Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
    }
}