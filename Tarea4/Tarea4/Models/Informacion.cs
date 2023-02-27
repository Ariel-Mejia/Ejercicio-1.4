using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea4.Models
{
    public class Informacion
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public String nombres { get; set; }

        public String descripcion { get; set; }

        public byte[] imagen { get; set; }
    }
}
