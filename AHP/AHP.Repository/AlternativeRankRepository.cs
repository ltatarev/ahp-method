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

        //Methods in interface needs to be initialized

        public IEnumerable<AlternativeRank> GetAlternativeRanks()
        {
            return Context.AlternativeRanks.ToList();
        }

        public AlternativeRank GetAlternativeRankById(int AlternativeRankId)
        {
            return Context.AlternativeRanks.Find(AlternativeRankId);
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

        public void InsertAlternativeRank(AlternativeRank AlternativeRank)
        {
            Context.AlternativeRanks.Add(AlternativeRank);
            //    Context.SaveChanges();
        }

        public void DeleteAlternativeRank(int AlternativeRankId)
        {
            AlternativeRank alternativeRank = Context.AlternativeRanks.Find(AlternativeRankId);
            Context.AlternativeRanks.Remove(alternativeRank);
            //   Context.SaveChanges();
        }

        #endregion Methods
    }
}
