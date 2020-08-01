using Dapper;
using Data.Core;
using Domain.Core;
using Domain.Core.Entities;
using Domain.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Store.SqlServer
{
	public class PlayerRepository : IPlayerRepository
	{
		internal readonly IDbConnectionFactory _dbConnectionFactory = null;

		public PlayerRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory), nameof(UsersRepository));
		}


		public PlayerEntity Create(PlayerEntity playerEntity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@PlayerGUID", playerEntity.PlayerGUID, DbType.String);
					parameters.Add("@Name", playerEntity.Name, DbType.String);
					
					playerEntity.Id = connection.ExecuteScalar<int>(
						sql: "PlayerInsert",
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					
					transaction.Commit();

					return playerEntity;
				}
			}
		}


		// TODO: Create stored procedures instead of direct SQL calls

		public IEnumerable<PlayerEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public PlayerEntity GetById(int userId)
		{

			var parameters = new DynamicParameters();

			parameters.Add("@UserId", userId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				return connection.QueryFirstOrDefault<PlayerEntity>(
					sql: "SELECT * FROM [Players] WHERE Id = @UserId LIMIT 1",
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}

		public IEnumerable<PlayerEntity> QueryByName(string Name)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Name", Name + "%", DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				return connection.Query<PlayerEntity>(
					sql: "SELECT * FROM [Players] WHERE Name LIKE @Name",
					commandType: CommandType.Text,
					param: parameters
				);
			}
		}

		public void Update(UserEntity userEntity)
		{
			throw new NotImplementedException();
		}
	}
}
