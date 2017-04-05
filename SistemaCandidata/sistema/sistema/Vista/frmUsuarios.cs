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

namespace sistema.Vista
{
    public partial class frmUsuarios : Form
    {
        public void cargar()
        {
            this.dgvDatos.DataSource = UsuarioManager.Listar();
        }

        public frmUsuarios()
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificarUsuario verUsuario = new frmAgregarModificarUsuario(this);
            verUsuario.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioManager UsuarioM = new UsuarioManager();
            usuario eUsuario = new usuario();

            eUsuario.pkUsuario = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            UsuarioM.eliminar(eUsuario);
            cargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FILTRARUSUARIO BUSCAR = new FILTRARUSUARIO();
            this.dgvDatos.DataSource = UsuarioManager.Buscar(BUSCAR, txtBuscar.Text);
        }

        private void dgvDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            usuario Usuario = new usuario();

            Usuario.pkUsuario = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            Usuario.sNombreCompleto = dgvDatos.CurrentRow.Cells[1].Value.ToString();
            Usuario.Cuenta = dgvDatos.CurrentRow.Cells[2].Value.ToString();
            Usuario.bStatus = Convert.ToBoolean(dgvDatos.CurrentRow.Cells[3].Value.ToString());
            Usuario.Roles.pkRol = int.Parse(dgvDatos.CurrentRow.Cells[4].Value.ToString());
            //Usuario.sContrasena = dgvDatos.CurrentRow.Cells[3].Value.ToString();

            //Usuario.Roles = (dgvDatos.CurrentRow.Cells[5].Value.ToString());

            frmAgregarModificarUsuario editar = new frmAgregarModificarUsuario(this, Usuario);
            editar.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
