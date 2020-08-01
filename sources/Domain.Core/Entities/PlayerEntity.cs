using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Entities
{
	public class PlayerEntity
	{
		public int Id { get; set; }
		public string PlayerGUID { get; set; }
		public string Name { get; set; }
		public string Race { get; set; }
		public int Level { get; set; }
		public string @Class { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int UpdatedBy { get; set; }
	}
}
