using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_CW_4.Migrations
{
    /// <inheritdoc />
    public partial class Finito2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription Medicament_Medicaments_IdMedicament",
                table: "Prescription Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription Medicament_Prescriptions_IdPrescription",
                table: "Prescription Medicament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription Medicament",
                table: "Prescription Medicament");

            migrationBuilder.RenameTable(
                name: "Prescription Medicament",
                newName: "Prescription_Medicament");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription Medicament_IdPrescription",
                table: "Prescription_Medicament",
                newName: "IX_Prescription_Medicament_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Medicaments_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Medicaments_IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament");

            migrationBuilder.RenameTable(
                name: "Prescription_Medicament",
                newName: "Prescription Medicament");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription Medicament",
                newName: "IX_Prescription Medicament_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription Medicament",
                table: "Prescription Medicament",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription Medicament_Medicaments_IdMedicament",
                table: "Prescription Medicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription Medicament_Prescriptions_IdPrescription",
                table: "Prescription Medicament",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
