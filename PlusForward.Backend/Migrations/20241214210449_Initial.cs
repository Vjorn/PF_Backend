using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlusForward.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServerId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpAddress = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServerName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MapName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServersData", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            
            migrationBuilder.Sql(@"
CREATE PROCEDURE AddServerEntry(
    _ServerId VARCHAR(36),
    _IpAddress VARCHAR(15),
    _ServerName VARCHAR(25),
    _MapName VARCHAR(25),
    _CurrentPlayers INT,
    _MaxPlayers INT)
BEGIN
    INSERT INTO ServersData (ServerId, IpAddress, ServerName, MapName, CurrentPlayers, MaxPlayers) 
    VALUES (_ServerId, _IpAddress, _ServerName, _MapName, _CurrentPlayers, _MaxPlayers);
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS AddServerEntry;");
            
            migrationBuilder.DropTable(
                name: "ServersData");
        }
    }
}
