using MathQuestAPI.Data;
using MathQuestCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MathQuestAPI.Repository
{
    public class LeconRepository : IRepository<Lecon>
    {
        private ApplicationDbContext _dbContext { get; }
        public LeconRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Lecon lecon)
        {
            var addedObj = await _dbContext.Lecons.AddAsync(lecon);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.LeconId;
        }

        public async Task<bool> Delete(int id)
        {
            var lecon = await GetById(id);
            if (lecon == null)
                return false;
            _dbContext.Lecons.Remove(lecon);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Lecon?> Get(Expression<Func<Lecon, bool>> predicate)
        {
            return await _dbContext.Lecons.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Lecon>> GetAll()
        {
            return await _dbContext.Lecons.ToListAsync();
        }

        public async Task<List<Lecon>> GetAll(Expression<Func<Lecon, bool>> predicate)
        {
            return await _dbContext.Lecons.Where(predicate).ToListAsync();
        }

        public async Task<Lecon?> GetById(int id)
        {
            return await _dbContext.Lecons.FindAsync(id);
        }

        public async Task<bool> Update(Lecon lecon)
        {
            var leconFromDb = await GetById(lecon.LeconId);

            if (leconFromDb == null)
                return false;

            if (leconFromDb.Titre != lecon.Titre)
                leconFromDb.Titre = lecon.Titre;
            if (leconFromDb.Contenu != lecon.Contenu)
                leconFromDb.Contenu = lecon.Contenu;


            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
