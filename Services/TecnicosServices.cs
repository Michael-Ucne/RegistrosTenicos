using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;

namespace RegistrosTenicos.Services
{
    public class TecnicosServices(IDbContextFactory<Contexto> DbFactory)
    {

        // Metodo Existe
        private async Task<bool> Existe(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AnyAsync(t => t.TecnicoId == tecnicoId);
        }
    }
}
