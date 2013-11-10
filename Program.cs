using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Linq;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:/Minoru/Study/syntagrus24.09.2012/SynTagRus/2011/Alpinizm.tgt"; //имя файла размеченного хмл
            XDocument doc = XDocument.Load(fileName); //загружаем файл
            
            Console.WriteLine("Сейчас все предложения из файла выведутся в файл Sentense.txt");
            //выводим все предложения
            //sent.Value - то, что заключено в S, т.е. последовательность слов в предложении
            using (StreamWriter sw = new StreamWriter("Sentense.txt")) //штука для вывода текста построчно с перезаписью файла, если не написать using то будет черная дыра
            {
                foreach (XElement sent in doc.Root.Elements().Elements("S")) 
                //doc.Root.Elements это все наружные корневые элементы вложенные в бади(я так понял), 
                //из них мы выбираем только элементы S
                sw.WriteLine(sent.Value);   //записываем в файл            
            }
            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();


            Dictionary<string, string> sentenseID = new Dictionary<string, string>(); //Создаем объект класса Dictionary<TKey, TValue>
            foreach (XElement element in doc.Root.Elements().Elements("S"))
            {
                sentenseID.Add(element.Attribute("ID").Value, element.Value); //добавляем в словарь string ID предложения и само предложение
                //Console.WriteLine(element.Attribute("ID")); //можно вывести все айдишники в консоль если не лень.
            }
            Console.WriteLine("Словарь, содержащий ID и Value предложения создан, \n нажмите любую клавишу чтобы продолжить");
            Console.ReadKey();

            //создаем штуку для записи в файл предложений с их айдишниками (из словаря sentenseID)
            using(StreamWriter sentenses = new StreamWriter("Sentenses.txt"))
            {
                foreach (var sentense in sentenseID)
                sentenses.WriteLine(string.Format("Key = {0}; Value = {1}", sentense.Key, sentense.Value));
            }
            Console.WriteLine("Словарь был выведен в файл Sentenses.txt, нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();

            //попробуем пойти дальше и выведем атрибуты элементов элементов *фейспалм*
            Console.WriteLine("Вывод всех предков слов");
            foreach (XElement element in doc.Root.Elements().Elements("S").Elements("W")) //<-- ясн
                Console.WriteLine(element.Attribute("DOM").Value);
                Console.ReadKey();
                                                                   
        }
    }
}
