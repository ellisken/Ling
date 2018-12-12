using System;
using Xunit;
using Ling.Data;
using Ling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using Ling.Models.Services;
    

namespace LingTest
{
    public class LingCrudTest 
    {
        /// <summary>
        /// Can get user language
        /// </summary>
        [Fact]
        public void CanGetLanguage()
        {
            Language lang = new Language();
            lang.EnglishName = "English";
            Assert.Equal("English", lang.EnglishName);
        }


        /// <summary>
        /// Can set user language
        /// </summary>
        [Fact]
        public void CanSetLanguage()
        {
            Language lang = new Language();
            lang.EnglishName = "English";
            lang.EnglishName = "Spanish";
            Assert.Equal("Spanish", lang.EnglishName);
        }


        [Fact]
        public async void LanguageCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                // Create
                Language lang = new Language();
                lang.EnglishName = "English";
                lang.ISOCode = "en-US";

                context.Languages.Add(lang);
                context.SaveChanges();

                // Read
                var myLang = await context.Languages.FirstOrDefaultAsync(x => x.EnglishName == lang.EnglishName);

                Assert.Equal("English", myLang.EnglishName);

                // Update 
                myLang.EnglishName = "Spanish";
                context.Update(myLang);
                context.SaveChanges();

                var newLang = await context.Languages.FirstOrDefaultAsync(l => l.EnglishName == myLang.EnglishName);

                Assert.Equal("Spanish", newLang.EnglishName);

                // Delete
                context.Languages.Remove(newLang);
                context.SaveChanges();

                var deletedLang = await context.Languages.FirstOrDefaultAsync(l => l.EnglishName == newLang.EnglishName);

                Assert.True(deletedLang == null);
            }
        }

        /// <summary>
        /// Can get recording
        /// </summary>
        [Fact]
        public void CanGetRecording()
        {
            Recording rec = new Recording();
            rec.Transcription = "English";
            Assert.Equal("English", rec.Transcription);
        }


        /// <summary>
        /// Can set user recording
        /// </summary>
        [Fact]
        public void CanSetRecording()
        {
            Recording rec = new Recording();
            rec.Transcription = "English";
            rec.Transcription = "Spanish";
            Assert.Equal("Spanish", rec.Transcription);
        }


        [Fact]
        public async void RecordingCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("RecordingDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                // Create
                Recording rec = new Recording();
                rec.Transcription = "English";
                rec.ID = 1;

                context.Recordings.Add(rec);
                context.SaveChanges();

                // Read
                var myRecording = await context.Recordings.FirstOrDefaultAsync(x => x.Transcription == rec.Transcription);

                Assert.Equal("English", myRecording.Transcription);

                // Update 
                myRecording.Transcription = "Spanish";
                context.Update(myRecording);
                context.SaveChanges();

                var newRecording = await context.Recordings.FirstOrDefaultAsync(l => l.Transcription == myRecording.Transcription);

                Assert.Equal("Spanish", newRecording.Transcription);

                // Delete
                context.Recordings.Remove(newRecording);
                context.SaveChanges();

                var deletedRecording = await context.Recordings.FirstOrDefaultAsync(l => l.Transcription == newRecording.Transcription);

                Assert.True(deletedRecording == null);
            }
        }
    }
}
