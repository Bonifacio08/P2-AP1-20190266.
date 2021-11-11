using Microsoft.EntityFrameworkCore;
using P2_AP1_20190266.DAL;
using P2_AP1_20190266.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_20190266.BLL
{
    public class ProyectoBLL
    {
        public static bool Guardar(Proyecto proyecto)
        {
            if (!Existe(proyecto.Proyectoid))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }
        private static bool Insertar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyecto.Add(proyecto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Modificar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM TipoDetalle Where Proyectoid={proyecto.Proyectoid}");

                foreach (var item in proyecto.TipoDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyecto = ProyectoBLL.Buscar(id);

                if (proyecto != null)
                {
                    contexto.Proyecto.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Proyecto Buscar(int id)
        {
            Proyecto tarea = new Proyecto();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Proyecto.Include(x => x.TipoDetalle).Where(x => x.Proyectoid == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyecto.Any(e => e.Proyectoid == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            List<Proyecto> Lista = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyecto.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
