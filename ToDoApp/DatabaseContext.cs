using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseModel")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<DatabaseContext>(modelBuilder));
        }

        public virtual DbSet<TaskEntity> Tasks { get; set; }
    }
}
