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

        public parser(string fileName)
        {
            parse(fileName);
        }

        public void parse(string fileName)
        {
            XDocument doc =  XDocument.Load(fileName);
            sentenceMap = new Dictionary<int, sentence>();

            foreach (XElement sentence in doc.Root.Elements().Elements(XML_NODE_SENTENCE))
            {
                Dictionary<int, word> wordsMap = new Dictionary<int, word>();

                foreach (XElement _word in sentence.Elements(XML_NODE_WORD))
                {
                    int dom = 0;
                    if (Convert.ToString((string) _word.Attribute(WORD_ATTR_DOM).Value) != XML_ROOT_NODE) 
                        dom = Convert.ToInt32((string) _word.Attribute(WORD_ATTR_DOM).Value);

                    word w = new word(dom,
                            (string)_word.Attribute(WORD_ATTR_FEAT),
                            Convert.ToInt32((string)_word.Attribute(WORD_ATTR_ID)),
                            (string)_word.Attribute(WORD_ATTR_LEMMA),
                            (string)_word.Attribute(WORD_ATTR_LINK));

                    wordsMap.Add(w.id, w);
                }

                sentence s = new sentence(Convert.ToInt32((string) sentence.Attribute(SENTENCE_ATTR_ID).Value),
                        sentence.Value,
                        wordsMap);

                sentenceMap.Add(s.id, s);
            }
        }
         //foreach(KeyValuePair<int, word> kvpWord in kvpSentence.Value)
        public void getStats()
        {
            foreach (KeyValuePair<int, sentence> kvpSentence in sentenceMap)
            {
                foreach (KeyValuePair<int, word> kvpWord in kvpSentence.Value.wordsMap)
                {
                    string bigram; //словосочетание
                    if (kvpWord.Value.dom == 0) continue;
                    word parent = kvpSentence.Value.wordsMap[kvpWord.Value.dom];

                    string delimiter = ">";
                    if (kvpWord.Value.id < parent.id) delimiter = "<";

                    bigram = kvpWord.Value.featValues[0] + delimiter + parent.featValues[0];

                    //здесь мы в главный словарь закидываем полученное словосочетание

                    //kvpSentence.Value.wordsMap.TryGetValue(kvpSentence.Value.wordsMap.TryGetValue(w.dom, out w.dom), out w.id));
                    if (main.stats.ContainsKey(bigram))
                        main.stats[bigram]++;
                    else main.stats.Add(bigram, 1);
                }
            }
        }
    }
}
