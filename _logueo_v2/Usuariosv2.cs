using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _logueo_v2
{
    class Usuariosv2
    {
        //ATRIBUTOS:
        static List<string> nombre = new List<string>();
        static List<string> user = new List<string>();
        static List<string> pass = new List<string>();

        public  List<string> Nombre { get => nombre; set => nombre = value; }
        public  List<string> User { get => user; set => user = value; }
        public  List<string> Pass { get => pass; set => pass = value; }
        //public static string User { get => user; set => user = value; }

        //constructores
        public Usuariosv2()
        {

        }
        //Metodos;
        public void obtenernombres(string nom)
        {
            Nombre.Add(nom);
        }

        public bool obtenerusuarios(string usus)
        {
            if (User.Contains(usus))
            {
                return false;
            }
            else
            {
                User.Add(usus);
                return true;
            }
        }
        public void obtenercontraseña(string contra)
        {
            Pass.Add(contra);
        }
        public bool validausuario(string u, string p)
        {
            if (User.Contains(u) && Pass.Contains(p))
                return true;
            else
                return false;
        }

        public List<string> mostrar()
        {
            return User;
        }

    }
}

