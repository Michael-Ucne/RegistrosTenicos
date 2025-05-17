using Microsoft.EntityFrameworkCore;
using RegistrosTenicos.DAL;

namespace RegistrosTenicos.Services
{
    public class TecnicosServices(IDbContextFactory<Contexto> DbFactory)
    {

    }
}
