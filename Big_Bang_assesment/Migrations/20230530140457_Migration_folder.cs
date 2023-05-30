using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Big_Bang_assesment.Migrations
{
    /// <inheritdoc />
    public partial class Migration_folder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "5001, 1"),
                    Hotel_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_rating = table.Column<int>(type: "int", nullable: false),
                    Hotel_Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Guest_Id = table.Column<int>(type: "int", nullable: false),
                      
                    Guest_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guest_pwd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Guest_Id);
                    table.ForeignKey(
                        name: "FK_Guests_Hotels_Hotel_id",
                        column: x => x.Hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false),
                    Room_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Price = table.Column<int>(type: "int", nullable: false),
                    Room_Amenities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_Hotel_id",
                        column: x => x.Hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_Id = table.Column<int>(type: "int", nullable: false),
                    Check_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check_out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room_Id = table.Column<int>(type: "int", nullable: true),
                    Guest_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_Guest_Id",
                        column: x => x.Guest_Id,
                        principalTable: "Guests",
                        principalColumn: "Guest_Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Hotel_id",
                table: "Guests",
                column: "Hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Guest_Id",
                table: "Reservations",
                column: "Guest_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Room_Id",
                table: "Reservations",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hotel_id",
                table: "Rooms",
                column: "Hotel_id");
            migrationBuilder.AddColumn<string>(
                name: "Room_Avaliability",
                table: "Rooms"
              
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
