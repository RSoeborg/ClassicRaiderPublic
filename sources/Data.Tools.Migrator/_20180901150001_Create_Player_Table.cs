using Data.Core;
using FluentMigrator;

namespace Data.Tools.Migrator
{
	[Migration(20180901150001, "Create Player Table")]
	public class _20180901150001_Create_Player_Table : Migration
	{
		private readonly IMigrationScriptPathProvider _migrationScriptPathProvider;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public _20180901150001_Create_Player_Table(IMigrationScriptPathProvider migrationScriptPathProvider)
		{
			_migrationScriptPathProvider = migrationScriptPathProvider;
		}

		public override void Down()
		{
		}

		public override void Up()
		{
			var script = _migrationScriptPathProvider.GetPath("Create_Player_Table.sql");

			IfDatabase(_Constants.SqlServer).Execute.Script(script);
		}
	}
}
