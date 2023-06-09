﻿// <auto-generated />
using System;
using Big_Bang_assesment.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Big_Bang_assesment.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Big_Bang_assesment.Models.Guest", b =>
                {
                    b.Property<int>("Guest_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Guest_Id"));

                    b.Property<string>("Guest_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guest_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guest_pwd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Hotel_id")
                        .HasColumnType("int");

                    b.HasKey("Guest_Id");

                    b.HasIndex("Hotel_id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Hotel", b =>
                {
                    b.Property<int>("Hotel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hotel_id"));

                    b.Property<string>("Hotel_Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hotel_Phone")
                        .HasColumnType("int");

                    b.Property<string>("Hotel_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hotel_rating")
                        .HasColumnType("int");

                    b.HasKey("Hotel_id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Reservation", b =>
                {
                    b.Property<int>("Reservation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_Id"));

                    b.Property<DateTime>("Check_in")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_out")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Guest_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Room_Id")
                        .HasColumnType("int");

                    b.HasKey("Reservation_Id");

                    b.HasIndex("Guest_Id");

                    b.HasIndex("Room_Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Room", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_Id"));

                    b.Property<int?>("Hotel_id")
                        .HasColumnType("int");

                    b.Property<string>("Room_Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Room_Price")
                        .HasColumnType("int");

                    b.Property<int>("Room_availability")
                        .HasColumnType("int");

                    b.Property<string>("Room_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Room_Id");

                    b.HasIndex("Hotel_id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Guest", b =>
                {
                    b.HasOne("Big_Bang_assesment.Models.Hotel", null)
                        .WithMany("Guests")
                        .HasForeignKey("Hotel_id");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Reservation", b =>
                {
                    b.HasOne("Big_Bang_assesment.Models.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("Guest_Id");

                    b.HasOne("Big_Bang_assesment.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("Room_Id");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Room", b =>
                {
                    b.HasOne("Big_Bang_assesment.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("Hotel_id");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Big_Bang_assesment.Models.Hotel", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
