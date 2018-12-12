﻿// <auto-generated />
using Ling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ling.Migrations
{
    [DbContext(typeof(LingDbContext))]
    [Migration("20181212192455_addURI")]
    partial class addURI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ling.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnglishName");

                    b.Property<string>("ISOCode");

                    b.Property<string>("OriginalName");

                    b.Property<string>("Romanized");

                    b.HasKey("ID");

                    b.ToTable("Languages");

                    b.HasData(
                        new { ID = 1, EnglishName = "Mandarin", ISOCode = "cmn-hans-cn", OriginalName = "官话", Romanized = "Guānhuà" },
                        new { ID = 2, EnglishName = "English", ISOCode = "en-us", OriginalName = "English" },
                        new { ID = 3, EnglishName = "Hindi", ISOCode = "hi-in", OriginalName = "Hindī", Romanized = "हिन्दी " },
                        new { ID = 4, EnglishName = "Spanish (Spain)", ISOCode = "es-es", OriginalName = "Español (España)", Romanized = "español" },
                        new { ID = 5, EnglishName = "Spanish", ISOCode = "es-mx", OriginalName = "Español", Romanized = "español, castellano" },
                        new { ID = 6, EnglishName = "Arabic (Egypt)", ISOCode = "ar-eg", OriginalName = "العربية", Romanized = "al-ʻarabiyyah" },
                        new { ID = 7, EnglishName = "Portuguese (Brazil)", ISOCode = "pt-br", OriginalName = "Português (Brasil)", Romanized = "português" },
                        new { ID = 8, EnglishName = "Russian", ISOCode = "ru-ru", OriginalName = "русский язык", Romanized = "russkiy yazyk" },
                        new { ID = 9, EnglishName = "Bengali", ISOCode = "bn-in", OriginalName = "বাংলা", Romanized = "Bangla" },
                        new { ID = 10, EnglishName = "French", ISOCode = "fr-fr", OriginalName = "français", Romanized = "français" },
                        new { ID = 11, EnglishName = "Japanese", ISOCode = "ja-jp", OriginalName = "日本語", Romanized = "Nihongo" },
                        new { ID = 12, EnglishName = "Malay", ISOCode = "ms-my", OriginalName = "بهاس ملايو‎", Romanized = "Bahasa Melayu" },
                        new { ID = 13, EnglishName = "Swahili", ISOCode = "sw-ke", OriginalName = "Kiswahili‎", Romanized = "Kiswahili" },
                        new { ID = 14, EnglishName = "German", ISOCode = "de-de", OriginalName = "Deutsch‎", Romanized = "Deutsch" },
                        new { ID = 15, EnglishName = "Polish", ISOCode = "pl-pl", OriginalName = "‎Polski", Romanized = "Polski" }
                    );
                });

            modelBuilder.Entity("Ling.Models.Recording", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Transcription");

                    b.Property<string>("URI");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Recordings");

                    b.HasData(
                        new { ID = 1, FileName = "fr-sample.flac", LanguageID = 10, Transcription = "maître corbeau sur un arbre perché tenait en son bec un fromage" },
                        new { ID = 2, FileName = "those-internets.wav", LanguageID = 2, Transcription = "" }
                    );
                });

            modelBuilder.Entity("Ling.Models.Recording", b =>
                {
                    b.HasOne("Ling.Models.Language", "Language")
                        .WithMany("Recordings")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
