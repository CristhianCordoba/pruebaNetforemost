using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Models;
using pruebaGestores.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaApi.Repositories
{
    public class BDRepository
    {
        private readonly ApplicationDbContext _context;

        public BDRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeudoresModel>> CallStoredProcedureAsyncDeudores()
        {
            var result = await _context.DeudoresModel
                .FromSqlRaw("EXEC ver_saldos_pendientes")
                .ToListAsync();

            return result ?? new List<DeudoresModel>();
        }

        public async Task<IEnumerable<ModeGestoresSaldos>> CallStoredProcedureAsyncDeudoresSaldos()
        {
            var result = await _context.GestoresSaldos
                .FromSqlRaw("EXEC ver_gestores_asociados_cuentas_por_cobrar")
                .ToListAsync();

            return result ?? new List<ModeGestoresSaldos>();
        }

        public async Task<IEnumerable<ModeGestores>> CallStoredProcedureAsyncGestores()
        {
            var result = await _context.Gestores
                .FromSqlRaw("EXEC ver_gestores")
                .ToListAsync();

            return result ?? new List<ModeGestores>();
        }
    }
}
