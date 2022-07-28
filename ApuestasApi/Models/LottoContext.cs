using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class LottoContext : DbContext
    {
        public LottoContext()
        {
        }

        public LottoContext(DbContextOptions<LottoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Animalwin> Animalwins { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Detailplay> Detailplays { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Methodpayment> Methodpayments { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<Probability> Probabilities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Range> Ranges { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Typegame> Typegames { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=Lotto;Port=5432;UserId=postgres;Password=moki-moki24");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.MethodId, "fki_method");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.MethodId).HasColumnName("method_id");

                entity.Property(e => e.NAccount)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("n_account");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.MethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("method");
            });

            modelBuilder.Entity<Animalwin>(entity =>
            {
                entity.ToTable("animalwin");

                entity.HasIndex(e => e.AnimalId, "fki_Animal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_Id");

                entity.Property(e => e.AnimalName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("animal_name");

                entity.Property(e => e.AnimalNumber)
                    .HasMaxLength(60)
                    .HasColumnName("Animal_Number");

                entity.Property(e => e.DateDay)
                    .HasColumnType("date")
                    .HasColumnName("date_day");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Animalwins)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("Animal");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Animalwins)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Schedule");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Animalwins)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TypeGame");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bills");

                entity.HasIndex(e => e.AccountId, "fki_Account");

                entity.HasIndex(e => e.PaymentId, "fki_Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.GrossAmount).HasColumnName("gross_amount");

                entity.Property(e => e.NetAmount).HasColumnName("net_amount");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PlayId).HasColumnName("play_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Client");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Payment");

                entity.HasOne(d => d.Play)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PlayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Play");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("document");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Detailplay>(entity =>
            {
                entity.ToTable("detailplays");

                entity.HasIndex(e => e.GameId, "fki_Game");

                entity.HasIndex(e => e.PlayId, "fki_Play");

                entity.HasIndex(e => e.TypeGameId, "fki_TypeGame");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.PlayId).HasColumnName("play_id");

                entity.Property(e => e.ProbabilityId).HasColumnName("probability_id");

                entity.Property(e => e.TypeGameId).HasColumnName("TypeGame_Id");

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");

                entity.Property(e => e.WinAmount).HasColumnName("win_amount");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Detailplays)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game");

                entity.HasOne(d => d.Play)
                    .WithMany(p => p.Detailplays)
                    .HasForeignKey(d => d.PlayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Play");

                entity.HasOne(d => d.Probability)
                    .WithMany(p => p.Detailplays)
                    .HasForeignKey(d => d.ProbabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Probability");

                entity.HasOne(d => d.TypeGame)
                    .WithMany(p => p.Detailplays)
                    .HasForeignKey(d => d.TypeGameId)
                    .HasConstraintName("TypeGame");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.ToTable("estatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.HasIndex(e => e.ProbabilityId, "fki_Probability");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.ProbabilityId).HasColumnName("probability_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Probability)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.ProbabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Probability");
            });

            modelBuilder.Entity<Methodpayment>(entity =>
            {
                entity.ToTable("methodpayment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.BillId, "fki_Bills");

                entity.HasIndex(e => e.ClientId, "fki_Client");

                entity.HasIndex(e => e.MethodId, "fki_Method");

                entity.HasIndex(e => e.ClientId, "fki_User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BillId).HasColumnName("bill_id");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.MethodId).HasColumnName("method_id");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bills");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Client");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Method");
            });

            modelBuilder.Entity<Play>(entity =>
            {
                entity.ToTable("plays");

                entity.HasIndex(e => e.ScheduleId, "fki_Schedule");

                entity.HasIndex(e => e.ClientId, "fki_Users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.WinAmount).HasColumnName("win_amount");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Client");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Schedule");
            });

            modelBuilder.Entity<Probability>(entity =>
            {
                entity.ToTable("probability");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.ProbabilityId, "fki_Probabilidad");

                entity.HasIndex(e => e.GameId, "fki_j");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("number");

                entity.Property(e => e.ProbabilityId).HasColumnName("probability_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game");

                entity.HasOne(d => d.Probability)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProbabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Probability");
            });

            modelBuilder.Entity<Range>(entity =>
            {
                entity.ToTable("range");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estatus)
                    .HasColumnName("estatus")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.GameDate)
                    .HasColumnType("date")
                    .HasColumnName("game_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Hour)
                    .HasColumnType("time without time zone")
                    .HasColumnName("hour");
            });

            modelBuilder.Entity<Typegame>(entity =>
            {
                entity.ToTable("typegame");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Typegames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.RangeId, "fki_rango");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("document");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RangeId)
                    .HasColumnName("range_id")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Range)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("range");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
