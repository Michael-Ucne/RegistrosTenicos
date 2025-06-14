using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;

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
    }
}
