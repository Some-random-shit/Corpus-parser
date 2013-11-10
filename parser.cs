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

        private static String XML_NODE_WORD = "W";
        private static String XML_NODE_SENTENCE = "S";
        private static String XML_ROOT_NODE = "_root";

        private static String SENTENCE_ATTR_ID = "ID";

        private static String WORD_ATTR_DOM = "DOM";
        private static String WORD_ATTR_FEAT = "FEAT";
        private static String WORD_ATTR_ID = "ID";
        private static String WORD_ATTR_LEMMA = "LEMMA";
        private static String WORD_ATTR_LINK = "LINK";

        public void parse(string fileName)
        {
            XDocument doc =  XDocument.Load(fileName);
            sentenceMap = new Dictionary<int, sentence>();

            foreach (XElement sentence in doc.Root.Elements().Elements(XML_NODE_SENTENCE))
            {
                Dictionary<int, word> wordsMap = new Dictionary<int, word>();

                foreach (XElement word in sentence.Elements(XML_NODE_WORD))
                {
                    int dom = 0;
                    if (Convert.ToString((string) word.Attribute(WORD_ATTR_DOM).Value) != XML_ROOT_NODE) 
                        dom = Convert.ToInt32((string) element.Attribute(WORD_ATTR_DOM).Value);

                    word w = new word(dom,
                            (string) word.Attribute(WORD_ATTR_FEAT).Value,
                            Convert.ToInt32((string) word.Attribute(WORD_ATTR_ID).Value),
                            (string) word.Attribute(WORD_ATTR_LEMMA).Value,
                            (string) word.Attribute(WORD_ATTR_LINK).Value);

                    wordsMap.Add(w.id, w);
                }

                sentence s = new sentence(Convert.ToInt32((string) sentence.Attribute(SENTENCE_ATTR_ID).Value),
                        sentence.Value,
                        wordsMap);

                sentenceMap.Add(s.id, s);
            }
        }
    }
}
