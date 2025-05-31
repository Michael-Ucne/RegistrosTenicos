using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;
using System.Linq.Expressions;

namespace RegistrosTenicos.Services
{
    public class TecnicosServices(IDbContextFactory<Contexto> DbFactory)
    {

        private async Task<bool> Existe(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AnyAsync(t => t.TecnicoId == tecnicoId);
        }

        private async Task<bool> Insertar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Tecnicos.Add(tecnicos);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(tecnicos);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tecnicos tecnicos)
        {
            tecnicos.TecnicoId = tecnicos.TecnicoId;
            if (!await Existe(tecnicos.TecnicoId))
            {
              return await Insertar(tecnicos);
            }
            else
            {
                return await Modificar(tecnicos);
            }
        }

        public async Task<Tecnicos?> Buscar(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
        }

        public async Task<bool> Eliminar(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AsNoTracking()
                .Where(t => t.TecnicoId == tecnicoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
