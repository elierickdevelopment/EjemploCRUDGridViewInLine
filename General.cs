using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EjemploCRUDGridViewInLine
{
  
    public class General
    {
        private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static void EjecutarQuery(string ProcedureName, SqlParameter[] Parameters, ref DataSet ds)
        {
            string Sentecia = string.Empty;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand Commad = new SqlCommand(ProcedureName, con);

                    Commad.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter par in Parameters)
                    {
                        if (par.Value == null)
                        {
                            par.Value = DBNull.Value;
                        }
                        Commad.Parameters.Add(par);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(Commad);
                    Sentecia = da.SelectCommand.CommandText;
                    da.SelectCommand.CommandTimeout = 0;
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public bool ObtenerDatos(string consulta, ref DataSet ds)
        {
            bool ok = false;
            using (SqlConnection conX = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlDataAdapter daConsulta = new SqlDataAdapter(consulta, conX);
                    ds = new DataSet();
                    daConsulta.Fill(ds, "0");
                    if (ds.Tables["0"].Rows.Count > 0)
                        ok = true;
                    else
                        ok = false;
                }
                catch (SqlException ex)
                {
                    ok = false;
                }
            }
            return ok;
        }


    }

}