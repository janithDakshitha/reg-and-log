using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class reg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniProfiles",
                columns: table => new
                {
                    UniID = table.Column<int>(name: "Uni_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniFullName = table.Column<string>(name: "Uni_FullName", type: "nvarchar(max)", nullable: false),
                    UniShortName = table.Column<string>(name: "Uni_ShortName", type: "nvarchar(max)", nullable: false),
                    UniDetails = table.Column<string>(name: "Uni_Details", type: "nvarchar(max)", nullable: false),
                    UniFacultyID = table.Column<int>(name: "Uni_FacultyID", type: "int", nullable: false),
                    ImageExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilPicURL = table.Column<string>(name: "ProfilPic_URL", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniProfiles", x => x.UniID);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    DegreeID = table.Column<int>(name: "Degree_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreName = table.Column<string>(name: "Degre_Name", type: "nvarchar(max)", nullable: false),
                    DegreeType = table.Column<string>(name: "Degree_Type", type: "nvarchar(max)", nullable: false),
                    DegreeDescription = table.Column<string>(name: "Degree_Description", type: "nvarchar(max)", nullable: true),
                    DegreeDuration = table.Column<string>(name: "Degree_Duration", type: "nvarchar(max)", nullable: true),
                    AdmissionRequirementsID = table.Column<int>(name: "Admission_Requirements_ID", type: "int", nullable: true),
                    CareerOpurtunity = table.Column<string>(name: "Career_Opurtunity", type: "nvarchar(max)", nullable: true),
                    AffiliatedUni = table.Column<string>(name: "Affiliated_Uni", type: "nvarchar(max)", nullable: true),
                    DegreeContentID = table.Column<int>(name: "Degree_Content_ID", type: "int", nullable: true),
                    CourseFee = table.Column<string>(name: "Course_Fee", type: "nvarchar(max)", nullable: true),
                    Academicprog = table.Column<string>(name: "Academic_prog", type: "nvarchar(max)", nullable: true),
                    UniID = table.Column<int>(name: "Uni_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.DegreeID);
                    table.ForeignKey(
                        name: "FK_Degrees_UniProfiles_Uni_ID",
                        column: x => x.UniID,
                        principalTable: "UniProfiles",
                        principalColumn: "Uni_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_Uni_ID",
                table: "Degrees",
                column: "Uni_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "UniProfiles");
        }
    }
}
