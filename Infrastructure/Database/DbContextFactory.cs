//using Infrastructure.Database; // Adjust the namespace as needed
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;

//public class DbContextFactory : IDesignTimeDbContextFactory<EcomOrderDDDContext>
//{
//    public EcomOrderDDDContext CreateDbContext(string[] args)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()  
//           .Build();

//        var builder = new DbContextOptionsBuilder<EcomOrderDDDContext>();
//        var connectionString = configuration.GetConnectionString("Data Source=desktop-5jalk0g;Initial Catalog=EcomOrderDDD;Integrated Security=True;Pooling=False");
//        builder.UseSqlServer(connectionString);

//        return new EcomOrderDDDContext(builder.Options);
//    }
//}
