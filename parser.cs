using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ConsoleApplication1;



namespace ConsoleApplication1
{
    class parser
    {
        private Dictionary<int, sentence> sentenceMap;
        public void parse(string fileName)
        {
            XDocument doc =  XDocument.Load(fileName);

            Dictionary<int, sentence> sentencesMap = new Dictionary<int, sentence>();
    
            foreach (XElement sent in doc.Root.Elements().Elements("S"))
            {
            Dictionary<int, word> wordsMap = new Dictionary<int, word>();
                foreach (XElement element in sent.Elements("W"))
                      {

                          if (Convert.ToString((string)element.Attribute("DOM").Value) == "_root") 
                          {
                              int dom = 0;
                              word w = new word(dom,
                              (string)element.Attribute("FEAT").Value,
                              Convert.ToInt32((string)element.Attribute("ID").Value),
                              (string)element.Attribute("LEMMA").Value,
                              (string)element.Attribute("LINK").Value);
                              wordsMap.Add(w.id, w);
                          }
                          else
                          {
                              word w = new word(Convert.ToInt32((string)element.Attribute("DOM").Value),
                                                (string)element.Attribute("FEAT").Value,
                                                Convert.ToInt32((string)element.Attribute("ID").Value),
                                                (string)element.Attribute("LEMMA").Value,
                                                (string)element.Attribute("LINK").Value);
                              wordsMap.Add(w.id, w);
                          }
                      }
            sentence s = new sentence(Convert.ToInt32((string)sent.Attribute("ID").Value),
                                      sent.Value,
                                      wordsMap);
            sentencesMap.Add(s.id, s);
    }
    


        }

    }
}
