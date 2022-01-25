namespace Garbage;

public class UnsafeCode
{
    public static void Test()
    {
        unsafe
        {
            int* x; //определяем указатель
            var y = 10; //определяем переменную

            x = &y; //указатель x теперь указывает на адрес переменной y
            
            Console.WriteLine($"x {*x}"); //10

            y += 20;
            Console.WriteLine($"x {*x}"); //30
            
            *x = 50;
            
            Console.WriteLine($"y {y}"); //переменная y=50

            
        }
    }

    public static void GetMemoryAddress()
    {
        unsafe
        {
            int* x; //определяем указатель
            var y = 10; //определяем переменную

            x = &y;
            
            //получаем адресс памяти y
            var addr = (uint) x;
            Console.WriteLine($"address y: {addr}");
        }
    }

    public static void TakeAnotherAddress()
    {
        unsafe
        {
            int* x; // определение указателя
            var y = 10; // определяем переменную
 
            x = &y; // указатель x теперь указывает на адрес переменной y
            int** z = &x; // указатель z теперь указывает на адрес, который указывает и указатель x
            **z = **z + 40; // изменение указателя z повлечет изменение переменной y
            Console.WriteLine(y); // переменная y=50
            Console.WriteLine(**z); // переменная **z=50
        }
    }
}