using Ling.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Data
{
    public class LingDbContext : DbContext
    {
        public LingDbContext(DbContextOptions<LingDbContext> options) : base(options)
        {

        }

        //Seed Language data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recording>().HasData(
                new Recording
                {
                    ID = 1,
                    LanguageID = 10,
                    FileName = "fr-sample.flac",
                    Transcription = "maître corbeau sur un arbre perché tenait en son bec un fromage"
                },
                new Recording
                {
                    ID = 2,
                    LanguageID = 2,
                    FileName = "those-internets.wav",
                    Transcription = ""
                }

            );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    ID = 1,
                    EnglishName = "Mandarin",
                    OriginalName = "官话",
                    Romanized = "Guānhuà",
                    ISOCode = "cmn-Hans-CN"
                },

                new Language
                {
                    ID = 2,
                    EnglishName = "English",
                    OriginalName = "English",
                    Romanized = null,
                    ISOCode = "en-US"
                },

                new Language
                {
                    ID = 3,
                    EnglishName = "Hindi",
                    OriginalName = "Hindī",
                    Romanized = "हिन्दी ",
                    ISOCode = "hi-IN"
                },

                new Language
                {
                    ID = 4,
                    EnglishName = "Spanish (Spain)",
                    OriginalName = "Español (España)",
                    Romanized = "español",
                    ISOCode = "es-ES"
                },

                new Language
                {
                    ID = 5,
                    EnglishName = "Spanish",
                    OriginalName = "Español",
                    Romanized = "español, castellano",
                    ISOCode = "es-MX"
                },

                new Language
                {
                    ID = 6,
                    EnglishName = "Arabic (Egypt)",
                    OriginalName = "العربية",
                    Romanized = "al-ʻarabiyyah",
                    ISOCode = "ar-EG"
                },

                new Language
                {
                    ID = 7,
                    EnglishName = "Portuguese (Brazil)",
                    OriginalName = "Português (Brasil)",
                    Romanized = "português",
                    ISOCode = "pt-BR"
                },

                new Language
                {
                    ID = 8,
                    EnglishName = "Russian",
                    OriginalName = "русский язык",
                    Romanized = "russkiy yazyk",
                    ISOCode = "ru-RU"
                },

                new Language
                {
                    ID = 9,
                    EnglishName = "Bengali",
                    OriginalName = "বাংলা",
                    Romanized = "Bangla",
                    ISOCode = "bn-IN"
                },

                new Language
                {
                    ID = 10,
                    EnglishName = "French",
                    OriginalName = "français",
                    Romanized = "français",
                    ISOCode = "fr-FR"
                },

                new Language
                {
                    ID = 11,
                    EnglishName = "Japanese",
                    OriginalName = "日本語",
                    Romanized = "Nihongo",
                    ISOCode = "ja-JP"
                },

                new Language
                {
                    ID = 12,
                    EnglishName = "Malay",
                    OriginalName = "بهاس ملايو‎",
                    Romanized = "Bahasa Melayu",
                    ISOCode = "ms-MY"
                });

        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Recording> Recordings { get; set; }
    }
}
