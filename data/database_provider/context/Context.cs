using Microsoft.EntityFrameworkCore;

public class TelegramBotContext : DbContext
{
    public TelegramBotContext() { }

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<ServicePrice> Service_price { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql(Secrets.DbReference);
    }
}