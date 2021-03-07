using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addingindexparttwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApplicantDetail_GrantProgram_GrantProgramGrantId",
            //    table: "ApplicantDetail");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApplicantDetail_GrantProgramGrantId",
            //    table: "ApplicantDetail");

            //migrationBuilder.DropColumn(
            //    name: "GrantProgramGrantId",
            //    table: "ApplicantDetail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetail_GrantId",
                table: "ApplicantDetail",
                column: "GrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetail_GrantProgram_GrantId",
                table: "ApplicantDetail",
                column: "GrantId",
                principalTable: "GrantProgram",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetail_GrantProgram_GrantId",
                table: "ApplicantDetail");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetail_GrantId",
                table: "ApplicantDetail");

            //migrationBuilder.AddColumn<int>(
            //    name: "GrantProgramGrantId",
            //    table: "ApplicantDetail",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicantDetail_GrantProgramGrantId",
            //    table: "ApplicantDetail",
            //    column: "GrantProgramGrantId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ApplicantDetail_GrantProgram_GrantProgramGrantId",
            //    table: "ApplicantDetail",
            //    column: "GrantProgramGrantId",
            //    principalTable: "GrantProgram",
            //    principalColumn: "GrantId",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
