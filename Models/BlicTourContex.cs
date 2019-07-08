using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using System;

namespace Blic_tur.Models
{
    public class BlicTourContext : DbContext
    {
        // public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Order> Orders { get; set; }
        IConfiguration Configuration { get; }

        public BlicTourContext(DbContextOptions<BlicTourContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dnepr = new City { Id = Guid.NewGuid(), Title = "Днепр" };
            var harkiv = new City { Id = Guid.NewGuid(), Title = "Харьков" };
            var kiev = new City { Id = Guid.NewGuid(), Title = "Киев" };
            var schastlivcevo = new City { Id = Guid.NewGuid(), Title = "Счастливцево" };
            var kirillovka = new City { Id = Guid.NewGuid(), Title = "Кирилловка" };
            var krivojRog = new City { Id = Guid.NewGuid(), Title = "Кривой Рог" };
            var berdyansk = new City { Id = Guid.NewGuid(), Title = "Бердянск" };
            var zheleznyjPort = new City { Id = Guid.NewGuid(), Title = "Железный Порт" };
            var lazurnoe = new City { Id = Guid.NewGuid(), Title = "Лазурное" };
            var skadovsk = new City { Id = Guid.NewGuid(), Title = "Скадовск" };
            var genichesk = new City { Id = Guid.NewGuid(), Title = "Геническ" };
            var odessa = new City { Id = Guid.NewGuid(), Title = "Одесса" };
            modelBuilder.Entity<City>()
                .HasData(
                    dnepr,
                    harkiv,
                    kiev,
                    schastlivcevo,
                    kirillovka,
                    krivojRog,
                    berdyansk,
                    zheleznyjPort,
                    lazurnoe,
                    skadovsk,
                    genichesk,
                    odessa
                );
 

            modelBuilder.Entity<Route>()                
                .HasData(
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд Из Днепра в Харьков осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 185, CityFromId = dnepr.Id, CityToId = harkiv.Id, Img = "3.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд из Харькова в Киев осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 270, CityFromId = harkiv.Id, CityToId = kiev.Id, Img = "2.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд из Киева в Днепр осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 350, CityFromId = kiev.Id, CityToId = dnepr.Id, Img = "1.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Счастливцево осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 350, CityFromId = krivojRog.Id, CityToId = schastlivcevo.Id, Img = "schastlivcevo.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Кирилловку осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 430, CityFromId = krivojRog.Id, CityToId = kirillovka.Id, Img = "kirillovka.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Бердянск осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 450, CityFromId = krivojRog.Id, CityToId = berdyansk.Id, Img = "berdyansk.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Железный порт осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 370, CityFromId = krivojRog.Id, CityToId = zheleznyjPort.Id, Img = "zheleznyjPort.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Лазурное осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 350, CityFromId = krivojRog.Id, CityToId = lazurnoe.Id, Img = "lazurnoe.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Скадовск осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 350, CityFromId = krivojRog.Id, CityToId = skadovsk.Id, Img = "skadovsk.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Геническ осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 350, CityFromId = krivojRog.Id, CityToId = genichesk.Id, Img = "genichesk.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Одессу осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 400, CityFromId = krivojRog.Id, CityToId = odessa.Id, Img = "odessa.jpg" },
                    new Route { Id = Guid.NewGuid(), Description = "Сбор по городу по всем остановкам. Доставляем к месту отдыха по адресу. Выезд утром с 4:00 до 5:00. Точное время отправления сообщаем за день с 16:00 до 18:00. Выезд вечером с  21:00 до 23:00. Точное время отправления сообщаем в день отъезда с 14:00 до 16:00. Проезд в Харьков осуществляется комфортабельными 18-местными микроавтобусами Sprinter и 8-местными Vito. Мягкий салон, кондиционер, DVD.", Price = 250, CityFromId = krivojRog.Id, CityToId = harkiv.Id, Img = "kharkov.jpg" }
                );

            var manager1 = new Manager { Id = Guid.NewGuid(), Name = "Катя", SurName = "Титова", Login = "kate1990", NumberPhone = "0504582074", Password = "kate1", PasswordConfirm = "kate1" };
            var manager2 = new Manager { Id = Guid.NewGuid(), Name = "Алексей", SurName = "Шапошник", Login = "alex007", NumberPhone = "0671239060", Password = "alex123", PasswordConfirm = "alex123" };
            modelBuilder.Entity<Manager>()
                .HasData(manager1, manager2);


        }
    }
}
