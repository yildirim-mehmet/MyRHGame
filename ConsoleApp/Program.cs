using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("myapp :)");
        }
    }
}