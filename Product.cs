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
    /// класс продукта, наследуемый от общего класса о товарах
    /// </summary>
    [Serializable]
    public class Product : Goods
    {

        /// <summary>
        /// дата производства
        /// </summary>
        public DateTime startDate;
        /// <summary>
        /// срок годности в днях
        /// </summary>
        public uint srok;

        /// <summary>
        /// выводится информация о продукте
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine("name : " + name);
            Console.WriteLine("price : " + price);
            Console.WriteLine("start date : {0}.{1}.{2}", startDate.Day,startDate.Month,startDate.Year);
            Console.WriteLine("srok : {0} days",srok);

            Trace.WriteLine("продукт напечатан");
        }

        /// <summary>
        /// проверка на срок годности
        /// </summary>
        /// <returns>возвращается true, если срок не нарушен</returns>
        public override bool checkValid()
        {
            
            if (startDate.AddDays(srok) <= DateTime.Today)
                return false;
            return true;

            
        }

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Product() { }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        public Product(string name,
            float price,
            DateTime startDate,
            uint srok)
        {
            this.name = name;
            this.price = price;
            this.startDate = startDate;
            this.srok = srok;
        }

        /// <summary>
        /// конструктор копирования
        /// </summary>
        /// <param name="other">копируемый продукт</param>
        public Product(Product other)
        {
            name = other.name;
            price = other.price;
            startDate = other.startDate;
            srok = other.srok;
        }

    }
}
