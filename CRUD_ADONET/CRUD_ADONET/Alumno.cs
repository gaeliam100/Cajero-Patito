using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONET
{
    class Alumno
    {
        int boleta = 0;
        string nombre = string.Empty;
        //propiedades
        public int Boleta { get => boleta; set => boleta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Alumno()
        {

        }
        public Alumno(string bol,string nom)
        {
            this.Boleta = int.Parse(bol);
            this.Nombre = nom;
        }
    }
}
