using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;

namespace RegistrosTenicos.Services
{
    public class SistemasServices(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Existe(int sistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistema
                .AnyAsync(t => t.SistemaId == sistemaId);
        }

        private async Task<bool> Insertar(Sistema sistema)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Sistema.Add(sistema);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Sistema sistema)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(sistema);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Sistema sistema)
        {
            sistema.SistemaId = sistema.SistemaId;
            if (!await Existe(sistema.SistemaId))
            {
                return await Insertar(sistema);
            }
            else
            {
                return await Modificar(sistema);
            }
        }

        public async Task<Sistema?> Buscar(int sistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistema
                .FirstOrDefaultAsync(s => s.SistemaId == sistemaId);
        }
        public async Task<bool> Eliminar(int sistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistema
                .AsNoTracking()
                .Where(s => s.SistemaId == sistemaId)
                .ExecuteDeleteAsync() > 0;
        }

    }
}
