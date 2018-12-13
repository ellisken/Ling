using Ling.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<Language> languages = new List<Language>();
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/country_seed_data.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                languages.Add(new Language
                {
                    ID = i,
                    EnglishName = fields[2],
                    OriginalName = fields[1],
                    ISOCode = fields[0]
                });
            }

            foreach (Language l in languages)
            {
                modelBuilder.Entity<Language>().HasData(l);
            }


            modelBuilder.Entity<Recording>().HasData(
                new Recording
                {
                    ID = 1,
                    LanguageID = 11,
                    FileName = "fr-sample.flac",
                    URI = "https://lingblob.blob.core.windows.net/soundrecording/fr-sample.flac",
                    Transcription = "maître corbeau sur un arbre perché tenait en son bec un fromage"
                },
                new Recording
                {
                    ID = 2,
                    LanguageID = 6,
                    URI = "https://lingblob.blob.core.windows.net/soundrecording/those-internets.wav",
                    FileName = "those-internets.wav",
                    Transcription = ""
                },
                new Recording
                {
                    ID = 3,
                    LanguageID = 4,
                    URI = "https://lingblob.blob.core.windows.net/soundrecording/sod.wav",
                    FileName = "sod.wav",
                    Transcription = "you silly sod"
                }
            );
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Recording> Recordings { get; set; }
    }
}
