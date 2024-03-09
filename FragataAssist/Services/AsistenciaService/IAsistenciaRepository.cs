using FragataAssist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Services.AsistenciaService
{
    public interface IAsistenciaRepository
    {
        Task<bool> AddUpdateAsistenciaAsync(Asistencia alumno);
        Task<bool> DeleteAsistenciasAsync();
        Task<Asistencia> GetAsistenciaAsync(string cedula);
        Task<IEnumerable<Asistencia>> GetAllAsistenciasAsync();
        Task<IEnumerable<Asistencia>> GetAsistenciasByCedulaAsync(string cedula);
        //Task<IEnumerable<Asistencia>> GetAsistenciasByActivoAsync(bool activo);
    }
}
