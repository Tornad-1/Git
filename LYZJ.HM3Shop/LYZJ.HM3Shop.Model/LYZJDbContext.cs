using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace LYZJ.HM3Shop.Model
{
    public class LYZJDbContext:DbContext
    {
        public LYZJDbContext()
           : base("name=DefaultConnection")
        {
            base.Database.CreateIfNotExists();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var s = Assembly.GetExecutingAssembly().FullName;
            //modelBuilder.Configurations.AddFromAssembly()表示从指定程序集中加载所有继承自EntityTypeConfiguration<>的类到配置中
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly());
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<ActionGroup> ActionGroup { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<GoodInfo> GoodInfo { get; set; }
        public DbSet<GoodSKU> GoodSKU { get; set; }
        public DbSet<GoodsPropValue> GoodsPropValue { get; set; }
        public DbSet<ImageInfo> ImageInfo { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropOption> PropOption { get; set; }
        public DbSet<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public DbSet<R_UserInfo_Role> R_UserInfo_Role { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<实体1> 实体1集 { get; set; }
    }
}

