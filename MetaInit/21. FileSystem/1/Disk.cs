namespace FileSystem
{
    class Disk
    {
        public static void GetDrivers()
        {
            var drivers = DriveInfo.GetDrives();
            foreach (var driver in drivers)
            {
                Console.WriteLine($"name: {driver.Name}");
                Console.WriteLine($"Тип: {driver.DriveType}");
                if (driver.IsReady)
                {
                    Console.WriteLine($"Объем диска: {driver.TotalSize / Math.Pow(1024,3)}");
                    Console.WriteLine($"Свободное пространство: {driver.TotalFreeSpace / Math.Pow(1024,3)}");
                    Console.WriteLine($"Метка диска: {driver.VolumeLabel}");
                }
            }
        }
    }
}