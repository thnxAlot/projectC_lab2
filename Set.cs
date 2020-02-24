using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace second
{
    /// <summary>
    /// класс набора, наследуемый от общего класса о товарах
    /// </summary>
    /// 
    [Serializable]
    public class Set : Goods
    {
        /// <summary>
        /// набор продуктов
        /// </summary>
        public Product[] products;

        /// <summary>
        /// выводится информация о наборе
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine("name : " + name);
            Console.WriteLine("price : " + price);
            Console.WriteLine("products:");
            for(int i=0;i<products.Length;i++)
            {
                products[i].printInfo();
                Console.WriteLine();
            }
            Trace.WriteLine("сет напечатан");
        }

        /// <summary>
        /// проверка на срок годности
        /// </summary>
        /// <returns>возвращается true, если срок не нарушен</returns>
        public override bool checkValid()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (!products[i].checkValid())
                    return false;
            }
            
            return true;

        }

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Set() { }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        public Set(string name,
            float price,
            Product[] products)
        {
            this.name = name;
            this.price = price;
            this.products = new Product[products.Length];
            for(int i=0;i<products.Length;i++)
            {
                this.products[i] = new Product(products[i]);
            }
        }

        /// <summary>
        /// конструктор копирования
        /// </summary>
        /// <param name="other">копируемый продукт</param>
        public Set(Set other)
        {
            name = other.name;
            price = other.price;
            products = new Product[other.products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = new Product(other.products[i]);
            }
        }


    }
}
