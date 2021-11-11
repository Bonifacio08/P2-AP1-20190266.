using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_20190266.Entidades
{
    public class TipoDetalle
    {
        [Key]

        public int Id { get; set; }
        public int Proyectoid { get; set; }
        public string TipodeTarea { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }


        public TipoDetalle()
        {
            Id = 0;
            Proyectoid = 0;
            TipodeTarea = string.Empty;
            Requerimiento = string.Empty;
            Tiempo = 0;
        }

        public TipoDetalle(int proyectoid, string tipotarea, string requerimiento, int tiempo)
        {
            Id = 0;
            Proyectoid = proyectoid;
            TipodeTarea = tipotarea;
            Requerimiento = requerimiento;
            Tiempo = tiempo;
        }


    }
}

