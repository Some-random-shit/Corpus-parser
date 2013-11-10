using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class sentence
    {
        public sentence(int _id, string _value, Dictionary<int, word> _wordsMap)
        {
            this.id = _id;
            this.value = _value;
            this.wordsMap = _wordsMap;
        }

        public int id;
        public string value;
        public  Dictionary<int, word> wordsMap;

    }
}
