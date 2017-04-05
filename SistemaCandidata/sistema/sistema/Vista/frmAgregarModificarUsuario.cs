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
    public partial class frmAgregarModificarUsuario : Form
    {
        frmUsuarios Usuario;
        usuario ZUSUARIO;
        public frmAgregarModificarUsuario(frmUsuarios usu)
        {
            InitializeComponent();
            btnAceptar.Text = "Agregar";
            Usuario = usu;
        }

        public frmAgregarModificarUsuario(frmUsuarios usu, usuario zusuario)
        {
            InitializeComponent();
            this.Text = "Editar usuario";
            btnAceptar.Text = "Actualizar";
            ZUSUARIO = zusuario;
            txtNombreCompleto.Text = zusuario.sNombreCompleto;
            txtCuenta.Text = zusuario.Cuenta;
            txtContrasena.Text = zusuario.sContrasena;
            checkBox1.Checked = zusuario.bStatus;
            //cmbRol.Text = zusuario.Roles;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            usuario Nusuario;
            if (ZUSUARIO == null)
            {
                Nusuario = new usuario();
            }
            else
            {
                Nusuario = ZUSUARIO;
            }

            Nusuario.sNombreCompleto = txtNombreCompleto.Text;
            Nusuario.Cuenta = txtCuenta.Text;
            Nusuario.sContrasena = txtContrasena.Text;
            Nusuario.bStatus = false; 
            //Nusuario.Roles = cmbRol.Text;

            if(checkBox1.Checked == true)
            {
                Nusuario.bStatus = true;
            }

            UsuarioManager UsuarioM = new UsuarioManager();
            UsuarioM.GuardarModificar(Nusuario);

            Usuario.cargar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere salir de la ventana?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
