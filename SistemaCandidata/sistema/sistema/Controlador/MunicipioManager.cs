using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using sistema.Modelo;

namespace sistema.Controlador
{
    class MunicipioManager
    {
        public static List<Municipio> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.municipios.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GuardarModificar(Municipio nMunicipio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if (nMunicipio.pkMunicipio > 0)
                    {
                        ctx.Entry(nMunicipio).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(nMunicipio).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminar(Municipio eMunicipio)
        {
            try
            {
                using (var ctx = new DataModel())
                {

                    ctx.Entry(eMunicipio).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Municipio> Buscar(FILTRAR buscarPor, String Valor)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if (buscarPor == FILTRAR.NOMBRE)
                    {
                        return ctx.municipios.Where(r => r.sNombreMunicipio.Contains(Valor)).ToList();
                    }
                    else
                    {
                        return ctx.municipios.Where(r => r.sNombreMunicipio.Contains(Valor)).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public enum FILTRAR
    {
        APELLIDO = 0,
        NOMBRE = 1
    }
}
