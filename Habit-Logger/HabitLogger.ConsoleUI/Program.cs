using HabitLogger.Application.Service;
using HabitLogger.Infrastructure.Database;

var factory = new DbConnectionFactory("Data Source=habits.db");

new DatabaseInitializer(factory).Initalize();
new DatabaseSeeder(factory).Seed();