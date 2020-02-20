using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second
{
    /// <summary>
    /// класс комплекта, наследуемый от общего класса о товарах
    /// </summary>
    class Consignment : Goods
    {
        /// <summary>
        /// дата производства
        /// </summary>
        DateTime startDate;
        /// <summary>
        /// количество продуктов
        /// </summary>
        uint ammount;
        /// <summary>
        /// срок годности в днях
        /// </summary>
        uint srok;

        /// <summary>
        /// выводится информация о комплекте
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine("name : " + name);
            Console.WriteLine("price : " + price);
            Console.WriteLine("start date : {0}.{1}.{2}", startDate.Day, startDate.Month, startDate.Year);
            Console.WriteLine("srok : {0} days", srok);
            Console.WriteLine("ammount : {0}", ammount);
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
        public Consignment() { }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        public Consignment(string name,
            float price,
            DateTime startDate,
            uint srok,
            uint ammount)
        {
            this.name = name;
            this.price = price;
            this.startDate = startDate;
            this.ammount = ammount;
            this.srok = srok;
        }

        /// <summary>
        /// конструктор копирования
        /// </summary>
        /// <param name="other">копируемый продукт</param>
        public Consignment(Consignment other)
        {
            name = other.name;
            price = other.price;
            startDate = other.startDate;
            ammount = other.ammount;
            srok = other.srok;
        }
    }
}
