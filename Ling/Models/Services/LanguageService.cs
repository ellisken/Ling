using Ling.Data;
using Ling.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Models.Services
{
    public class LanguageService : ILanguage
    {
        private LingDbContext _context;

        public LanguageService(LingDbContext context)
        {
            _context = context;
        }

        //Create
        /// <summary>
        /// Adds a new language entry to the Language table
        /// </summary>C:\Users\curtl\source\repos\Ling\Ling\Models\Services\LanguageService.cs
        /// <param name="language">Completed task</param>
        /// <returns></returns>
        public async Task AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
        }

        //Read
        /// <summary>
        /// Gets and returns a list of all Language entries in the database
        /// </summary>
        /// <returns>A list of all Language entries</returns>
        public async Task<List<Language>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        /// <summary>
        /// Gets and returns a Language entry by ID
        /// </summary>
        /// <param name="id">The language's ID</param>
        /// <returns>The language with the given ID</returns>
        public async Task<Language> GetLanguage(int id)
        {
            return await _context.Languages.FirstOrDefaultAsync(lang => lang.ID == id);
        }

        //Update
        /// <summary>
        /// Updates and saves a language entry
        /// </summary>
        /// <param name="language">The language entry to update</param>
        /// <returns>Completed task</returns>
        public async Task UpdateLanguage(Language language)
        {
            _context.Languages.Update(language);
            await _context.SaveChangesAsync();
        }

        //Delete
        /// <summary>
        /// Deletes a language entry by ID
        /// </summary>
        /// <param name="id">ID of the language entry to delete</param>
        /// <returns>Completed task</returns>
        public async Task DeleteLanguage(int id)
        {
            Language language = await GetLanguage(id);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="isoCode">The iso code.</param>
        /// <returns></returns>
        public async Task<Language> GetLanguage(string isoCode)
        {
            Language lang = await _context.Languages.FirstOrDefaultAsync(x => x.ISOCode.ToLower() == isoCode);
            if (lang == null)
            {
                string s = isoCode.Split('-')[0];
                lang = await _context.Languages.Where(x => x.ISOCode.ToLower().StartsWith(s)).FirstOrDefaultAsync();
            }
            return lang;
        }
    }
}
