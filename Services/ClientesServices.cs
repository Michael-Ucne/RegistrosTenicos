using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;
using System.Linq.Expressions;

namespace RegistrosTenicos.Services
{
    public class ClientesServices(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Existe(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AnyAsync(c => c.ClienteId == clienteId);
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Clientes.Add(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Clientes cliente)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            cliente.ClienteId = cliente.ClienteId;
            if (!await Existe(cliente.ClienteId))
            {
                return await Insertar(cliente);
            }
            else
            {
                return await Modificar(cliente);
            }
        }

        public async Task<Clientes?> Buscar(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AsNoTracking()
                .Where(c => c.ClienteId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
