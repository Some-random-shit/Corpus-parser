using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class word
    {
        public word(int _dom, string _feat, int _id, string _lemma, string _link)
        {
                int dom = _dom;
                string feat = _feat;
                int id = _id;
                string lemma = _lemma;
                string link = _link;
        }

        public int dom;
        public string feat;
        public int id;
        public string lemma;
        public string link;
    }
}
