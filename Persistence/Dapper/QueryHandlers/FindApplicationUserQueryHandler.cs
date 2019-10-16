﻿using ApplicationQueries.IdentityAndAccess;
using Dapper;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Dapper.QueryHandlers
{
    public class FindApplicationUserQueryHandler : IQueryHandlerAsync<FindApplicationUserQuery, ApplicationUserViewModel>
    {
         private readonly IDbConfigProvider databaseProvider;

        public FindApplicationUserQueryHandler(IDbConfigProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public async Task<ApplicationUserViewModel> HandleAsync(FindApplicationUserQuery query, CancellationToken cancellationToken = default)
        {        
            var sql = @"SELECT Login, Password, Id, PreSharedKey FROM Runners WHERE Login = @Login
                            UNION
                        SELECT Login, Password, Id, PreSharedKey FROM Coaches WHERE Login = @Login ";

            using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
            {
                connection.Open();

                return await connection.QueryFirstOrDefaultAsync<ApplicationUserViewModel>(sql, new { query.Login });
            }
        }
    }
}
