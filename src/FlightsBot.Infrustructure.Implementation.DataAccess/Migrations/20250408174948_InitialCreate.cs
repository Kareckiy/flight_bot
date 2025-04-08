using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "flights_bot");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:data_provider", "YANDEX")
                .Annotation("Npgsql:Enum:flight_status", "CREATED,DELAYED,IN_PROGRESS,FINISHED,CANCELED,FAILED");

            migrationBuilder.CreateTable(
                name: "Airplanes",
                schema: "flights_bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PassengersMaxCount = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                schema: "flights_bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IataCode = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                schema: "flights_bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CodeDataProvider = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "flights_bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    FinishedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    AirportFromId = table.Column<Guid>(type: "uuid", nullable: false),
                    AirportToId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PassengersCount = table.Column<int>(type: "integer", nullable: false),
                    AirplaneId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarrierId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalSchema: "flights_bot",
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportFromId",
                        column: x => x.AirportFromId,
                        principalSchema: "flights_bot",
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportToId",
                        column: x => x.AirportToId,
                        principalSchema: "flights_bot",
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "flights_bot",
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "flights_bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "flights_bot",
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_IataCode",
                schema: "flights_bot",
                table: "Airports",
                column: "IataCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_Code",
                schema: "flights_bot",
                table: "Carriers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                schema: "flights_bot",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportFromId",
                schema: "flights_bot",
                table: "Flights",
                column: "AirportFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportToId",
                schema: "flights_bot",
                table: "Flights",
                column: "AirportToId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CarrierId",
                schema: "flights_bot",
                table: "Flights",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Number",
                schema: "flights_bot",
                table: "Flights",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FlightId",
                schema: "flights_bot",
                table: "Notifications",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "flights_bot");

            migrationBuilder.DropTable(
                name: "Flights",
                schema: "flights_bot");

            migrationBuilder.DropTable(
                name: "Airplanes",
                schema: "flights_bot");

            migrationBuilder.DropTable(
                name: "Airports",
                schema: "flights_bot");

            migrationBuilder.DropTable(
                name: "Carriers",
                schema: "flights_bot");
        }
    }
}
