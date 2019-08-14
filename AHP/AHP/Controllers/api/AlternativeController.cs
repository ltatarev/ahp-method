using AHP.Model.Common.Model_Interfaces;
using AHP.Models.Dto;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AHP.Controllers.api
{
    public class AlternativeController : ApiController
    {
        #region ctor and properties
        public AlternativeController(IAlternativeService alternativeService,
                                    ICriteriaService criteriaService,
                                    IAlternativeRankService alternativeRankService,
                                    IMapper mapper)
        {
            this._alternativeService = alternativeService;
            this._criteriaService = criteriaService;
            this._alternativeRankService = alternativeRankService;
            this._mapper = mapper;
        }
        ICriteriaService _criteriaService;
        IAlternativeService _alternativeService;
        IAlternativeRankService _alternativeRankService;
        IMapper _mapper;
        #endregion
              

        // GET: api/Alterntive/EditAlternative
        [HttpGet]
        public async Task<CriteriaAlternativeDto> EditAlternative(Guid id)
        {
            
            var alternatives = await _alternativeService.GetAlternativesByProjectId(id, 1);
            var criterias = await _criteriaService.GetCriteriasByProjectId(id, 1);

            var criteriaAlternativeDto = new CriteriaAlternativeDto();

            var mappedAlternatives = _mapper.Map<IList<AlternativeDto>>(alternatives.OrderBy(a => a.Order));
            var mappedCriterias = _mapper.Map<IList<CriterionDto>>(criterias.OrderBy(c => c.Order));

            criteriaAlternativeDto.Alternatives = mappedAlternatives;
            criteriaAlternativeDto.Criterias = mappedCriterias;

            return criteriaAlternativeDto;

        }

        // POST: api/Alterntive/AddNewAlternative
        [HttpPost]
        public async Task<List<AlternativeDto>> AddNewAlternative(List<AlternativeDto> alternatives)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<IAlternativeModel>>(alternatives);

                var status = await _alternativeService.AddRange(mapped);

                return alternatives;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        // POST: api/Alternative/EditAlternativePreference
        [HttpPost]
        public async Task<List<AlternativeRankDto>> EditAlternativePreference(List<AlternativeRankDto> alternative)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<IAlternativeRankModel>>(alternative);

                await _alternativeRankService.AddRange(mapped);
                return alternative;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
    }
}
