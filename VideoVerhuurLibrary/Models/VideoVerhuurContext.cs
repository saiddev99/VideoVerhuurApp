using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurLibrary.Models;
public class VideoVerhuurContext: DbContext
{
    public VideoVerhuurContext() { }
    public VideoVerhuurContext(DbContextOptions options) : base(options) { }
    public DbSet<Verhuur> Verhuringen { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Genre> Genres { get; set; }
}
