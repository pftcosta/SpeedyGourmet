using SpeedyGourmet.Model;
using SpeedyGourmet.Repository;
using SpeedyGourmet.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        CategoryService categoryService = new CategoryService(categoryRepository);

        Console.WriteLine("name of cateory is...");
        Console.ReadLine();
        Category category = new Category();
        category.Name = "zé";

        categoryService.Create(category);
        categoryService.GetAll();
        Console.ReadLine();

        Console.ReadKey();

    }
}