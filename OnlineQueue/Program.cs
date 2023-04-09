using Infrastructure.Persistence;

class Program
{
    static void Main(string[] args)
    {
       DbContext dbContext = new DbContext();
        //dbContext.CreateDb();
        dbContext.InitializeTables();
    }
}