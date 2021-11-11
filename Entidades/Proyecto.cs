using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_20190266.Entidades
{
    public class Proyecto
    {
        [Key]
        public int Proyectoid { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }


        [ForeignKey("Proyectoid")]
        public virtual List<TipoDetalle> TipoDetalle { get; set; }

        public Proyecto()
        {
            Proyectoid = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            TipoDetalle = new List<TipoDetalle>();
        }
    }
}

