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
            foreach (XElement el in doc.Root.Elements().Elements("S"))
                Console.WriteLine(el.Value);
                Console.ReadKey();
            foreach (XElement element in doc.Root.Elements().Elements("S"))
                Console.WriteLine(element.Attribute("ID"));
                Console.ReadKey();
            foreach (XElement element in doc.Root.Elements().Elements("S").Elements("W")) //<-- ясн
                Console.WriteLine(element.Attribute("LEMMA"));
                Console.ReadKey();
                                                                   
        }
    }
}
