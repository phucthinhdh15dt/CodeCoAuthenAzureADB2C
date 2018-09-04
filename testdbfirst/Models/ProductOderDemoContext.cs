using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testdbfirst.Models
{
    public partial class ProductOderDemoContext : DbContext
    {
        public ProductOderDemoContext()
        {
        }

        public ProductOderDemoContext(DbContextOptions<ProductOderDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<RefProductCategories> RefProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=projectcuoiky.database.windows.net;Database=project;User Id=phucthinh97@projectcuoiky;Password=Thinh1997;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("customer_address")
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customer_email")
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerLogin)
                    .HasColumnName("customer_login")
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerPassword)
                    .HasColumnName("customer_password")
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerPhone).HasColumnName("customer_phone");

                entity.Property(e => e.OthorCustomerDetails)
                    .HasColumnName("othor_customer_details")
                    .HasMaxLength(200);

                entity.Property(e => e.PaymentMethodCode)
                    .HasColumnName("payment_method_code")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Customer_Orders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasMaxLength(200);

                entity.Property(e => e.OderPlaceDatatime)
                    .HasColumnName("oder_place_datatime")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderDeliveDatatime)
                    .HasColumnName("order_delive_datatime")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderShoppingCharges)
                    .HasColumnName("order_shopping_charges")
                    .HasMaxLength(200);

                entity.Property(e => e.OrderStatusCode)
                    .HasColumnName("order_status_code")
                    .HasMaxLength(200);

                entity.Property(e => e.OtherOrtherDetails)
                    .HasColumnName("other_orther_details")
                    .HasMaxLength(200);

                entity.Property(e => e.ShippingMethodCode)
                    .HasColumnName("shipping_method_code")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Customer___custo__5165187F");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Iditem);

                entity.ToTable("Order_Item");

                entity.Property(e => e.Iditem).HasColumnName("iditem");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(200);

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Order_Ite__order__534D60F1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Order_Ite__produ__52593CB8");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_id")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.OtherProductDetails)
                    .HasColumnName("other_product_details")
                    .HasMaxLength(200);

                entity.Property(e => e.ProductCategoryCode)
                    .HasColumnName("Product_category_code")
                    .HasMaxLength(200);

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(200);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("Product_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.ProductCategoryCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Product__Product__5441852A");
            });

            modelBuilder.Entity<RefProductCategories>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryCode);

                entity.ToTable("Ref_Product_Categories");

                entity.Property(e => e.ProductCategoryCode)
                    .HasColumnName("product_category_code")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductCategoryDescription)
                    .HasColumnName("product_category_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
