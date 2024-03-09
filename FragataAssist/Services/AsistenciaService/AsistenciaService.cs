using FragataAssist.Data;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace FragataAssist.Services.AsistenciaService
{
    internal class AsistenciaService : IAsistenciaRepository
    {
        public SQLiteAsyncConnection _db;
        string _dbPath;

        public AsistenciaService(string dbPath)
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
            _db.CreateTableAsync<Asistencia>().Wait();
            _db.CreateTableAsync<Alumno>().Wait();


        }

        public async Task<bool> AddUpdateAsistenciaAsync(Asistencia newAsistencia)
        {
            await _db.InsertAsync(newAsistencia);
           
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsistenciasAsync()
        {
            await _db.Table<Asistencia>().DeleteAsync(p => p.IdAsistencia >= 0);
            return await Task.FromResult(true);
         }

        public async Task<Asistencia> GetAsistenciaAsync(string cedula)
        {
            return await _db.Table<Asistencia>().Where(p => p.IdAlumno == cedula).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Asistencia>> GetAllAsistenciasAsync()
        {
            return await _db.Table<Asistencia>().ToListAsync();
        }
        public async Task<IEnumerable<Asistencia>> GetAsistenciasByCedulaAsync(string cedula)
        {
            return await _db.Table<Asistencia>().Where(p => p.IdAlumno == cedula).ToListAsync();

        }

    }

}
