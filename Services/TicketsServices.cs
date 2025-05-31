using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;
using System.Linq.Expressions;

namespace RegistrosTenicos.Services
{
    public class TicketsServices(IDbContextFactory<Contexto> DbFactory)
    {
        // Metodo Existe
        private async Task<bool> Existe(int ticketId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .AnyAsync(t => t.TicketId == ticketId);
        }

        // Metodo Insertar
        private async Task<bool> Insertar(Tickets tickets)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Tickets.Add(tickets);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Metodo Modificar 
        private async Task<bool> Modificar(Tickets tickets)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(tickets);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Metodo Guardar
        public async Task<bool> Guardar(Tickets tickets)
        {
            if (!await Existe(tickets.TicketId))
            {
                return await Insertar(tickets);
            }
            else
            {
                return await Modificar(tickets);
            }
        }

        // Metodo Buscar
        public async Task<Tickets?> Buscar(int ticketId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        // Metodo Eliminar
        public async Task<bool> Eliminar(int ticketId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .AsNoTracking()
                .Where(t => t.TicketId == ticketId)
                .ExecuteDeleteAsync() > 0;
        }

        // Metodo Listar
        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}