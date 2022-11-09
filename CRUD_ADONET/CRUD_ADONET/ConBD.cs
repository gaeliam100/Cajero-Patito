using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregar librerias
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CRUD_ADONET
{
    class ConBD
    {
        //atributos:
        //constructores
        public ConBD()
        { }
        //métodos:
        public static SqlConnection conexion1()
        {
            string cadenacon = @"Data Source=DESKTOP-PNAGB4Q\SQLEXPRESS01;Initial Catalog=Alumnoss;Integrated Security=True";
            SqlConnection nvaconexion = new SqlConnection(cadenacon);
            return nvaconexion;
        }
        public static SqlConnection conexion2()
        {
            string cadenacon = ConfigurationManager.ConnectionStrings["alias"].ConnectionString;
            SqlConnection nvaconexion = new SqlConnection(cadenacon);
            return nvaconexion;
        }
    }
}
