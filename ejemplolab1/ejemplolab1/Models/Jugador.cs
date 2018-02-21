using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplolab1.Models
{
    public class Jugador
    {
        public int jugadorid{get;set;}
        public string nombre { get; set; }
        public string apellido { get; set; }
        public double salario { get; set; }
        public string posiscion { get; set; }
        public string club { get; set; }
    }
}