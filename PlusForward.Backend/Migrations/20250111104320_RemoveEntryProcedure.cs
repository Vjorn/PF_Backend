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
CREATE PROCEDURE RemoveServerEntry(_IpAddress VARCHAR(15))
BEGIN
    DELETE FROM ServersData WHERE IpAddress = _IpAddress;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS RemoveServerEntry;");
        }
    }
}
