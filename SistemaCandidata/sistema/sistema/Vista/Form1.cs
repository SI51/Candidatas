using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sistema.Controlador;
using sistema.Modelo;
using sistema.Vista;

namespace sistema
{
    public partial class frmMunicipio : Form
    {

        public void cargar()
        {
            this.dgvDatos.DataSource = MunicipioManager.Listar();
        }
        public frmMunicipio()
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
        }

        private void frmMunicipio_Load(object sender, EventArgs e)
        {
            this.cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificarMunicipio Agrgar = new frmAgregarModificarMunicipio(this);
            Agrgar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MunicipioManager MunicipioM = new MunicipioManager();
            Municipio eMUNI = new Municipio();

            eMUNI.pkMunicipio = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            MunicipioM.eliminar(eMUNI);
            cargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            FILTRAR BUSCAR = new FILTRAR();
            this.dgvDatos.DataSource = MunicipioManager.Buscar(BUSCAR, txtBuscar.Text);
        }

        private void dgvDatos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Municipio Municipio = new Municipio();            

            Municipio.pkMunicipio = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            Municipio.sNombreMunicipio = dgvDatos.CurrentRow.Cells[1].Value.ToString();
            Municipio.sDescripcion = dgvDatos.CurrentRow.Cells[2].Value.ToString();
            Municipio.bStatus = Convert.ToBoolean(dgvDatos.CurrentRow.Cells[3].Value.ToString());
            Municipio.sLogotipo = dgvDatos.CurrentRow.Cells[4].Value.ToString();

            frmAgregarModificarMunicipio editar = new frmAgregarModificarMunicipio(this,Municipio);
            editar.Show();
        }
    }
}
