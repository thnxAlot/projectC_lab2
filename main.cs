using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace second
{
    class main
    {
        /// <summary>
        /// проверяется наличие товаров с истекшим сроком
        /// </summary>
        /// <param name="prods">товары</param>
        /// <param name="outProds">истекшие товары</param>
        static void checkForOutProducts(Goods[] prods, out List<Goods> outProds)
        {
            outProds = new List<Goods>();
            for(int i=0;i<prods.Length;i++)
            {
                if (!prods[i].checkValid())
                    outProds.Add(prods[i]);
            }
        }

        static void Main()
        {
            TextWriterTraceListener trac = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(trac);

            FileInfo file = new FileInfo("input.txt");
            bool isFileExists = false;
            if(file.Exists)
            {
                isFileExists = true;
                Trace.WriteLine("файл input.txt отстутствует");
            }
                
            if (!isFileExists)
            {
                StreamWriter tmp = new StreamWriter("input.txt");
                tmp.Close();
                Trace.WriteLine("файл input.txt был создан");
            }
                

            StreamReader reader = new StreamReader("input.txt");

            uint n=0;
            if(!uint.TryParse(reader.ReadLine(),out n))
            {
                //Console.WriteLine("no values!");
                Trace.WriteLine("no values in input");
                Console.ReadKey();
                return;
            }
            
            Goods[] prods = new Goods[n];


           
            try
            {
                for (int i = 0; i < prods.Length; i++)
                {
                    string info = reader.ReadLine();
                    string[] measures = info.Split(',');
                    if (measures.Length == 6)
                    {
                        prods[i] = new Product(measures[0],
                        float.Parse(measures[1]),
                        new DateTime(int.Parse(measures[4]), int.Parse(measures[3]), int.Parse(measures[2])),
                        uint.Parse(measures[5]));

                        

                    }
                    else if (measures.Length == 7)
                    {
                        prods[i] = new Consignment(measures[0],
                        float.Parse(measures[1]),
                        new DateTime(int.Parse(measures[4]), int.Parse(measures[3]), int.Parse(measures[2])),
                        uint.Parse(measures[5]),
                        uint.Parse(measures[6]));
                    }
                    else
                    {
                        string[] razbSl = measures[2].Split('|');
                        Product[] temp = new Product[razbSl.Length];
                        for (int e = 0; e < temp.Length; e++)
                        {
                            string[] tmp2 = razbSl[e].Split('~');
                            temp[e] = new Product(tmp2[0],
                        float.Parse(tmp2[1]),
                        new DateTime(int.Parse(tmp2[4]), int.Parse(tmp2[3]), int.Parse(tmp2[2])),
                        uint.Parse(tmp2[5]));
                        }
                        prods[i] = new Set(measures[0], float.Parse(measures[1]), temp);
                    }

                    


                    prods[i].printInfo();

                    Console.WriteLine();
                }

                XmlSerializer formatter = new XmlSerializer(typeof(Goods[]));

                using (FileStream fs = new FileStream("Goods.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, prods);

                    Trace.WriteLine("Объект сериализован");
                    //Console.WriteLine("Объект сериализован");
                }


                reader.Close();

                List<Goods> outProds = new List<Goods>();
                checkForOutProducts(prods, out outProds);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("out products:");
                for (int i = 0; i < outProds.Count; i++)
                {
                    outProds[i].printInfo();
                    Console.WriteLine();
                }
            }
            catch
            {
                Trace.WriteLine("ошибка при чтении данных");
                Trace.WriteLine("Информация должна быть представлена в следующем виде:");
                Trace.WriteLine("red_pepper,75,01,11,2019,50\npotato,1000,10,02,2020,20,50\nligth_set,500,carrot~110~16~02~2020~5|potato~50~11~02~2020~20|garlic~65~10~01~2020~120|red_pepper~75~01~11~2019~50");

                //Console.WriteLine("ошибка при чтении данных");
                //Console.WriteLine("Информация должна быть представлена в следующем виде:");
                //Console.WriteLine("red_pepper,75,01,11,2019,50\npotato,1000,10,02,2020,20,50\nligth_set,500,carrot~110~16~02~2020~5|potato~50~11~02~2020~20|garlic~65~10~01~2020~120|red_pepper~75~01~11~2019~50");
            }


            

            Console.ReadKey();
        }

    }
}
