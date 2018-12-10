using Ling.Data;
using Ling.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
        }

        //Read
        public async Task<List<Language>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetLanguage(int id)
        {
            return await _context.Languages.FirstOrDefaultAsync(lang => lang.ID == id);
        }

        //Update
        public async Task UpdateLanguage(Language language)
        {
            _context.Languages.Update(language);
            await _context.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteLanguage(int id)
        {
            Language language = await GetLanguage(id);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }
    }
}
