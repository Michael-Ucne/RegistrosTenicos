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

        // Metodo Guardar
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
    }
}
