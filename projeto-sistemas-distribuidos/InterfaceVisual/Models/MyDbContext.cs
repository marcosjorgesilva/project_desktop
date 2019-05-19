using System;
using BibliotecaComum.categoria;
using BibliotecaComum.produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InterfaceVisual.Models
{
    public partial class MyDbContext : DbContext
    {
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<LinkRolesMenus> LinkRolesMenus { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
		public virtual DbSet<Usuario> Usuario { get; set; }
		public virtual DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                    Para proteger informações confidenciais em sua seqüência de conexão, você deve removê-la
                    do código-fonte. Consulte http://go.microsoft.com/fwlink/?LinkId=723263 para obter orientação 
                    sobre como armazenar cadeias de conexão.                
                 */ 
                optionsBuilder.UseSqlServer("Server=localhost;User Id=dbomarcos;Password=#marcos;Database=MELOCHICOUT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.ToTable("admins");

                entity.HasIndex(e => e.RolesId)
                    .HasName("admins_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.RolesId)
                    .HasColumnName("roles_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("admins_ibfk_1");
            });

            modelBuilder.Entity<LinkRolesMenus>(entity =>
            {
                entity.ToTable("link_roles_menus");

                entity.HasIndex(e => e.MenusId)
                    .HasName("menus_id");

                entity.HasIndex(e => e.RolesId)
                    .HasName("roles_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenusId)
                    .HasColumnName("menus_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RolesId)
                    .HasColumnName("roles_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Menus)
                    .WithMany(p => p.LinkRolesMenus)
                    .HasForeignKey(d => d.MenusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("link_roles_menus_ibfk_1");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.LinkRolesMenus)
                    .HasForeignKey(d => d.RolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("link_roles_menus_ibfk_2");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.ToTable("menus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.IdProduto)
                    .HasColumnName("id_produto")
                    .HasColumnType("integer");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.ValorProduto)
                    .IsRequired()
                    .HasColumnName("valor_produto")
                    .HasColumnType("float");

                entity.Property(e => e.Estoque)
                    .IsRequired()
                    .HasColumnName("estoque")
                    .HasColumnType("integer");

                entity.Property(e => e.Tamanho)
                    .IsRequired()
                    .HasColumnName("tamanho")
                    .HasColumnType("nvarchar(3)");
        
            });
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("integer");

                entity.Property(e => e.TipoCategoria)
                    .IsRequired()
                    .HasColumnName("tipo_categoria")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.IdProduto)
                    .HasColumnName("id_produto")
                    .HasColumnType("integer");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Categorias)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("ForeignKey_Categoria_Produto");

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("integer");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("tipo_usuario")
                    .HasColumnType("nvarchar(3)");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.TelefoneCelular)
                    .IsRequired()
                    .HasColumnName("tel_celular")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.TelefoneFixo)
                    .IsRequired()
                    .HasColumnName("tel_fixo")
                    .HasColumnType("varchar(12)");

            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.IdEndereco)
                    .HasColumnName("id_endereco")
                    .HasColumnType("integer");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasColumnType("integer");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("nvarchar(2)");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasColumnType("integer");

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("integer");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("ForeignKey_Endereco_Produto");

            });
        }
    }
}
