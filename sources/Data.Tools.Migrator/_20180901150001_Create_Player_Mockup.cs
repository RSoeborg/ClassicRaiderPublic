using Data.Core;
using FluentMigrator;

namespace Data.Tools.Migrator
{
	[Migration(20180901150002, "Create mockup data for 10.000 players")]
	public class _20180901150001_Create_Player_Mockup : Migration
	{
		private readonly IMigrationScriptPathProvider _migrationScriptPathProvider;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public _20180901150001_Create_Player_Mockup(IMigrationScriptPathProvider migrationScriptPathProvider)
		{
			_migrationScriptPathProvider = migrationScriptPathProvider;
		}

		public override void Down()
		{
		}

		public override void Up()
		{
			var script = _migrationScriptPathProvider.GetPath("Create_Player_Mockup.sql");

			IfDatabase(_Constants.SqlServer).Execute.Script(script);
		}
	}
}
