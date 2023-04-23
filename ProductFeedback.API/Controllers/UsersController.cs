using Microsoft.AspNetCore.Mvc;
using ProductFeedback.API.Entities;
using ProductFeedback.API.Services;

namespace ProductFeedback.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISuggestionsRepository _suggestionsRepository;

        public UsersController(ISuggestionsRepository suggestionsRepository)
        {
            _suggestionsRepository = suggestionsRepository ??
                throw new ArgumentNullException(nameof(suggestionsRepository));
        }

        [HttpGet("{userId}")]
       public async Task<ActionResult<User>> getUser(int userId)
        {
            var userEntity = await _suggestionsRepository.GetUser(userId);  

            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(userEntity);

        }
    }
}
