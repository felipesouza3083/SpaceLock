using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Contracts
{
    public interface IEspacoRepository:IBaseRepository<Espaco>
    {
        List<Espaco> ListarPorUsuario(int idUsuario);

        List<Espaco> ListarPorTipoEvento(int idTipoEvento);

        int InsertRetornandoChavePrimaria(Espaco obj);
    }
}
