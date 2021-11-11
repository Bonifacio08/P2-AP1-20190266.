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
    public class TipoDeTareaBLL
    {
        public static TipoDeTareas Buscar(int id)
        {
            TipoDeTareas tipotarea;

            Contexto contexto = new Contexto();

            try
            {
                tipotarea = contexto.TipoDeTarea.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tipotarea;
        }

        public static List<TipoDeTareas> GetPermisos()
        {
            List<TipoDeTareas> lista = new List<TipoDeTareas>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TipoDeTarea.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TipoDeTareas> GetList(Expression<Func<TipoDeTareas, bool>> criterio)
        {
            List<TipoDeTareas> Lista = new List<TipoDeTareas>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.TipoDeTarea.Where(criterio).ToList();
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
