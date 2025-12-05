using Application.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.DTO.Wishlist.Dtos;

namespace WebUI.Components.Pages.User
{
    public partial class WishlistDetails : ComponentBase
    {
        [Inject]
        private IWishlistService WishlistService { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        

        private WishlistDetailsDto _wishlist { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            _wishlist = await WishlistService.GetWishlistDetailsForUser(Id);
        }
    }
}