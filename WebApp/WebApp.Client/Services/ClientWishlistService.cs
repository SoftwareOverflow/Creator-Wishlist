using Application.Service.Interfaces;
using Shared.DTO.Wishlist.Commands;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.Wishlist.Queries;
using System.Net.Http.Json;

namespace WebUI.Client.Services
{
    public class ClientWishlistService : IWishlistService
    {
        private readonly HttpClient _http;

        public ClientWishlistService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<Guid> CreateWishlistAsync(CreateWishlistCommand command)
        {
            var response = await _http.PostAsJsonAsync("api/user/wishlist", command);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            return Guid.TryParse(responseContent, out var guid) ? guid : Guid.Empty;
        }

        public Task<WishlistDetailsDto> GetWishlistDetails(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WishlistDetailsDto> GetWishlistDetailsForUser(Guid id)
        {
            return await _http.GetFromJsonAsync<WishlistDetailsDto>($"api/user/wishlist/{id.ToString()}");
        }

        public async Task<IReadOnlyList<WishlistSummaryDto>> GetWishlistsForUser(WishlistsForUserQuery query)
        {
            return await _http.GetFromJsonAsync<IReadOnlyList<WishlistSummaryDto>>("api/user/wishlist");
        }
    }
}
