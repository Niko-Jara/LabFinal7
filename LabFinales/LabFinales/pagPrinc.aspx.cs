using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaDatos;

namespace LabFinales
{
    public partial class pagPrinc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (!this.IsPostBack)
                {
                    cargarcmbPaises();
                    cargarcmbIdioma();
                    cargarGrid();
                }
            }
            void cargarcmbPaises()
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    cmbpais.DataSource = contextoBD.Pais.ToList();
                    cmbpais.DataTextField = "DescPais";
                    cmbpais.DataValueField = "idPais";
                    cmbpais.DataBind();
                }
            }

            void cargarcmbIdioma()
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    cmbIdioma.DataSource = contextoBD.Idioma.ToList();
                    cmbIdioma.DataTextField = "DescIdioma";
                    cmbIdioma.DataValueField = "idIdioma";
                    cmbIdioma.DataBind();
                }
            }

            public void cargarGrid()
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    var data = (from gt in contextoBD.GestionPrestamoes
                                join p in contextoBD.Pais on gt.idPais equals p.idPais
                                join i in contextoBD.Idioma on gt.idIdioma equals i.IdIdioma

                                select new
                                {
                                idPrestamo = gt.idprestamo,
                                idPais     = p.DescPais,
                                Habitantes = gt.Habitantes,
                                Idioma     = i.DescIdioma,
                                PIB        = gt.PIB,
                                Superficie = gt.Superficie,
                                Riesgo     = gt.Riesgo,
                                Prestamo   = gt.Prestamo


                                }).ToList();

                    gridPrestamos.DataSource = data;
                    gridPrestamos.DataBind();
                }
            }
            protected void gridPrestamos_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPrestamos, "Select$" + e.Row.RowIndex);
                }

            }

            protected void gridPrestamos_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (GridViewRow fila in gridPrestamos.Rows)
                {

                    if (fila.RowIndex == gridPrestamos.SelectedIndex)
                    {
                        cmbpais.Text = fila.Cells[0].Text;
                        txtHabitantes.Text = fila.Cells[1].Text;
                        cmbIdioma.Text = fila.Cells[2].Text;
                        txtPIB.Text = fila.Cells[3].Text;
                        txtSuperficie.Text = fila.Cells[4].Text;
                        Radio.SelectedItem.Text = fila.Cells[5].Text;
                        Check.Text = fila.Cells[6].Text;
                        fila.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    }
                    else
                    {
                        fila.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }
                cargarGrid();
            }

            protected void Registrar_Click(object sender, EventArgs e)
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    GestionPrestamos objPrestamo = new GestionPrestamos();
                    objPrestamo.idPais = Convert.ToInt32(cmbpais.SelectedValue);
                    objPrestamo.Habitantes = Convert.ToInt32(txtHabitantes.Text);
                    objPrestamo.idIdioma = Convert.ToInt32(cmbIdioma.SelectedValue);
                    objPrestamo.PIB = Convert.ToDecimal(txtPIB.Text);
                    objPrestamo.Superficie = Convert.ToInt32(txtSuperficie.Text);
                    objPrestamo.Prestamo = Check.Checked;
                    objPrestamo.Riesgo = Radio.SelectedItem.Text;


                    contextoBD.GestionPrestamoes.Add(objPrestamo);
                    contextoBD.SaveChanges(); //COMMIT
                    cargarGrid();
                }
            }

            protected void Modificar_Click(object sender, EventArgs e)
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    int modificar = Convert.ToInt32(cmbpais.SelectedValue);

                    GestionPrestamos aux = contextoBD.GestionPrestamoes.Where(x => x.idPais == modificar).FirstOrDefault();
                    if (aux == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('El registro no se encontro')", true);
                        return;
                    }

                    aux.idPais = Convert.ToInt32(cmbpais.SelectedValue);
                    aux.Habitantes = Convert.ToInt32(txtHabitantes.Text);
                    aux.idIdioma = Convert.ToInt32(cmbIdioma.SelectedValue);
                    aux.PIB = Convert.ToDecimal(txtPIB.Text);
                    aux.Superficie = Convert.ToInt32(txtSuperficie.Text);
                    aux.Prestamo = Check.Checked;
                    aux.Riesgo = Radio.SelectedItem.Text;


                    contextoBD.SaveChanges();
                    cargarGrid();
                }
            }

            protected void Eliminar_Click(object sender, EventArgs e)
            {
                using (ModeloFMI contextoBD = new ModeloFMI())
                {
                    int borrado = Convert.ToInt32(cmbpais.SelectedValue);

                    GestionPrestamos aux = contextoBD.GestionPrestamoes.Where(x => x.idPais == borrado).FirstOrDefault();
                    if (aux == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('El registro no se encontro')", true);
                        return;
                    }
                    contextoBD.GestionPrestamoes.Remove(aux);
                    contextoBD.SaveChanges();
                    cargarGrid();
                }
            }
        }
    }
