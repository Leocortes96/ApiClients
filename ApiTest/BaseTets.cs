using ApiClients.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    public class BaseTets
    {
        protected ApiClientsContext BuildContext(string nameDB)
        {
            var option = new DbContextOptionsBuilder<ApiClientsContext>()
                .UseInMemoryDatabase(nameDB).Options;
            var dbContext = new ApiClientsContext(option);
            return dbContext;
        }
    }
}
