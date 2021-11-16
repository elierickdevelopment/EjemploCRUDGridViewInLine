using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploCRUDGridViewInLine
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataSet llenarDdlComuna(ref DataSet ds, string idCiudad) {

            General FG = new General();
            string query = "SELECT co.Id as IdComuna, co.Descripcion FROM Comuna co, Ciudad ci where co.IdCiudad = ci.Id AND co.IdCiudad =" + idCiudad;
            if (FG.ObtenerDatos(query, ref ds))
            {

            }

            return ds;

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlNew = new DropDownList();
                    DropDownList ddlCiudad = (DropDownList)e.Row.FindControl("DropDownList_Ciudad");
                    ddlCiudadGlobal = ddlCiudad;
                    DropDownList ddlComuna = (DropDownList)e.Row.FindControl("DropDownList_Comuna");
                    DataSet ds = new DataSet();
                    string idCiudad = ddlCiudad.SelectedValue;
                    llenarDdlComuna(ref ds, idCiudad);
                    ddlComuna.DataSource = ds.Tables[0].DefaultView;
                    ddlComuna.DataBind();
                    //int cont = ddlComuna.Items.Count;
                    //ddlComuna.SelectedValue = GridView1.DataKeys[e.Row.RowIndex].Values["IdRegion"].ToString();



                }
            }
        }

        DropDownList ddlCiudadGlobal = new DropDownList();
        DropDownList ddlComunaGloobal = new DropDownList();

        protected void DropDownList_Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llenarDdlComuna(ddlGeneral);
            //int cant = ddlGeneral.Items.Count;
            string idCiudad = HiddenField_idCiudad.Value;
            //string idCiudad = ddlCiudadGlobal.SelectedValue;
            DataSet ds = new DataSet();
            llenarDdlComuna(ref ds, idCiudad);
            ddlComunaGloobal.DataSource = ds.Tables[0].DefaultView;
            ddlComunaGloobal.DataBind();

        }
    }
}