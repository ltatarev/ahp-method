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
	class AlternativeRankRepository : IAlternativeRankRepository
	{
        //Body of class

        #region Constructor

            public AlternativeRankRepository(AHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods

        //Methods for AlternativeRank class

        public async Task<List<AlternativeRank>> GetAlternativeRanksAsync()
        {
            return await Context.AlternativeRanks.ToListAsync();
        }

        public async Task<AlternativeRank> GetAlternativeRankByIdAsync(int AlternativeRankId)
        {
            return await Context.AlternativeRanks.FindAsync(AlternativeRankId);
        }

        //Method for cheching if projectId in criteria is same as projectId in project

     //   public void GetAlternativeByProjectId(int ProjectId)
     //   {
     //
     //       Project projectId = Context.Projects.Find(ProjectId);
     //       Alternative alternativeProjectId = Context.Alternatives.Find(ProjectId);
     //
     //       // project.Equals(criteriaProjectId); -- checks if objects are same
     //
     //       if (projectId.Equals(alternativeProjectId))
     //       {
     //          Context.Criterias.Find(alternativeProjectId);
     //       }
     //   }

        public void InsertAlternativeRank(AlternativeRank AlternativeRank)
        {
            Context.AlternativeRanks.Add(AlternativeRank);
            Context.SaveChanges();
        }

        public async void DeleteAlternativeRankAsync(int AlternativeRankId)
        {
            AlternativeRank alternativeRank = await Context.AlternativeRanks.FindAsync(AlternativeRankId);
            Context.AlternativeRanks.Remove(alternativeRank);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
