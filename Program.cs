using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:/Minoru/Study/syntagrus24.09.2012/SynTagRus/2011/Alpinizm.tgt";
            XDocument doc = XDocument.Load(fileName);
            //выводим все предложения, el.value для элементов S будет последовательность всех элементов имен внутри предложения
            foreach (XElement el in doc.Root.Elements().Elements("S")) //doc.Root.Elements это все наружные корневые элементы вложенные в бади(я так понял)
                Console.WriteLine(el.Value);
                Console.ReadKey();
            //попробуем вывести атрибуты, выведем хотя бы айди предложений
            foreach (XElement element in doc.Root.Elements().Elements("S"))
                Console.WriteLine(element.Attribute("ID"));
                Console.ReadKey();
            //попробуем пойти дальше и выведем атрибуты элементов элементов *фейспалм*
            foreach (XElement element in doc.Root.Elements().Elements("S").Elements("W")) //<-- ясн
                Console.WriteLine(element.Attribute("LEMMA"));
                Console.ReadKey();
                                                                   
        }
    }
}
