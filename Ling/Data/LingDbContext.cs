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
                    ISOCode = "cmn-hans-cn"
                },

                new Language
                {
                    ID = 2,
                    EnglishName = "English",
                    OriginalName = "English",
                    Romanized = null,
                    ISOCode = "en-us"
                },

                new Language
                {
                    ID = 3,
                    EnglishName = "Hindi",
                    OriginalName = "Hindī",
                    Romanized = "हिन्दी ",
                    ISOCode = "hi-in"
                },

                new Language
                {
                    ID = 4,
                    EnglishName = "Spanish (Spain)",
                    OriginalName = "Español (España)",
                    Romanized = "español",
                    ISOCode = "es-es"
                },

                new Language
                {
                    ID = 5,
                    EnglishName = "Spanish",
                    OriginalName = "Español",
                    Romanized = "español, castellano",
                    ISOCode = "es-mx"
                },

                new Language
                {
                    ID = 6,
                    EnglishName = "Arabic (Egypt)",
                    OriginalName = "العربية",
                    Romanized = "al-ʻarabiyyah",
                    ISOCode = "ar-eg"
                },

                new Language
                {
                    ID = 7,
                    EnglishName = "Portuguese (Brazil)",
                    OriginalName = "Português (Brasil)",
                    Romanized = "português",
                    ISOCode = "pt-br"
                },

                new Language
                {
                    ID = 8,
                    EnglishName = "Russian",
                    OriginalName = "русский язык",
                    Romanized = "russkiy yazyk",
                    ISOCode = "ru-ru"
                },

                new Language
                {
                    ID = 9,
                    EnglishName = "Bengali",
                    OriginalName = "বাংলা",
                    Romanized = "Bangla",
                    ISOCode = "bn-in"
                },

                new Language
                {
                    ID = 10,
                    EnglishName = "French",
                    OriginalName = "français",
                    Romanized = "français",
                    ISOCode = "fr-fr"
                },

                new Language
                {
                    ID = 11,
                    EnglishName = "Japanese",
                    OriginalName = "日本語",
                    Romanized = "Nihongo",
                    ISOCode = "ja-jp"
                },

                new Language
                {
                    ID = 12,
                    EnglishName = "Malay",
                    OriginalName = "بهاس ملايو‎",
                    Romanized = "Bahasa Melayu",
                    ISOCode = "ms-my"
                }, 

                new Language
                {
                    ID = 13,
                    EnglishName = "Swahili",
                    OriginalName = "Kiswahili‎",
                    Romanized = "Kiswahili",
                    ISOCode = "sw-ke"
                },

                new Language
                {
                    ID = 14,
                    EnglishName = "German",
                    OriginalName = "Deutsch‎",
                    Romanized = "Deutsch",
                    ISOCode = "de-de"
                },
                new Language
                {
                    ID = 15,
                    EnglishName = "Polish",
                    OriginalName = "‎Polski",
                    Romanized = "Polski",
                    ISOCode = "pl-pl"
                });

        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Recording> Recordings { get; set; }
    }
}
