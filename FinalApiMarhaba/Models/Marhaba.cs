namespace FinalApiMarhaba.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Marhaba : DbContext
    {
        // Your context has been configured to use a 'Marhaba' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalApiMarhaba.Models.Marhaba' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Marhaba' 
        // connection string in the application configuration file.
        public Marhaba()
            : base("name=Marhaba")
        {
        }
        public DbSet<Branch> Branshs { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealPic> DealPics { get; set; }
        public DbSet<Highlight> Highlights { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopCartOption> ShopCartOptions { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}