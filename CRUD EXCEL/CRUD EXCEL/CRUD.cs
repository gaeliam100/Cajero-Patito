using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;


namespace CRUD_EXCEL
{
    class CRUD
    {
        //ATRIBUTOS
        //ARCHIVOS .XLS
        //LA CADENA DE CONEXIÓN SE COMPONE ---> TECNOLOGÍA; ORIGEN DE DATOS; PARÁMETROS GENERALES
        //SE PONE UN "@" PARA PODER USAR LAS DIAGONALES
        private string cadenaConexionXls = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\gaeli\source\repos\CRUD EXCEL\CRUD EXCEL\Alumnos.xlsx;Extended Properties='Excel 8.0'";
       // private string cadenaConexionXlsx = @"Provider=Microsoft.ACE.OLEDB.12.0;Source=C:\Users\gaeli\Downloads\CRUD EXCEL (1)\CRUD EXCEL\CRUD EXCEL\Alumnos.xlsx;Extended Properties='Excel 12.0'";
        OleDbConnection conexionExcel;
        public CRUD() { }
        //MEDOTOS
        //DATA TABLE SIRVE PARA GENERAR UNA MATRIZ (CON FILAS Y COLUMNAS) DONDE SE VACIARA LA INFORMACIÓN QUE TRAGIAMOS DE ALGÚN LADO
        //EL DATA TABLE ES UN PUENTE
        public DataTable consultarAlumnos()
        {
            DataTable alumnosRegistrados = new DataTable();
            alumnosRegistrados.Columns.Add("BOLETA");
            alumnosRegistrados.Columns.Add("ALUMNO");
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            { //AQUÍ SE REALIZA LA OPERACIÓN DE EXTRACCIÓN DE DATOS
                conexionExcel.Open();
                String query = "SELECT * FROM [Hoja1$]";
                OleDbCommand comando = new OleDbCommand(query, conexionExcel);
                OleDbDataAdapter copiaDatos = new OleDbDataAdapter(comando);
                copiaDatos.Fill(alumnosRegistrados);
                conexionExcel.Close();
            }
            return alumnosRegistrados;
        }
        public DataTable consultarAlumnos2()
        {
            DataTable alumnosRegistrados = new DataTable();
            alumnosRegistrados.Columns.Add("BOLETA");
            alumnosRegistrados.Columns.Add("ALUMNO");
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            { //AQUÍ SE REALIZA LA OPERACIÓN DE EXTRACCIÓN DE DATOS
                conexionExcel.Open();
                String query = "SELECT * FROM [Hoja1$]";
                OleDbCommand comando = new OleDbCommand(query, conexionExcel);
                OleDbDataAdapter copiaDatos = new OleDbDataAdapter(comando);
                copiaDatos.Fill(alumnosRegistrados);
                conexionExcel.Close();
            }
            return alumnosRegistrados;
        }
        public void agregaralumno(string bol, string nom)
        {
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            {
                conexionExcel.Open();
                string query = "INSERT INTO [Hoja1$] (BOLETA,ALUMNO) values(@boleta,@alumno)";
                OleDbCommand cmdagrgar = new OleDbCommand(query, conexionExcel);
                cmdagrgar.Parameters.AddWithValue("@boleta", bol);
                cmdagrgar.Parameters.AddWithValue("@alumno", nom);
                //se ejecuta query
                //execute es como un return
                cmdagrgar.ExecuteNonQuery();
                conexionExcel.Close();
            }
        }
        //public void buscaralumnos(string boleta)
        //{
        //    using (conexionExcel = new OleDbConnection(cadenaConexionXls))
        //    { //AQUÍ SE REALIZA LA OPERACIÓN DE EXTRACCIÓN DE DATOS
        //        conexionExcel.Open();
        //        string query = "SELECT * FROM [Hoja1$] WHERE BOLETA  ='@boleta';";
        //        OleDbCommand cmdbuscar = new OleDbCommand(query, conexionExcel);
        //        cmdbuscar.Parameters.AddWithValue(boleta,"@boleta");
        //        cmdbuscar.ExecuteReader();
        //        conexionExcel.Close();
        //    }

        //}
        public DataTable buscaralumno(string boleta)
        {
            DataTable alumnos = new DataTable();
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            { //AQUÍ SE REALIZA LA OPERACIÓN DE EXTRACCIÓN DE DATOS
                conexionExcel.Open();
                string query = "SELECT * FROM [Hoja1$] WHERE BOLETA =" + boleta;
                OleDbCommand cmdbuscar = new OleDbCommand(query, conexionExcel);
                OleDbDataAdapter copiadatos2 = new OleDbDataAdapter(cmdbuscar);
                copiadatos2.Fill(alumnos);
                conexionExcel.Close();
            }
            return alumnos;
        }
        public void eliminaralumno(string bol2, string nom)
        {
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            {
                conexionExcel.Open();
                string query = "DELETE*FROM [Hoja1$] WHERE BOLETA=" + bol2 + "AND ALUMNO='" + nom + "'";
                OleDbCommand cmdborrar = new OleDbCommand(query, conexionExcel);
                //cmdborrar.Parameters.AddWithValue("@boleta",bol2);
                cmdborrar.ExecuteNonQuery();
                conexionExcel.Close();
            }

        }
        public void modificaralumno(string bol3, string nom1)
        {
            using (conexionExcel = new OleDbConnection(cadenaConexionXls))
            {
                conexionExcel.Open();
                string query = "update [Hoja1$] set ALUMNO= @nombre where BOLETA =" + bol3;
                OleDbCommand cmdagrgarnuevo = new OleDbCommand(query, conexionExcel);
                cmdagrgarnuevo.Parameters.AddWithValue("@nombre", nom1);
                //se ejecuta query
                //execute es como un return
                cmdagrgarnuevo.ExecuteNonQuery();
                conexionExcel.Close();
            }

        }
    }
}
