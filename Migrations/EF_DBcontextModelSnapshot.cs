﻿// <auto-generated />
using API_6._0_2.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_6._0_2.Migrations
{
    [DbContext(typeof(EF_DBcontext))]
    partial class EF_DBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_6._0_2.DBcontext.Huyen", b =>
                {
                    b.Property<int>("Hid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Hid"));

                    b.Property<string>("Hdes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Hname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tid")
                        .HasColumnType("integer");

                    b.HasKey("Hid");

                    b.HasIndex("Tid");

                    b.ToTable("Huyen");
                });

            modelBuilder.Entity("API_6._0_2.DBcontext.Tinh", b =>
                {
                    b.Property<int>("Tid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Tid"));

                    b.Property<string>("Tdes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Tid");

                    b.ToTable("Tinh");
                });

            modelBuilder.Entity("API_6._0_2.DBcontext.Xa", b =>
                {
                    b.Property<int>("Xid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Xid"));

                    b.Property<int>("Hid")
                        .HasColumnType("integer");

                    b.Property<string>("Xdes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Xname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Xid");

                    b.HasIndex("Hid");

                    b.ToTable("Xa");
                });

            modelBuilder.Entity("API_6._0_2.DBcontext.Huyen", b =>
                {
                    b.HasOne("API_6._0_2.DBcontext.Tinh", "Tinh")
                        .WithMany()
                        .HasForeignKey("Tid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tinh");
                });

            modelBuilder.Entity("API_6._0_2.DBcontext.Xa", b =>
                {
                    b.HasOne("API_6._0_2.DBcontext.Huyen", "Huyen")
                        .WithMany()
                        .HasForeignKey("Hid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Huyen");
                });
#pragma warning restore 612, 618
        }
    }
}
