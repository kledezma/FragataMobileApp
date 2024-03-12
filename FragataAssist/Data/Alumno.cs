using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Data
{
    [SQLite.Table("Alumno")]

    public class Alumno
    {

        [PrimaryKey]
        public string IdAlumno { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Foto { get; set; }
        public string PathFoto { get; set; }

    }
}
