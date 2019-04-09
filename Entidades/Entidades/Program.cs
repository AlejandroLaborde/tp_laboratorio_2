using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    class Program
    {
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MiCalculadora.LaCalculadora());
            
            //Console.ReadKey();
        }
    }
}
