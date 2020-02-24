using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace second
{
    /// <summary>
    /// абстрактный класс для хранения общих полей и методов
    /// </summary>
    [XmlInclude(typeof(Product))]
    [XmlInclude(typeof(Consignment))]
    [XmlInclude(typeof(Set))]
    [Serializable]
    public abstract class Goods
    {
        /// <summary>
        /// имя товара
        /// </summary>
        public string name;
        /// <summary>
        /// цена товара
        /// </summary>
        public float price;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Goods() { }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Goods(string name, float price)
        {
            this.name = name;
            this.price = price;
        }

        /// <summary>
        /// функция, выводящая на экран всю информацию о товаре
        /// </summary>
        public abstract void printInfo() 
             ;

        /// <summary>
        /// функция, проверяющая срок годности товара
        /// </summary>
        /// <returns>возвращает true, если срок годности не нарушен</returns>
        public abstract bool checkValid();
        
    }
}
