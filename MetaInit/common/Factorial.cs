namespace MetaInit.common
{
    public class Calculation
    {
        public static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
        }
    }
}