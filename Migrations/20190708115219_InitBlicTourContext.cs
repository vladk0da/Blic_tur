using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blic_tur.Migrations
{
    public partial class InitBlicTourContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TypeCar = table.Column<string>(nullable: false),
                    Number_of_the_car = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SurName = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(nullable: false),
                    NumberPhone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PasswordConfirm = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SurName = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(nullable: false),
                    NumberPhone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PasswordConfirm = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: false),
                    CityFromId = table.Column<Guid>(nullable: false),
                    CityToId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Cities_CityFromId",
                        column: x => x.CityFromId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Routes_Cities_CityToId",
                        column: x => x.CityToId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriverId = table.Column<int>(nullable: false),
                    DriverId1 = table.Column<Guid>(nullable: true),
                    CarId = table.Column<int>(nullable: false),
                    CarId1 = table.Column<Guid>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Cars_CarId1",
                        column: x => x.CarId1,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Drivers_DriverId1",
                        column: x => x.DriverId1,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    RouteId = table.Column<Guid>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ToPlaceInCity = table.Column<string>(nullable: true),
                    FromPlaceInCity = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    TripId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("e9a7ed50-fd06-455c-a555-8156fb9be18e"), "Днепр" },
                    { new Guid("66f36c7b-5b0f-4a99-8228-a4b04c5a1297"), "Харьков" },
                    { new Guid("5d94f14a-540a-4dd5-8719-d098e1b5b4e3"), "Киев" },
                    { new Guid("b405c00b-cf4a-4ee9-8ec9-d75f41f068d6"), "Счастливцево" },
                    { new Guid("0c98ed05-f4e1-4170-b6a7-32c3b8128256"), "Кирилловка" },
                    { new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), "Кривой Рог" },
                    { new Guid("c0d1ded0-c89f-4da8-ba3a-18d0b3a5e097"), "Бердянск" },
                    { new Guid("7c98ee79-9204-4bbd-b33e-d2559547fcc8"), "Железный Порт" },
                    { new Guid("dd3a805d-357d-4245-a02f-edf0fd42f2bb"), "Лазурное" },
                    { new Guid("d42f4498-df67-4fc6-849e-dde60eaa42e4"), "Скадовск" },
                    { new Guid("1784754a-a375-4593-bfe6-129fd9a05790"), "Геническ" },
                    { new Guid("982555b4-d17b-4cb4-9814-df5990f3251b"), "Одесса" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Login", "Name", "NumberPhone", "Password", "PasswordConfirm", "SurName" },
                values: new object[,]
                {
                    { new Guid("36307e4a-e818-4454-9bd3-5083b09fb6e0"), "kate1990", "Катя", "0504582074", "kate1", "kate1", "Титова" },
                    { new Guid("e7e05f58-d7c2-44c1-9124-02131dedc4f0"), "alex007", "Алексей", "0671239060", "alex123", "alex123", "Шапошник" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "CityFromId", "CityToId", "Description", "Img", "Price" },
                values: new object[,]
                {
                    { new Guid("744173e5-1715-450b-b29c-520d2159050c"), new Guid("e9a7ed50-fd06-455c-a555-8156fb9be18e"), new Guid("66f36c7b-5b0f-4a99-8228-a4b04c5a1297"), "Сбор по городу по всем остановкам. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд Из Днепра в Харьков осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "3.jpg", 185 },
                    { new Guid("1ebf301f-c8dd-4eec-af65-b984b19311ba"), new Guid("66f36c7b-5b0f-4a99-8228-a4b04c5a1297"), new Guid("5d94f14a-540a-4dd5-8719-d098e1b5b4e3"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд из Харькова в Киев осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "2.jpg", 270 },
                    { new Guid("aef457bc-7223-4385-b164-f83c356a36f3"), new Guid("5d94f14a-540a-4dd5-8719-d098e1b5b4e3"), new Guid("e9a7ed50-fd06-455c-a555-8156fb9be18e"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд из Киева в Днепр осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "1.jpg", 350 },
                    { new Guid("1923e42e-1c16-4648-be58-a9749397dc8e"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("b405c00b-cf4a-4ee9-8ec9-d75f41f068d6"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Счастливцево осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "schastlivcevo.jpg", 350 },
                    { new Guid("62e7d88e-b5cd-4aed-9676-9eced2fedf86"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("0c98ed05-f4e1-4170-b6a7-32c3b8128256"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Кирилловку осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "kirillovka.jpg", 430 },
                    { new Guid("58cc0c9d-0a9f-4660-9e7a-deebc46beca1"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("66f36c7b-5b0f-4a99-8228-a4b04c5a1297"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Харьков осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "kharkov.jpg", 250 },
                    { new Guid("9c6525bf-26ce-4ec9-8769-6448ac0159a0"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("c0d1ded0-c89f-4da8-ba3a-18d0b3a5e097"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Бердянск осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "berdyansk.jpg", 450 },
                    { new Guid("774551c0-20ea-4a51-b17c-5041cb687c1a"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("7c98ee79-9204-4bbd-b33e-d2559547fcc8"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Железный порт осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "zheleznyjPort.jpg", 370 },
                    { new Guid("bce3a87b-5d46-4f2d-b195-629b95e4eb4a"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("dd3a805d-357d-4245-a02f-edf0fd42f2bb"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Лазурное осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "lazurnoe.jpg", 350 },
                    { new Guid("54ff5a00-c8af-415f-8524-633b6ef43b47"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("d42f4498-df67-4fc6-849e-dde60eaa42e4"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Скадовск осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "skadovsk.jpg", 350 },
                    { new Guid("1f10553d-e2fc-45da-9b89-1e0f0080d6d6"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("1784754a-a375-4593-bfe6-129fd9a05790"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Геническ осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "genichesk.jpg", 350 },
                    { new Guid("e7920f9b-0b67-49ed-ab64-719e78f5ae89"), new Guid("76ba56d8-585d-4f0b-9df4-62bc223c56f3"), new Guid("982555b4-d17b-4cb4-9814-df5990f3251b"), "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Одессу осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", "odessa.jpg", 400 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RouteId",
                table: "Orders",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TripId",
                table: "Orders",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CityFromId",
                table: "Routes",
                column: "CityFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CityToId",
                table: "Routes",
                column: "CityToId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CarId1",
                table: "Trips",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId1",
                table: "Trips",
                column: "DriverId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
