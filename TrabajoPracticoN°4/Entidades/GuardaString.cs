using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto,string archivo){

            bool retorno = true;
            StreamWriter guardar=null;
            try
            {
                string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//devuelve la ruta del escritorio
                StringBuilder path = new StringBuilder();
                path.Append(pathEscritorio);
                path.AppendFormat("\\{0}", archivo);
                guardar = new StreamWriter(path.ToString(), true);
                guardar.WriteLine(texto); ;
                guardar.Close();
            }
            finally
            {
                retorno = false;
                if (guardar != null)
                {
                    guardar.Close();
                }
            }

            return retorno;
        }

    }

}
