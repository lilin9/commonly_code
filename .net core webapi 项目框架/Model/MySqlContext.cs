using Microsoft.EntityFrameworkCore;

namespace api.model; 

public class MySqlContext: DbContext {
    public MySqlContext() {
    }
    
    public MySqlContext(DbContextOptions<MySqlContext> options): base(options) {}
    
    public virtual DbSet<User> User { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseCollation("utf8_general_ci").HasCharSet("utf8");
        modelBuilder.Entity<User>(entity => {
            //指定表名
            entity.ToTable("sys_user");
            entity.Property(en => en.Id).ValueGeneratedOnAdd();
            entity.Property(en => en.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
        });
    }
}







