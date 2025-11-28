using Application.Repository;
using Domain.Entity;
using Shared.DTO.Wishlist;

namespace Application.Service
{
    public class WishlistService
    {
        private IWishlistRepository _wishlistRepository;
        private IUserRepository _userRepository;

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

            int creatorInternalId;
            try
            {
                creatorInternalId = await _userRepository.GetInternalIdFromPublicIdAsync(command.CreatorPublicId);
                var creator = await _userRepository.GetByIdAsync(creatorInternalId);
                if (creator == null || !creator.IsCreator)
                {
                    throw new UnauthorizedAccessException("User is not authorized to create wishlists.");
                }
            } catch(InvalidOperationException) // TODO check this correct catch for the UserRepo
            {
                throw new UnauthorizedAccessException("The specified creator ID does not exist or is invalid");
            }

            var wishlist = new Wishlist
            {
                Guid = Guid.NewGuid(),
                CreatorId = creatorInternalId,
                Name = command.Title,
                Description = command.Description,
            };

            await _wishlistRepository.AddAsync(wishlist);

            return wishlist.Guid;
        }
    }
}
