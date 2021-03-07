using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addingcolumnsinapplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<bool>(
                name: "ReviewStatus",
                table: "ApplicantDetail",
                type: "bit",
                nullable: true);


            migrationBuilder.AddColumn<string>(
              name: "ApplicationStatus",
              table: "ApplicantDetail",
              type: "varchar(50)",
              nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "ApplicantDetail");

            migrationBuilder.DropColumn(
               name: "ReviewStatus",
               table: "ApplicantDetail");

        
        }
    }
}
