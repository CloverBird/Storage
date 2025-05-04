using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storage.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsForReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportItem_ProductsBatches_ProductsBatchId",
                table: "ReportItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportItem_Reports_ReportId",
                table: "ReportItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportItem",
                table: "ReportItem");

            migrationBuilder.RenameTable(
                name: "ReportItem",
                newName: "ReportItems");

            migrationBuilder.RenameIndex(
                name: "IX_ReportItem_ReportId",
                table: "ReportItems",
                newName: "IX_ReportItems_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportItem_ProductsBatchId",
                table: "ReportItems",
                newName: "IX_ReportItems_ProductsBatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportItems",
                table: "ReportItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportItems_ProductsBatches_ProductsBatchId",
                table: "ReportItems",
                column: "ProductsBatchId",
                principalTable: "ProductsBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportItems_Reports_ReportId",
                table: "ReportItems",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportItems_ProductsBatches_ProductsBatchId",
                table: "ReportItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportItems_Reports_ReportId",
                table: "ReportItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportItems",
                table: "ReportItems");

            migrationBuilder.RenameTable(
                name: "ReportItems",
                newName: "ReportItem");

            migrationBuilder.RenameIndex(
                name: "IX_ReportItems_ReportId",
                table: "ReportItem",
                newName: "IX_ReportItem_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportItems_ProductsBatchId",
                table: "ReportItem",
                newName: "IX_ReportItem_ProductsBatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportItem",
                table: "ReportItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportItem_ProductsBatches_ProductsBatchId",
                table: "ReportItem",
                column: "ProductsBatchId",
                principalTable: "ProductsBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportItem_Reports_ReportId",
                table: "ReportItem",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
