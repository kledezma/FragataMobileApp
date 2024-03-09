using FragataAssist.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Services.AlumnoService
{
    internal class AlumnoService : IAlumnoRepository
    {
        public SQLiteAsyncConnection _db;
        string _dbPath;

        public AlumnoService(string dbPath)
        {
            _dbPath = dbPath;
            InitAsync();
        }

        private async Task InitAsync()
        {
            if (_db != null)
            {
                return;
            }
            _db = new SQLiteAsyncConnection(_dbPath);
             _db.CreateTableAsync<Alumno>().Wait();
        }
        public async Task<bool> AddUpdateAlumnoAsync(Alumno alumno)
        {


            var response = await _db.Table<Alumno>().Where(p => p.IdAlumno == alumno.IdAlumno).CountAsync();
       

            if (response > 0)
            {
                await _db.UpdateAsync(alumno);
            }
            else
            {
                await _db.InsertAsync(alumno);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAlumnoAsync(string cedula)
        {
            await _db.DeleteAsync<Alumno>(cedula);
            return await Task.FromResult(true);
        }

        public async Task<Alumno> GetAlumnoAsync(string cedula)
        {
            return await _db.Table<Alumno>().Where(p => p.IdAlumno == cedula).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Alumno>> GetAllAlumnosAsync()
        {
            return await _db.Table<Alumno>().ToListAsync();
        }
        public async Task<IEnumerable<Alumno>> GetAlumnosByCedulaAsync(string cedula)
        {
            return await _db.Table<Alumno>().Where(p => p.IdAlumno == cedula).ToListAsync();

        }
        public async Task<IEnumerable<Alumno>> GetAlumnosByActivoAsync(bool activo)
        {
            return await _db.Table<Alumno>().Where(p => p.Activo == activo).ToListAsync();
        }
    }

}
