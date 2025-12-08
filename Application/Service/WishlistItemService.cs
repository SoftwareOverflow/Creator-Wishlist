using Application.Repository;
using Application.Service.Interfaces;
using Application.Service.Mappers;
using Domain.Entity;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.WishlistItem.Commands;

namespace Application.Service
{
    internal class WishlistItemService : IWishlistItemService
    {
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUserRepository _userRepository;

        public WishlistItemService(IWishlistItemRepository wishlistItemRepository, IWishlistRepository wishlistRepository, IUserRepository userRepository)
        {
            _wishlistItemRepository = wishlistItemRepository;
            _wishlistRepository = wishlistRepository;
            _userRepository = userRepository;
        }

        public async Task<WishlistItemDto> CreateWishlistItem(CreateWishlistItemCommand command)
        {
            if (String.IsNullOrWhiteSpace(command.Name))
            {
                throw new ArgumentException("Wishlist Item name cannot be empty.");
            }

            var wishlist = await GetWishlist(command.WishlistGuid);

            var wishlistItem = new WishlistItem()
            {
                WishlistId = wishlist.Id,
                Guid = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                ItemUrl = command.ItemUrl,
                ImageUrl = command.ImageUrl,
            };

            var result = await _wishlistItemRepository.AddAsync(wishlistItem);

            return result.ToDto();
        }

        public async Task<WishlistItemDto> UpdateWishlistItem(UpdateWishlistItemCommand command)
        {
            var wishlist = await GetWishlist(command.WishlistGuid);

            var entity = wishlist.Items.SingleOrDefault(wi => wi.Guid == command.Guid);
            if (entity == null)
            {
                throw new InvalidOperationException("Not found");
            }

            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.ItemUrl = command.ItemUrl;
            entity.ImageUrl = command.ImageUrl;


            var result = await _wishlistItemRepository.UpdateAsync(entity);

            return result.ToDto();
        }

        private async Task<Wishlist> GetWishlist(Guid wishlistGuid)
        {
            var creatorInternalId = await _userRepository.GetCurrentUserId();
            var wishlistsForUser = await _wishlistRepository.GetWishlistsForUser(creatorInternalId);

            // TODO manage erros / throw different error type
            return wishlistsForUser.SingleOrDefault(w => w.Guid == wishlistGuid) ?? throw new InvalidOperationException("Not found");
        }
    }
}
