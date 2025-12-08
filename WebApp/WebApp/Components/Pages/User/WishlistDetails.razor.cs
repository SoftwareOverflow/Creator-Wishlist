using Application.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.WishlistItem.Commands;

namespace WebUI.Components.Pages.User
{
    public partial class WishlistDetails : ComponentBase
    {
        [Inject]
        private IWishlistService WishlistService { get; set; } = default!;

        [Inject]
        private DialogService DialogService { get; set; } = default!;

        [Parameter]
        public Guid WishlistId { get; set; }

        private WishlistItemBaseCommand? _wishlistItemToEdit = null;
        

        private WishlistDetailsDto _wishlist { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            _wishlist = await WishlistService.GetWishlistDetailsForUser(WishlistId);
        }

        private bool IsVisible = false;

        private async Task ShowItemDetails(WishlistItemBaseCommand command, Guid? guid = null)
        {
            IsVisible = !IsVisible;
            Console.WriteLine("Modal Visible: " +  IsVisible);
            //StateHasChanged();

            var title = (guid == null) ? "Create Wishlist Item" : "Edit Wishlist Item";

            var result = await DialogService.OpenAsync<WishlistItemDialog>(title, new() { { "WishlistItemCommand", command } });
            Console.WriteLine(result ?? "No Result");

            _wishlistItemToEdit = null;
            StateHasChanged();
        }

        private async Task CreateNewWishlistItem()
        {
            var createCommand = new CreateWishlistItemCommand
            {
                WishlistGuid = WishlistId
            };

            await ShowItemDetails(createCommand);
        }
    }
}