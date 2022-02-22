using Microsoft.EntityFrameworkCore;
using moment32.Models;
using System;

namespace moment32.Data{
    // DbContext class
    public class RecordContext : DbContext {
        public RecordContext(DbContextOptions<RecordContext> options) : base(options){

        }
        public DbSet<Artist>? Artist { get; set; }
        public DbSet<Record>? Record { get; set; }
        public DbSet<Renting>? Renting { get; set; }
        public DbSet<Song>? Song { get; set; }
        public DbSet<User>? User { get; set; }
    }
}