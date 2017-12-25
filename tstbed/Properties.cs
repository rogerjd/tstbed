using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //auto and manual
    class Properties
    {
        private string backingFld;

        //auto
        public string MyAutoProperty { get; set; }

        //manual (cant use part auto, part manl)
        public string MyManualProperty
        {
            get { return backingFld; }
            set { backingFld = value; }
        }

    }
}
