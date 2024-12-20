﻿// <auto-generated />
using HR_2024.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR_2024.Ef.Migrations
{
    [DbContext(typeof(AppCon))]
    partial class AppConModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HR_2024.Core.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("management_subid")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("management_subid");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("degree")
                        .HasColumnType("tinyint");

                    b.Property<byte>("eval")
                        .HasColumnType("tinyint");

                    b.Property<int>("id_emp")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("evaluations");
                });

            modelBuilder.Entity("HR_2024.Core.Model.GeneralManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("flag")
                        .HasColumnType("tinyint");

                    b.Property<string>("management_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GeneralManagements");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Management_Sub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Management_sub_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("generalManagementid")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("generalManagementid");

                    b.ToTable("Management_Subs");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Management_Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("departmentid")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<string>("unit_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("departmentid");

                    b.ToTable("Management_Units");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Tb_Help", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Helps");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Department", b =>
                {
                    b.HasOne("HR_2024.Core.Model.Management_Sub", "management_sub")
                        .WithMany("Departments")
                        .HasForeignKey("management_subid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("management_sub");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Management_Sub", b =>
                {
                    b.HasOne("HR_2024.Core.Model.GeneralManagement", "generalManagement")
                        .WithMany("management_sub")
                        .HasForeignKey("generalManagementid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("generalManagement");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Management_Unit", b =>
                {
                    b.HasOne("HR_2024.Core.Model.Department", "department")
                        .WithMany("management_Unit")
                        .HasForeignKey("departmentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Department", b =>
                {
                    b.Navigation("management_Unit");
                });

            modelBuilder.Entity("HR_2024.Core.Model.GeneralManagement", b =>
                {
                    b.Navigation("management_sub");
                });

            modelBuilder.Entity("HR_2024.Core.Model.Management_Sub", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
