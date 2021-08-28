using AutoMapper;
using Matches.Data;
using Matches.Models;
using Matches.Models.Dto;
using Matches.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkgenerator;

        public MatchesController(IMatchRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkgenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> Get()
        {

            try
            {
                IEnumerable<Match> matches = await _repository.GetAllAsync();

                IEnumerable<MatchDto> matchesDto = _mapper.Map<IEnumerable<MatchDto>>(matches);


                return Ok(matchesDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> Get(int id)
        {
            try
            {
                Match match = await _repository.GetByIdAsync(id);

                if (match == null)
                {
                    return NotFound();
                }

                MatchDto matchDto = _mapper.Map<MatchDto>(match);

                return Ok(matchDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<Match>> Update(int id, MatchDto matchDto)
        {
            try
            {
                if (id != matchDto.Id)
                {
                    return BadRequest();
                }

                Match existingMatch = await _repository.GetByIdAsync(id);

                if (existingMatch == null)
                {
                    return NotFound();
                }

                _mapper.Map(matchDto, existingMatch);

                await _repository.UpdateAsync(existingMatch);

                return Ok(existingMatch);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MatchDto>> Create(MatchDto matchDto)
        {
            try
            {
                Match match = _mapper.Map<Match>(matchDto);
                Match createdMatch = await _repository.SaveAsync(match);

                string location = _linkgenerator.GetPathByAction("Get", "Matches", new Match { Id = createdMatch.Id });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current description");
                }

                return Created("", _mapper.Map<MatchDto>(createdMatch));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);

                if (existing == null)
                {
                    return NotFound();
                }

                await _repository.RemoveAsync(existing);

                return Ok();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }
    }
}
