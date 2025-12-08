using Application.Repository;
using Application.Service.Interfaces;
using Application.Service.Mappers;
using Domain.Entity;
using Shared.DTO.Wishlist.Commands;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.Wishlist.Queries;

namespace Application.Service
{
    internal class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUserRepository _userRepository;

        public WishlistService(IWishlistRepository wishlistRepository, IUserRepository userRepository)
        {
            _wishlistRepository = wishlistRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateWishlistAsync(CreateWishlistCommand command)
        {
            if (String.IsNullOrWhiteSpace(command.Title))
            {
                throw new ArgumentException("Wishlist name cannot be empty.");
            }

            var creatorInternalId = await _userRepository.GetCurrentUserId();
            
            // TODO move this to mapper?
            var wishlist = new Wishlist
            {
                Guid = Guid.NewGuid(),
                UserId = creatorInternalId,
                Title = command.Title,
                Description = command.Description,
            };

            var result = await _wishlistRepository.AddAsync(wishlist);

            return result.Guid;
        }

        public async Task<IReadOnlyList<WishlistSummaryDto>> GetWishlistsForUser(WishlistsForUserQuery query)
        {
            // TODO any business logic for checking subsciption levels or similar.
            var creatorInternalId = await _userRepository.GetCurrentUserId();
            var wishlists = await _wishlistRepository.GetWishlistsForUser(creatorInternalId);

            var result = wishlists.ToSummaryDto();

            return [.. result];
        }

        public async Task<WishlistDetailsDto> GetWishlistDetails(Guid id)
        {
            var internalId = await _wishlistRepository.GetInternalIdByPublicIdAsync(id) ?? throw new InvalidOperationException("Not Found");

            var wishlist = await _wishlistRepository.GetByIdAsync(internalId) ?? throw new InvalidOperationException("Not Found");

            var result = wishlist.ToDetailsDto();

            return result;
        }

        public async Task<WishlistDetailsDto> GetWishlistDetailsForUser(Guid id)
        {
            var internalId = await _wishlistRepository.GetInternalIdByPublicIdAsync(id) ?? throw new InvalidOperationException("Not Found");

            var wishlist = await _wishlistRepository.GetByIdAsync(internalId);
            
            var currentUserId = await _userRepository.GetCurrentUserId();

            // Ensure that the current user is the owner of this wishlist.
            if(wishlist.UserId != currentUserId)
            {
                // TODO throw some UnauthorizedAccess exception? Or return null? Think about what's best to avoid leaking valid Guid...
                throw new UnauthorizedAccessException("Current user does not have permission to access the requested wishlist");
            }

            return wishlist.ToDetailsDto();

        }
    }
}
