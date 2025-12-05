using Application.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.DTO.Wishlist.Commands;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.Wishlist.Queries;

namespace WebUI.Components.Pages.User
{
    public partial class WishlistsSummary : ComponentBase
    {
        [Inject]
        private IWishlistService WishlistService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;


        private IReadOnlyList<WishlistSummaryDto> _wishlists = [];

        [SupplyParameterFromForm]
        private CreateWishlistCommand CreateWishlistModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync");
            // TODO
            var query = new WishlistsForUserQuery();
            _wishlists = await WishlistService.GetWishlistsForUser(query);
        }

        private async Task SubmitCreateWishlistForm()
        {
            var guid = await WishlistService.CreateWishlistAsync(CreateWishlistModel);
            Console.WriteLine("NEWLY CREATED: " + guid);
        }

        private void GoToWishlistDetails(Guid guid)
        {
            NavigationManager.NavigateTo($"user/wishlists/{guid}");
        }
    }
}