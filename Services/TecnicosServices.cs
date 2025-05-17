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

        // Metodo Insertar
        private async Task<bool> Insertar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Tecnicos.Add(tecnicos);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Metodo Modificar 
        private async Task<bool> Modificar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(tecnicos);
            return await contexto.SaveChangesAsync() > 0;
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

        // Metodo Buscar
        public async Task<Tecnicos?> Buscar(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos.Include(d => d.TecnicoId)
                .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
        }
    }
}
