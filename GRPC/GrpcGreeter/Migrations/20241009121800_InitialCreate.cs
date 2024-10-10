using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrpcGreeter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grpc_data",
                columns: table => new
                {
                    ud_num = table.Column<string>(type: "text", nullable: false),
                    packet_seq_num = table.Column<int>(type: "integer", maxLength: 128, nullable: false),
                    record_seq_num = table.Column<int>(type: "integer", maxLength: 128, nullable: false),
                    packet_timestamp = table.Column<string>(type: "text", nullable: false),
                    dec_1 = table.Column<double>(type: "double precision", nullable: false),
                    dec_2 = table.Column<double>(type: "double precision", nullable: false),
                    dec_3 = table.Column<double>(type: "double precision", nullable: false),
                    dec_4 = table.Column<double>(type: "double precision", nullable: false),
                    record_timestap = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkey", x => x.ud_num);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grpc_data");
        }
    }
}
