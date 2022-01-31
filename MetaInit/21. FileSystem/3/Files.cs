namespace FileSystem
{
    public class File
    {
        private string _path;

        public File(string path)
        {
            _path = path;
        }
        public void GetFileInfo()
        {
            FileInfo fileInfo = new(_path);
            if (!fileInfo.Exists) return;
            
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Размер: {fileInfo.Length}");
        }

        private void IsFileExist(Action del)
        {
            if (!System.IO.File.Exists(_path)) return;
            del();
        }

        private void _DeleteFile()
        {
            var fileInf = new FileInfo(_path);
            fileInf.Delete();
        }
        public void DeleteFile() => IsFileExist(_DeleteFile);

        private void _MoveFile(string newPath)
        {
            var fileInf = new FileInfo(_path);
            fileInf.MoveTo(newPath); 
        }
 
    }
}