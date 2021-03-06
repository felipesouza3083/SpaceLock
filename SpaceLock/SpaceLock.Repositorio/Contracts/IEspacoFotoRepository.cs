﻿using SpaceLock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Contracts
{
    public interface IEspacoFotoRepository:IBaseRepository<EspacoFoto>
    {
        List<EspacoFoto> ListarFotosPorEspaco(int idEspaco);
    }
}
