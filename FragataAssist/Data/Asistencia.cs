
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace FragataAssist.Data
{
    [SQLite.Table("Asistencia")]
    public class Asistencia
    {

        [PrimaryKey, AutoIncrement]
        public int IdAsistencia { get; set; }

        public string IdAlumno { get; set; }

        public DateTime Hora { get; set; }

        public bool EntradaSalida { get; set; }

        //[ManyToOne(CascadeOperations = CascadeOperation.All)]
        //public  Alumno alumno { get; set; }

    }
}
