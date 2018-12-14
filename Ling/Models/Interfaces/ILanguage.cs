using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Models.Interfaces
{
    public interface ILanguage
    {
        //Create
        Task AddLanguage(Language language);

        //Read
        Task<List<Language>> GetLanguages();
        Task<Language> GetLanguage(int id);
        Task<Language> GetLanguage(string isoCode);

        //Update
        Task UpdateLanguage(Language language);

        //Delete
        Task DeleteLanguage(int id);
    }
}
