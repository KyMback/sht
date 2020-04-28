using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Extensions
{
    internal static class MigrationBuilderExtensions
    {
        public static MigrationBuilder AddColumnWithDefaultValue<TColumn>(
            this MigrationBuilder migrationBuilder,
            [NotNull] string name,
            [NotNull] string table,
            int? maxLength = null,
            [CanBeNull] string schema = null,
            bool nullable = false,
            [CanBeNull] object defaultValue = null,
            [CanBeNull] string defaultValueSql = null,
            string oldType = null)
        {
            migrationBuilder.AddColumn<TColumn>(
                name: name,
                schema: schema,
                table: table,
                maxLength: maxLength,
                nullable: true);

            if (defaultValue != null)
            {
                migrationBuilder.UpdateData(
                    table,
                    name,
                    null,
                    name,
                    defaultValue,
                    schema);
            }

            if (defaultValueSql != null)
            {
                migrationBuilder.Sql(defaultValueSql);
            }

            if (!nullable)
            {
                migrationBuilder.AlterColumn<TColumn>(
                    name: name,
                    schema: schema,
                    table: table,
                    maxLength: maxLength,
                    nullable: false,
                    oldMaxLength: maxLength,
                    oldClrType: typeof(TColumn),
                    oldType: oldType);
            }

            return migrationBuilder;
        }
    }
}
