﻿using MathQuestAPI.Data;
using MathQuestCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MathQuestAPI.Repository
{
    public class UtilisateurRepository : IRepository<Utilisateur>
    {
        private ApplicationDbContext _dbContext { get; }
        public UtilisateurRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Utilisateur utilisateur)
        {
            var addedObj = await _dbContext.Utilisateurs.AddAsync(utilisateur);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.UtilisateurId;
        }

        public async Task<bool> Delete(int id)
        {
            var utilisateur = await GetById(id);
            if (utilisateur == null)
                return false;
            _dbContext.Utilisateurs.Remove(utilisateur);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Utilisateur?> Get(Expression<Func<Utilisateur, bool>> predicate)
        {
            return await _dbContext.Utilisateurs.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Utilisateur>> GetAll()
        {
            return await _dbContext.Utilisateurs.ToListAsync();
        }

        public async Task<List<Utilisateur>> GetAll(Expression<Func<Utilisateur, bool>> predicate)
        {
            return await _dbContext.Utilisateurs.Where(predicate).ToListAsync();
        }

        public async Task<Utilisateur?> GetById(int id)
        {
            return await _dbContext.Utilisateurs.FindAsync(id);
        }

        public async Task<bool> Update(Utilisateur utilisateur)
        {
            var utilisateurFromDb = await GetById(utilisateur.UtilisateurId);

            if (utilisateurFromDb == null)
                return false;

            if (utilisateurFromDb.Pseudo != utilisateur.Pseudo)
                utilisateurFromDb.Pseudo = utilisateur.Pseudo;
            if (utilisateurFromDb.Score != utilisateur.Score)
                utilisateurFromDb.Score = utilisateur.Score;


            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
