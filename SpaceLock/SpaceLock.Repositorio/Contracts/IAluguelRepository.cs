using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Contracts
{
    public interface IAluguelRepository:IBaseRepository<Aluguel>
    {
        List<Aluguel> ListaAlugueisPorUsuario(int idUsuario);
        List<Aluguel> ListaAlugueisPorEspaco(int idEspaco);
        void AtualizaValorAluguel(int idAluguel, double valor);
        void CancelaAluguel(int idAluguel);
    }
}
