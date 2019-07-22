using System;
using System.Collections.Generic;
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

        public IEnumerable<CriteriaRank> GetCriteriaRanks()
        {
            return Context.CriteriaRanks.ToList();
        }

        public CriteriaRank GetCriteriaRankById(int CriteriaRankId)
        {
            return Context.CriteriaRanks.Find(CriteriaRankId);
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

        public void InsertCriteriaRank(CriteriaRank CriteriaRank)
        {
            Context.CriteriaRanks.Add(CriteriaRank);
            Context.SaveChanges();
        }

        public void DeleteCriteriaRank(int CriteriaRankId)
        {
            CriteriaRank criteriaRank = Context.CriteriaRanks.Find(CriteriaRankId);
            Context.CriteriaRanks.Remove(criteriaRank);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
