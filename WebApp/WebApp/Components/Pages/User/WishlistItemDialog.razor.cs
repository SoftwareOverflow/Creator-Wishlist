using Application.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.WishlistItem.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebUI.Components.Pages.User
{
    public partial class WishlistItemDialog
    {
        [Inject]
        private DialogService DialogService { get; set; } = default!;

        [Inject]
        private NotificationService NotificationService { get; set; } = default!;

        [Inject]
        private IWishlistItemService WishlistItemService { get; set; } = default!;

        [Parameter, EditorRequired]
        public WishlistItemBaseCommand WishlistItemCommand { get; set; } = default!;

        [Parameter]
        public Guid? WishlistItemGuid { get; set; } = null;

        private bool _isSaving;

        public async Task SaveChanges()
        {
            _isSaving = true;

            WishlistItemDto? result = null;
            if (WishlistItemGuid == null)
            {
                if (WishlistItemCommand is CreateWishlistItemCommand createItemCommand)
                {
                    result = await WishlistItemService.CreateWishlistItem(createItemCommand);
                }
                else
                {
                    // TODO errors
                }
            }
            else
            {

                if(WishlistItemCommand is UpdateWishlistItemCommand updateItemCommand)
                {
                    updateItemCommand.Guid = WishlistItemGuid.Value;

                    result = await WishlistItemService.UpdateWishlistItem(updateItemCommand);
                }
                else
                {
                    // TODO errors
                }
            }

            if (result != null)
            {
                NotificationService.Notify(NotificationSeverity.Info, "Wishlist Item Saved");
            }
            else
            {
                NotificationService.Notify(NotificationSeverity.Warning, "Something went wrong. Please refresh the page and try again.");
            }

            _isSaving = false;


            DialogService.Close(result);
        }
    }
}