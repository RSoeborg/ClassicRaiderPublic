using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
	public interface IPlayerRepository
	{
		PlayerEntity Create(PlayerEntity playerEntity);

		IEnumerable<PlayerEntity> GetAll();

		IEnumerable<PlayerEntity> QueryByName(string Name);

		PlayerEntity GetById(int userId);
		
		void Update(UserEntity userEntity);
	}
}
