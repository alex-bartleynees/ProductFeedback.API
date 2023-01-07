using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;
using ProductFeedback.API.Services;

namespace ProductFeedback.API.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionsRepository _suggestionsRepository;

        public SuggestionsController(ISuggestionsRepository suggestionsRepository)
        {
            _suggestionsRepository = suggestionsRepository ??
                throw new ArgumentNullException(nameof(suggestionsRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suggestion>>> GetSuggestions()
        {
            var suggestionsEntity = await _suggestionsRepository.GetSuggestions();

            if (suggestionsEntity == null)
            {
                return NotFound();
            }

            return Ok(suggestionsEntity);
        }

        [HttpGet("{suggestionId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<IEnumerable<Suggestion>>> GetSuggestionById(int suggestionId)
        {
            var suggestion = await _suggestionsRepository.GetSuggestionById(suggestionId);

            if (suggestion == null)
            {
                return NotFound();
            }

            return Ok(suggestion);
        }

        [HttpPost]
        public async Task<ActionResult<Suggestion>> CreateSuggestion(SuggestionForCreationDto suggestion)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var suggestionEntity = new Suggestion(suggestion.Title, suggestion.Category, "" , suggestion.Description);

            await _suggestionsRepository.CreateSuggestion(suggestionEntity);

            return Ok(suggestionEntity);
        }

        [HttpPut("{suggestionId}")]
        public async Task<ActionResult<Suggestion>>  UpdateSuggestion(int suggestionId, SuggestionForUpdateDto suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToUpdate = await _suggestionsRepository.GetSuggestionById(suggestionId);

            if (entityToUpdate != null)
            {
                entityToUpdate.Title = suggestion.Title;
                entityToUpdate.Upvotes = suggestion.Upvotes;
                entityToUpdate.Category = suggestion.Category;
                entityToUpdate.Status = suggestion.Status;
                entityToUpdate.Description = suggestion.Description;

                await _suggestionsRepository.SaveChangesAsync();

                return Ok(entityToUpdate);
            }

            return NotFound();
        }

        [HttpDelete("{suggestionId}")]
        public async  Task<ActionResult> DeleteSuggestion(int suggestionId)
        {
            _suggestionsRepository.DeleteSuggestion(suggestionId);

            await _suggestionsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
