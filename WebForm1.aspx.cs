using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploCRUDGridViewInLine
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            e.Cancel = true;

            int IdRow = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            TextBox txtDescripcion = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            DropDownList ddlRegion = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList_region");
            string IdRegion = ddlRegion.SelectedValue;

            //CON SQLDATASOURCE:
            //SqlDataSource1.UpdateCommand = "UPDATE [dbo].[Pais] SET Descripcion = '" + txtDescripcion.Text.Trim() + "' , IdRegion= " + IdRegion + " WHERE id = " + IdRow;

            //CON SP:
            DataSet ds = new DataSet();
            var parametros = new SqlParameter[] {
                        new SqlParameter("@IdPais", IdRow.ToString()),
                        new SqlParameter("@IdRegion", IdRegion.ToString()),
                        new SqlParameter("@Descripcion", txtDescripcion.Text.Trim()),
                    };

            General.EjecutarQuery("dbo.Sp_UpdatePais", parametros, ref ds);
            if (ds.Tables.Count > 0)
            {
                string exito = ds.Tables[0].Rows[0]["exito"].ToString();
                string mensajeSql = ds.Tables[0].Rows[0]["mensaje"].ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('" + mensajeSql + "');", true);
            }

            GridView1.EditIndex = -1;
            GridView1.DataBind();
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdRow = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

            SqlDataSource1.DeleteCommand = "DELETE FROM [dbo].[Pais] WHERE id =" + IdRow;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            int rowIndex = Convert.ToInt32(e.CommandArgument);
    

            if (e.CommandName == "New")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Crear nuevo registro');", true);
            }
            if (e.CommandName == "Edit") {

                
                string idregion = GridView1.Rows[rowIndex].Cells[1].Text;

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlregion = (DropDownList)e.Row.FindControl("DropDownList_region");
                    
                    //establecemos el id de la región correspondiente en el row que estamos editando:
                    ddlregion.SelectedValue = GridView1.DataKeys[e.Row.RowIndex].Values["IdRegion"].ToString();
                }
            }
        }


        

    }
}