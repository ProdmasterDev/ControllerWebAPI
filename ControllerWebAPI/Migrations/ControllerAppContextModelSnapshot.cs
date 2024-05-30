﻿// <auto-generated />
using System;
using ControllerWebAPI.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    [DbContext(typeof(ControllerAppContext))]
    partial class ControllerAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ControllerDomain.Entities.Access", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ControllerLocationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateBlock")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Enterance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Exit")
                        .HasColumnType("boolean");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ControllerLocationId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccessGroup");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessGroupAccess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("ControllerLocationId")
                        .HasColumnType("integer");

                    b.Property<bool>("Enterance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Exit")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AccessGroupId");

                    b.HasIndex("ControllerLocationId");

                    b.ToTable("AccessGroupAccess");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccessMethods");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("CardNumb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumb16")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Controller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("ComFwVer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ControllerLocationId")
                        .HasColumnType("integer");

                    b.Property<string>("FwVer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastPing")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastPowerOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Sn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ControllerLocationId")
                        .IsUnique();

                    b.ToTable("Controllers");
                });

            modelBuilder.Entity("ControllerDomain.Entities.ControllerLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ControllerLocations");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ControllerId")
                        .HasColumnType("integer");

                    b.Property<int>("ControllerLocationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Create")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Flag")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ControllerId");

                    b.HasIndex("ControllerLocationId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ControllerDomain.Entities.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("ControllerDomain.Entities.GroupAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ControllerLocationId")
                        .HasColumnType("integer");

                    b.Property<bool>("Enterance")
                        .HasColumnType("boolean");

                    b.Property<bool>("Exit")
                        .HasColumnType("boolean");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ControllerLocationId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupAccesses");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ControllerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Create")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Flag")
                        .HasColumnType("integer");

                    b.Property<bool>("IsComplited")
                        .HasColumnType("boolean");

                    b.Property<int>("OperationId")
                        .HasColumnType("integer");

                    b.Property<int>("Tz")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ControllerId");

                    b.HasIndex("OperationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ControllerDomain.Entities.MessageCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageCards");
                });

            modelBuilder.Entity("ControllerDomain.Entities.MessageOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OperationCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MessageOperations");
                });

            modelBuilder.Entity("ControllerDomain.Entities.QuickAccess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateBlock")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Granted")
                        .HasColumnType("integer");

                    b.Property<int>("Reader")
                        .HasColumnType("integer");

                    b.Property<string>("Sn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuickAccess");
                });

            modelBuilder.Entity("ControllerDomain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccessMethodId")
                        .HasColumnType("integer");

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateBlock")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DisanId")
                        .HasColumnType("integer");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccessMethodId");

                    b.HasIndex("GroupId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("ControllerDomain.Entities.WorkerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Arch")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkerGroups");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Access", b =>
                {
                    b.HasOne("ControllerDomain.Entities.ControllerLocation", "ControllerLocation")
                        .WithMany("Accesses")
                        .HasForeignKey("ControllerLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.Worker", "Worker")
                        .WithMany("Accesses")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ControllerLocation");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessGroupAccess", b =>
                {
                    b.HasOne("ControllerDomain.Entities.AccessGroup", "AccessGroup")
                        .WithMany("Accesses")
                        .HasForeignKey("AccessGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.ControllerLocation", "ControllerLocation")
                        .WithMany("AccessGroupAccesses")
                        .HasForeignKey("ControllerLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessGroup");

                    b.Navigation("ControllerLocation");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Card", b =>
                {
                    b.HasOne("ControllerDomain.Entities.Worker", "Worker")
                        .WithMany("Cards")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Controller", b =>
                {
                    b.HasOne("ControllerDomain.Entities.ControllerLocation", "ControllerLocation")
                        .WithOne("Controller")
                        .HasForeignKey("ControllerDomain.Entities.Controller", "ControllerLocationId");

                    b.Navigation("ControllerLocation");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Event", b =>
                {
                    b.HasOne("ControllerDomain.Entities.Controller", null)
                        .WithMany("Events")
                        .HasForeignKey("ControllerId");

                    b.HasOne("ControllerDomain.Entities.ControllerLocation", "ControllerLocation")
                        .WithMany("Events")
                        .HasForeignKey("ControllerLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.Worker", "Worker")
                        .WithMany("Events")
                        .HasForeignKey("WorkerId");

                    b.Navigation("ControllerLocation");

                    b.Navigation("EventType");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ControllerDomain.Entities.GroupAccess", b =>
                {
                    b.HasOne("ControllerDomain.Entities.ControllerLocation", "ControllerLocation")
                        .WithMany("GroupAccesses")
                        .HasForeignKey("ControllerLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.WorkerGroup", "Group")
                        .WithMany("GroupAccess")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ControllerLocation");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Message", b =>
                {
                    b.HasOne("ControllerDomain.Entities.Controller", "Controller")
                        .WithMany()
                        .HasForeignKey("ControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.MessageOperation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Controller");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("ControllerDomain.Entities.MessageCard", b =>
                {
                    b.HasOne("ControllerDomain.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControllerDomain.Entities.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Worker", b =>
                {
                    b.HasOne("ControllerDomain.Entities.AccessMethod", "AccessMethod")
                        .WithMany("Workers")
                        .HasForeignKey("AccessMethodId");

                    b.HasOne("ControllerDomain.Entities.WorkerGroup", "Group")
                        .WithMany("Workers")
                        .HasForeignKey("GroupId");

                    b.Navigation("AccessMethod");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessGroup", b =>
                {
                    b.Navigation("Accesses");
                });

            modelBuilder.Entity("ControllerDomain.Entities.AccessMethod", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Controller", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ControllerDomain.Entities.ControllerLocation", b =>
                {
                    b.Navigation("AccessGroupAccesses");

                    b.Navigation("Accesses");

                    b.Navigation("Controller");

                    b.Navigation("Events");

                    b.Navigation("GroupAccesses");
                });

            modelBuilder.Entity("ControllerDomain.Entities.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ControllerDomain.Entities.Worker", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("Cards");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("ControllerDomain.Entities.WorkerGroup", b =>
                {
                    b.Navigation("GroupAccess");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
