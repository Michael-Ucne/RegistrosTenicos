using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;
using RegistrosTenicos.Models;
using System.Linq.Expressions;

namespace RegistrosTenicos.Services
{
    public class ClientesServices(IDbContextFactory<Contexto> DbFactory)
    {

    }
}
