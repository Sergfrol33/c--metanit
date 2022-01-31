namespace FileSystem
{
    public class Catalog
    {
        private static string _dirName = "C:\\";
        public static void GetFiles()
        {
            if (Directory.Exists(_dirName))
            {
                Console.WriteLine("Подкаталоги");
                var dirs = Directory.GetDirectories(_dirName);
                foreach (var s in dirs)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Файлы");
            var files = Directory.GetFiles(_dirName);
            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
        }

        public static void CreateDirectory(string path, string subpath)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            Directory.CreateDirectory($"{path}/{subpath}");
        }

        public static void DeleteDirectory()
        {
            var dirName = @"C:\SomeDir";
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName,true);
                Console.WriteLine("Каталог удален");
            }
            else
            {
                Console.WriteLine("Каталога не существует");
            }
        }

        public static void MoveDirectory(string oldPath,string newPath)
        {
            if (Directory.Exists(oldPath) && !Directory.Exists(newPath))
            {
                Directory.Move(oldPath,newPath);
                Console.WriteLine("Папка передвинута");
            }
            else
            {
                throw new DirectoryNotFoundException("Невозможно передвинуть каталог");
            }
        }
    }
}