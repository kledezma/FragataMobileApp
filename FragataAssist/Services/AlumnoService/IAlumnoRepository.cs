using FragataAssist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Services.AlumnoService
{
    public interface IAlumnoRepository
    {
        Task<bool> AddUpdateAlumnoAsync(Alumno alumno);
        Task<bool> DeleteAlumnoAsync(string cedula);
        Task<Alumno> GetAlumnoAsync(string cedula);
        Task<IEnumerable<Alumno>> GetAllAlumnosAsync();
        Task<IEnumerable<Alumno>> GetAlumnosByCedulaAsync(string cedula);
        Task<IEnumerable<Alumno>> GetAlumnosByActivoAsync(bool activo);
    }
}
