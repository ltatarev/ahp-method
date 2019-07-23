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
	class AlternativeRepository : IAlternativeRepository
	{
        //Body of class

        #region Constructor

            public AlternativeRepository(AHPContext context)
        {
            this.Context = context;
        }

        #endregion Constructor

        #region Properties

        //Context was protected

        private AHPContext Context { get; set; }

        #endregion Properties

        #region Methods

        //Methods for Alternative class

        public async Task<List<Alternative>> GetAlternativesAsync()
        {
            return await Context.Alternatives.ToListAsync();
        }

        public async Task<Alternative> GetAlternativeByIdAsync(int AlternativeId)
        {
            return await Context.Alternatives.FindAsync(AlternativeId);
        }

        //Method for cheching if Alternative is form specific project

        public async void GetAlternativeByProjectIdAsync(int ProjectId)
        {

            Project projectId = await Context.Projects.FindAsync(ProjectId);
            Alternative alternativeProjectId = await Context.Alternatives.FindAsync(ProjectId);

            // project.Equals(criteriaProjectId); -- checks if objects are same

            if (projectId.Equals(alternativeProjectId))
            {
                await Context.Criterias.FindAsync(alternativeProjectId);
            }
        }

        public void InsertAlternative(Alternative alternative)
        {
            Context.Alternatives.Add(alternative);
            Context.SaveChanges();
        }

        public async void DeleteAlternativeAsync(int AlternativeId)
        {
            Alternative alternative = await Context.Alternatives.FindAsync(AlternativeId);
            Context.Alternatives.Remove(alternative);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
