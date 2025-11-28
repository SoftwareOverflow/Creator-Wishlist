using Application.Service;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Wishlist;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWishList([FromBody] CreateWishlistCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var publicId = await _wishlistService.CreateWishlistAsync(command);

                return CreatedAtAction(nameof(GetWishlistDetails), new { publicId = publicId }, publicId);
            }
            catch (ArgumentException ex)
            {
                // Handle domain validation errors
                return BadRequest(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException)
            {
                // Handle user not found/unauthorized errors
                return Unauthorized(new { Message = "Creator ID is invalid or unauthorized." });
            }
            catch (Exception)
            {
                // Catch all unhandled exceptions and return 500
                return StatusCode(500, "An unexpected error occurred while creating the wishlist.");
            }
        }

        [HttpGet]
        public ActionResult GetWishlistDetails(Guid publicGuid)
        {
            // TODO Implement WishlistDetailsQuery dto, and retrieve the data.
            return Ok($"Fetching data for wishlist {publicGuid}");
        }
    }
}
