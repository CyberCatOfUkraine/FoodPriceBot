using Parameters;

namespace DAL
{
    public class Products
    {
        private readonly FullProductPage _productPage = new FullProductPage();

        public string GetGrocery()
        {
            var product = _productPage.GetProductPageText(MainParameter.Grocery).Trim();

            product = product.Replace("Крупы", "Крупи:\n");
            product = product.Replace("Макароны", "\nМакарони:\n");
            product = product.Replace("Масло", "\nОлія:\n");
            product = product.Replace("Мука", "\nБорошно:\n");
            product = product.Replace("Сахар", "\nЦукор:\n");
            return product;
        }

        public string GetCannedFood()
        {
            var product = _productPage.GetProductPageText(MainParameter.CannedFood);
            product = product.Replace("Овощи", "Овочі:\n");
            product = product.Replace("Оливки\n", "\nОливки:\n");
            product = product.Replace("Рыба", "\nРиба\n");
            return product;
        }

        public string GetDairyProducts()
        {
            var product = _productPage.GetProductPageText(MainParameter.DairyProducts);
            product = product.Replace("\nЙогурт\n", "Йогурт:\n");
            product = product.Replace("Кефир\n", "\nКефір:\n");
            product = product.Replace("Маргарин\n", "\nМаргарин:\n");
            product = product.Replace("Масло\n", "\nМасло:\n");
            product = product.Replace("Молоко\n", "\nМолоко:\n");
            product = product.Replace("Сливки\n", "\nВершки:\n");
            product = product.Replace("Сметана\n", "\nСметана:\n");
            product = product.Replace("Сыр\n", "\nСир:\n");
            product = product.Replace("Творог\n", "\nСир(Творог):\n");
            product = product.Replace("ы", "и");
            return product;
        }

        public string GetMeatProducts()
        {
            var product = _productPage.GetProductPageText(MainParameter.MeatProducts);
            product = product.Replace("Колбасы", "Ковбаси:\n");
            product = product.Replace(" Мясные деликатесы", "\nМʼясні делікатеси:\n");
            product = product.Replace("Мясо\n", "\nМʼясо:\n");
            product = product.Replace("Сало\n", "\nСало\n");
            product = product.Replace("Сосиски и сардельки", "\nСосиски та сардельки:\n");
            return product;
        }

        public string GetDrinks()
        {
            var product = _productPage.GetProductPageText(MainParameter.Drinks);
            product = product.Replace("Кофе", "\nКава:\n");
            product = product.Replace("Минеральная вода", "\nМінеральна вода:\n");
            product = product.Replace("Сладкая вода", "\nСолодка вода:\n");
            product = product.Replace("Сок", "\nСік:\n");
            product = product.Replace("Спиртные", "\nСпиртне:\n");
            return product;
        }

        public string GetFishAndSeafood()
        {
            var product = _productPage.GetProductPageText(MainParameter.FishAndSeafood);
            product = product.Replace("Рыба", "Риба:\n");
            return product;
        }

        public string GetSaucesAndSpices()
        {
            var product = _productPage.GetProductPageText(MainParameter.SaucesAndSpices);
            product = product.Replace("Майонез\n", "Майонез:\n");
            product = product.Replace("Приправы", "\nПриправи:\n");
            product = product.Replace("Соль", "\nСіль:\n");
            product = product.Replace("Соусы", "\nСоуси:\n");
            product = product.Replace("Специи", "\nСпеції:\n");
            return product;
        }

        public string GetFruitsAndVegetables()
        {
            var product = _productPage.GetProductPageText(MainParameter.FruitsAndVegetables);
            product = product.Replace("Грибы", "Гриби:\n");
            product = product.Replace("Зелень", "\nЗелень:\n");
            product = product.Replace("Овощи", "\nОвочі:\n");
            product = product.Replace("Фрукты", "\nФрукти:\n");
            return product;
        }

        public string GetBakeryProducts()
        {
            var product = _productPage.GetProductPageText(MainParameter.BakeryProducts);
            product = product.Replace("Лаваш\n", "Лаваш:\n");
            product = product.Replace("Хлеб", "\nХліб:\n");
            return product;
        }

        public string GetEggs()
        {
            var product = _productPage.GetProductPageText(MainParameter.Eggs);
            product = product.Replace("Яйца", "Яйця:\n");
            return product;
        }
    }
}