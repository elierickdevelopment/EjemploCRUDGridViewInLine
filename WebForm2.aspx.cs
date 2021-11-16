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

                }
            }
        }

        DropDownList ddlCiudadGlobal = new DropDownList();
        DropDownList ddlComunaGloobal = new DropDownList();

        protected void DropDownList_Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SOLO FALTA BUSCAR EL ROW INDEX seleccionado en el grid : 3
            string index = "3";// Session["rowIndex"].ToString();
            DropDownList ddl = (DropDownList)GridView1.Rows[int.Parse(index)].FindControl("DropDownList_Comuna");
            string idCiudad = HiddenField_idCiudad.Value;
            DataSet ds = new DataSet();
            llenarDdlComuna(ref ds, idCiudad);
            ddl.DataSource = ds.Tables[0].DefaultView;
            ddl.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView GridView1 = Page.FindControl("GridView1") as GridView;
            GridViewRow row = GridView1.SelectedRow;
            Session["rowIndex"] =row.RowIndex;
        }
    }
}