using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarTipoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            gvResultado.DataSource = negTipoUsuario.NEGTablaTodosLosTiposUsuario();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            gvResultado.DataSource = negTipoUsuario.NEGTablaTiposUsuarioFiltrados(campo, filtro);
            gvResultado.DataBind();

            SetFocus(gvResultado);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ConsultaDatos.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvResultado.AllowPaging = false;
                gvResultado.DataBind();

                gvResultado.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}