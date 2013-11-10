using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class word
    {
		public int dom;
		public string feat;
		public int id;
		public string lemma;
		public string link;

        public word(int _dom, string _feat, int _id, string _lemma, string _link)
        {
                this.dom = _dom;
                this.feat = _feat;
                this.id = _id;
                this.lemma = _lemma;
                this.link = _link;
        }
    }
}
