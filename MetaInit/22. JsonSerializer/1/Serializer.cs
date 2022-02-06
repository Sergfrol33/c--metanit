using System.Text.Json;
using MetaInit.common;

namespace JSONSerializer;

public class Serializer
{
    public static void Serialize()
    {
        var tom = new User {Age = 15, Name = "tom"};

        var json = JsonSerializer.Serialize<User>(tom);
        Console.WriteLine(json);
        User? restoredUser = JsonSerializer.Deserialize<User>(json);
        Console.WriteLine(restoredUser?.Age);
    }

    public static async void ReadAndWriteAsync()
    {
        await using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            User tom = new User { Name = "Tom", Age = 35 };
            await JsonSerializer.SerializeAsync(fs, tom);
            Console.WriteLine("Data has been saved to file");
        }
 
        // чтение данных
        await using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            User? restoredPerson = await JsonSerializer.DeserializeAsync<User>(fs);
            Console.WriteLine($"Name: {restoredPerson?.Name}  Age: {restoredPerson?.Age}");
        }
    }
}