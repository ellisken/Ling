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


        /// <summary>
        /// Can Create a Language in the database
        /// </summary>
        [Fact]
        public async void CanCreateLangCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingCreateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                // Create
                Language lang = new Language();
                lang.EnglishName = "Dutch";
                lang.ISOCode = "uk-EUR";

                context.Languages.Add(lang);
                context.SaveChanges();

                var createdLang = await context.Languages.FirstOrDefaultAsync(x => x.EnglishName == lang.EnglishName);
                Assert.Equal("Dutch", createdLang.EnglishName);
            }
        }


        /// <summary>
        /// Can read a Language in the database
        /// </summary>
        [Fact]
        public async void CanReadLangCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingReadDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                Language lang = new Language();
                lang.EnglishName = "English";
                lang.ISOCode = "en-US";

                context.Languages.Add(lang);
                context.SaveChanges();

                var myLang = await context.Languages.FirstOrDefaultAsync(x => x.EnglishName == lang.EnglishName);
                Assert.Equal("en-US", myLang.ISOCode);
            }
        }


        /// <summary>
        /// Can update a Language in the database
        /// </summary>
        [Fact]
        public async void CanUpdateLangCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingUpdateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                Language lang = new Language();
                lang.EnglishName = "English";
                lang.ISOCode = "en-US";
                context.Languages.Add(lang);
                context.SaveChanges();
                lang.EnglishName = "Spanish";
                context.Languages.Update(lang);
                context.SaveChanges();

                var myLang = await context.Languages.FirstOrDefaultAsync(x => x.EnglishName == lang.EnglishName);
                Assert.Equal("Spanish", myLang.EnglishName);
            }
        }


        /// <summary>
        /// Can delete language from databases
        /// </summary>
        [Fact]
        public async void CanDeleteLangCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingUpdateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                Language lang = new Language();
                lang.EnglishName = "English";
                lang.ISOCode = "en-US";
                context.Languages.Add(lang);
                context.SaveChanges();
                var newLang = await context.Languages.FirstOrDefaultAsync(x => x.EnglishName == lang.EnglishName);
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

        /// <summary>
        /// Can Create a recording in the database
        /// </summary>
        [Fact]
        public async void CanCreateRecordingCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("RecordingCreateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                // Create
                Recording rec = new Recording();
                rec.Transcription = "English";
                rec.ID = 1;

                context.Recordings.Add(rec);
                context.SaveChanges();

                var myRec = await context.Recordings.FirstOrDefaultAsync(x => x.Transcription == rec.Transcription);
                Assert.Equal("English", myRec.Transcription);
            }
        }


        /// <summary>
        /// Can read a recording in the database
        /// </summary>
        [Fact]
        public async void CanReadRecordingCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("RecordingReadDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                // Read
                Recording rec = new Recording();
                rec.Transcription = "English";
                rec.ID = 1;

                context.Recordings.Add(rec);
                context.SaveChanges();

                var myRec = await context.Recordings.FirstOrDefaultAsync(x => x.Transcription == rec.Transcription);
                Assert.Equal(1, myRec.ID);
            }
        }


        /// <summary>
        /// Can update a recording in the database
        /// </summary>
        [Fact]
        public async void CanUpdateRecordingCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("RecordingUpdateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                Recording rec = new Recording();
                rec.Transcription = "English";
                rec.ID = 1;

                context.Recordings.Add(rec);
                context.SaveChanges();
                rec.Transcription = "Spanish";
                context.Recordings.Update(rec);
                context.SaveChanges();

                var newRecording = await context.Recordings.FirstOrDefaultAsync(l => l.Transcription == rec.Transcription);

                Assert.Equal("Spanish", newRecording.Transcription);
            }
        }


        /// <summary>
        /// Can delete recording from databases
        /// </summary>
        [Fact]
        public async void CanDeleteRecordingCRUDTest()
        {
            DbContextOptions<LingDbContext> options =
                new DbContextOptionsBuilder<LingDbContext>()
                .UseInMemoryDatabase("LingUpdateDBContex")
                .Options;

            using (LingDbContext context = new LingDbContext(options))
            {
                Recording rec = new Recording();
                rec.Transcription = "English";
                rec.ID = 1;

                context.Recordings.Add(rec);
                context.SaveChanges();
                var newRecording = await context.Recordings.FirstOrDefaultAsync(x => x.Transcription == rec.Transcription);
                context.Recordings.Remove(newRecording);
                context.SaveChanges();

                var deletedRecording = await context.Recordings.FirstOrDefaultAsync(l => l.Transcription == newRecording.Transcription);

                Assert.True(deletedRecording == null);
            }
        }
    }
}
