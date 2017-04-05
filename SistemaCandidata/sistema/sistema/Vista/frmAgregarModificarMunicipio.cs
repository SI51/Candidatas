using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sistema.Modelo;
using sistema.Controlador;
using System.IO;

namespace sistema.Vista
{
    public partial class frmAgregarModificarMunicipio : Form
    {

        frmMunicipio MUNI;
        Municipio ZMUNI;

        

        public frmAgregarModificarMunicipio(frmMunicipio muni)
        {
            InitializeComponent();
            MUNI = muni;
        }

        public frmAgregarModificarMunicipio(frmMunicipio muni, Municipio zmuni)
        {
            InitializeComponent();
            this.Text = "Editar municipio";
            ZMUNI = zmuni;
            txtNombreCompleto.Text = zmuni.sNombreMunicipio;
            txtDescripcion.Text = zmuni.sDescripcion;
            chkEstado.Checked = zmuni.bStatus;
            txtRuta.Text = zmuni.sLogotipo;
            txtRuta.Enabled = false;




            MUNI = muni;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Municipio Nmuni;
            if (ZMUNI == null)
            {
                Nmuni = new Municipio();
            }
            else
            {
                Nmuni = ZMUNI;
            }                    

            Nmuni.sNombreMunicipio = txtNombreCompleto.Text;
            Nmuni.sDescripcion = txtDescripcion.Text;
            Nmuni.sLogotipo = txtRuta.Text;
            Nmuni.bStatus = false;
            if (chkEstado.Checked == true)
            {
                Nmuni.bStatus = true;
            }


            MunicipioManager MunicipioM = new MunicipioManager();
            MunicipioM.GuardarModificar(Nmuni);

            MUNI.cargar();
            this.Close();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere salir de la ventana?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRuta.Text = openFileDialog1.FileName;
            }
        }
    }
}
