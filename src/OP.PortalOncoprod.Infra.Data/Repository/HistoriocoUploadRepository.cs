
using OP.PortalOncoprod.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Infra.Data.Context;
using SistemaIndexador.Domain.Entities;

namespace OP.PortalOncoprod.Infra.Data.Repository
{
    public class HistoriocoUploadRepository : Repository<HistoriocoUpload>, IHistoriocoUploadRepository
    {
        public HistoriocoUploadRepository(PortalOncoprodContext context) : base(context)
        {

        }
    }
}
