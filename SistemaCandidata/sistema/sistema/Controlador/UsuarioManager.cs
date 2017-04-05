using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using sistema.Modelo;

namespace sistema.Controlador
{
    class UsuarioManager
    {
        public static List<usuario> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.usuarios.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GuardarModificar(usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if (nUsuario.pkUsuario > 0)
                    {
                        ctx.Entry(nUsuario).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(nUsuario).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminar(usuario eUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {

                    ctx.Entry(eUsuario).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<usuario> Buscar(FILTRARUSUARIO buscarPor, String Valor)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if (buscarPor == FILTRARUSUARIO.NOMBRE)
                    {
                        return ctx.usuarios.Where(r => r.sNombreCompleto.Contains(Valor)).ToList();
                    }
                    else
                    {
                        return ctx.usuarios.Where(r => r.sNombreCompleto.Contains(Valor)).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public enum FILTRARUSUARIO
    {
        APELLIDO = 0,
        NOMBRE = 1
    }
}



