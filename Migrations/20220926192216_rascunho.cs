using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace video.Migrations
{
    public partial class rascunho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalGravação = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoExtencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoDuracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoAssunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
