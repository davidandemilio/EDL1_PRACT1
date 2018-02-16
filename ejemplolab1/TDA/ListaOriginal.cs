using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDA
{
    public class ListaOriginal<T>
    {
        List<T> lista=new List<T>();

        public void Insertar(T elemento)
        {

            lista.Add(elemento);
        }
        public List<T> obtenerListado()
        {

            return lista;

        }
    }
}
