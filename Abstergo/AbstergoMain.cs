using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo
{
    class AbstergoMain
    {
        static void Main(string[] args)
        {
            
        }

        static void CallMethod(string number) {

            switch(number){
                case "1":
                    Bitly.BitlyFromWebRequest();
                    break;
                case "2":
                    Bitly.BitylFromApi();
                    break;
            }
        }
    }
}
