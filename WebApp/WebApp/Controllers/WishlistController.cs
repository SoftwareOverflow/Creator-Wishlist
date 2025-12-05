using Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Wishlist.Commands;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.Wishlist.Queries;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<WishlistSummaryDto>>> GetWishlistsForUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new WishlistsForUserQuery();
            var result = await _wishlistService.GetWishlistsForUser(query);
            return Ok(result);
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

                return CreatedAtAction(nameof(GetWishlistDetailsForUser), new { publicId }, publicId);
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

        [HttpGet("user/{id}")]
        public async Task<ActionResult<WishlistDetailsDto>> GetWishlistDetailsForUser(Guid id)
        {
            // TODO error checking..

            var result = await _wishlistService.GetWishlistDetailsForUser(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
