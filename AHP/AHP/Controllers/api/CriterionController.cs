using AHP.Model.Common.Model_Interfaces;
using AHP.Models.Dto;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace AHP.Controllers.api
{
    public class CriterionController : ApiController
    {
        #region ctor and property
        public CriterionController(ICriteriaService criteriaService, ICriteriaRankService criteriaRankService, IMapper mapper)
        {
            this._mapper = mapper;
            this._criteriaService = criteriaService;
            this._criteriaRankService = criteriaRankService;
        }
        private IMapper _mapper { get; set; }
        private ICriteriaService _criteriaService { get; set; }
        private ICriteriaRankService _criteriaRankService;
        #endregion

       
        // POST: api/Criterion/AddNewCriterion
        [HttpPost]
        public async Task<List<CriterionDto>> AddNewCriterion(List<CriterionDto> criteria)
        {

            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaModel>>(criteria);
                var status = await _criteriaService.AddRange(mapped);
                return criteria;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

        }

        // GET: api/Criterion/EditCriterion
        [HttpGet]
        public async Task<List<CriterionDto>> EditCriteria(Guid id)
        {
            var criteriasInProject = await _criteriaService.GetCriteriasByProjectId(id, 1);
            var sorted = criteriasInProject.OrderBy(c => c.Order).ToList();

            var criterias = _mapper.Map<List<CriterionDto>>(sorted);
            return criterias;
            //vraca kriterije sortirane po orderu.
        }

        // POST: api/Criterion/EditCriterionPreference
        [HttpPost]
        public async Task<List<CriteriaRankDto>> EditCriterionPreference(List<CriteriaRankDto> criteriaRank)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaRankModel>>(criteriaRank);
                await _criteriaRankService.AddRange(mapped);
                return criteriaRank;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
        // DELETE: api/Criterion/DeleteCriterion
        [HttpDelete]
        public async Task<HttpResponseException> DeleteCriterion(Guid criterion)
        {
            await _criteriaService.DeleteCriteriaAsync(criterion);
            throw new HttpResponseException(HttpStatusCode.OK);
        }
    }
}
