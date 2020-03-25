using System;
using DAL;

namespace FoodPriceBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Products products=new Products();
            Console.WriteLine(products.GetFishAndSeafood());
        }
        
    }
}