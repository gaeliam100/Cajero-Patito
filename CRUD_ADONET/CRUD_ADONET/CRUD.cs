using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADONET
{
    class CRUD
    {
        //atributos
        SqlConnection consql = ConBD.conexion1();
        SqlCommand cmdsql;
        SqlDataReader reader;
        SqlDataAdapter datasql;
        //constructores
        public CRUD() { }

        //metodos:
        public int create(Alumno nvoalumno)
        {
            int agregado = 0;
            using (consql = ConBD.conexion1())
            {
                consql.Open();
                cmdsql = new SqlCommand(string.Format("EXECUTE SP_CREARALUMNO '{0}','{1}';",nvoalumno.Boleta,nvoalumno.Nombre),consql);
                agregado = cmdsql.ExecuteNonQuery();
                consql.Close();
            }
            return agregado;
        }
        public DataTable Read()
        {
            DataTable tablaalumnos = new DataTable();
            using (consql)
            {
                consql.Open();
                string query = " Execute SP_leer;";
                datasql = new SqlDataAdapter(query, consql);
                datasql.Fill(tablaalumnos);
                consql.Close();
            }
            return tablaalumnos;
        }
        public List<Alumno> readalumnos(int boleta)
        {
            List<Alumno> encontrados = new List<Alumno>();
            using (consql)
            {
                consql.Open();
                cmdsql = new SqlCommand(string.Format("EXECUTE SP_BUSCARR'{0}';",boleta),consql);
                reader = cmdsql.ExecuteReader();
                while (reader.Read())
                {
                    Alumno almnoencontrado = new Alumno();
                    almnoencontrado.Boleta = Convert.ToInt32(reader[0]);
                    almnoencontrado.Nombre = reader[1].ToString();
                    encontrados.Add(almnoencontrado);
                }
                consql.Close();
            }
            return encontrados;
        }
        public Alumno alumnos(int boleta)
        {
            Alumno alumnoencontrado = new Alumno();
            using (consql)
            {
                consql.Open();
                cmdsql = new SqlCommand(string.Format("EXECUTE SP_BUSCARR'{0}';", boleta), consql);
                reader = cmdsql.ExecuteReader();
                while (reader.Read())
                {
                    alumnoencontrado.Boleta = Convert.ToInt32(reader[0]);
                    alumnoencontrado.Nombre = reader[1].ToString();   
                }
                consql.Close();
            }
            return alumnoencontrado;

        }
        public int update(Alumno alum, string nbol, string nnom)
        {
            int modificado = 0;
            int llave = alum.Boleta;
            alum.Boleta = int.Parse(nbol);
            alum.Nombre = nnom;
            using (consql)
            {
                consql.Open();
                cmdsql = new SqlCommand(string.Format(" EXECUTE SP_ACTUALIZARR  '{0}','{1}','{2}' ;", alum.Boleta, alum.Nombre, llave),consql);
                modificado = cmdsql.ExecuteNonQuery();
                consql.Close();
            }
            return modificado;
        }
        public int delete(int bol)
        {
            int eliminado = 0;
            using (consql)
            {
                consql.Open();
                cmdsql = new SqlCommand(string.Format(" EXECUTE SP_ELIMINAR'{0}';", bol), consql);
                eliminado = cmdsql.ExecuteNonQuery();
            }
            return eliminado;
        }
    }
}
