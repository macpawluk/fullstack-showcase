using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace TreeExercise.Models.Migrations.Extensions
{
	public static class MigrationExtensions
	{
		public static void RunScriptFromFile(this MigrationBuilder migrationBuilder, string scriptFileName)
		{
			var scriptFullPath = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory, 
				$"Migrations/Scripts/{scriptFileName}");

			var scriptBody = File.ReadAllText(scriptFullPath);
			migrationBuilder.Sql(scriptBody);
		}
	}
}
