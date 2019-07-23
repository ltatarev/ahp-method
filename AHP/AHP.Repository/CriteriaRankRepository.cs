using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.DAL.Entities;
using AHP.Model;
using AHP.Model.Common;
using AHP.Repository.Common;

namespace AHP.Repository
{
    class CriteriaRankRepository : ICriteriaRankRepository
    {
        //Body of class

        #region Constructor

            public CriteriaRankRepository(AHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods

        //Methods for CriteriaRank class

        public async Task<List<CriteriaRank>> GetCriteriaRanksAsync()
        {
            return await Context.CriteriaRanks.ToListAsync();
        }

        public async Task<CriteriaRank> GetCriteriaRankByIdAsync(int CriteriaRankId)
        {
            return await Context.CriteriaRanks.FindAsync(CriteriaRankId);
        }

        //Method for cheching if projectId in criteria is same as projectId in project

        //public void GetAlternativeByProjectId(int ProjectId)
        //{

        //    Project projectId = Context.Projects.Find(ProjectId);
        //    Alternative alternativeProjectId = Context.Alternatives.Find(ProjectId);

        //    // project.Equals(criteriaProjectId); -- checks if objects are same

        //    if (projectId.Equals(alternativeProjectId))
        //    {
        //        Context.Criterias.Find(alternativeProjectId);
        //    }
        //}

        public async void InsertCriteriaRankAsync(CriteriaRank CriteriaRank)
        {
            Context.CriteriaRanks.Add(CriteriaRank);
            await Context.SaveChangesAsync();
        }

        public async void DeleteCriteriaRankAsync(int CriteriaRankId)
        {
            CriteriaRank criteriaRank = await Context.CriteriaRanks.FindAsync(CriteriaRankId);
            Context.CriteriaRanks.Remove(criteriaRank);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
