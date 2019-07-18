using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL;
using AHP.Model;
using AHP.Model.Common;
using AHP.Repository.Common;


namespace AHP.Repository
{
    public class AhpRepository : IAhpRepository
    {
        
        #region Constructor

            public AhpRepository(IAhpContext context)
        {
            this.context = context;
        }

        #endregion Constructor

        #region Properties

        protected IAhpContext Context { get; private set }

        #endregion Properties

        #region Methods

        //Only methods

        public bool AddCriteria(int criteriaId)
        {
            //Adding criteria

            //Example:
            //Context.Carts.FirstOrDefault().Items.Add(Context.Products.First(p => p.Id.Equals(productId)));
            //return true;
        }

        public bool AddAlternative(int alternativeId)
        {
            //Adding Alternative
        }

        public List<ICriteria> GetAllCriteria()
        {
            //Getting all criteria

            //Example:
            //return new List<IProduct>(AutoMapper.Mapper.Map<List<Product>>(Context.Products));
        }

        public List<IAlternative> GetAllAlternative()
        {
            //Getting all alternative

            //Example:
            //return new List<IProduct>(AutoMapper.Mapper.Map<List<Product>>(Context.Products));
        }

        //-----CRUD needs to be added-----

        //Example:
        //public bool RemoveFromCart(int productId)
        //{
        //    return Context.Carts.FirstOrDefault().Items.Remove(Context.Products.First(p => p.Id.Equals(productId)));
        //}

        #endregion Methods
    }
}
