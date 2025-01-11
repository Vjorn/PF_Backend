using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlusForward.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntryProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE RemoveServerEntry(_ServerId VARCHAR(36))
BEGIN
    DELETE FROM ServersData WHERE ServerId = _ServerId;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS RemoveServerEntry;");
        }
    }
}
