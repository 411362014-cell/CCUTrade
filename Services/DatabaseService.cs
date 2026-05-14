using CCUTrade.Data;

namespace CCUTrade.Services;

public static class DatabaseService
{
    public static void Initialize()
    {
        using var db = new AppDbContext();

        db.Database.EnsureCreated();
    }
}