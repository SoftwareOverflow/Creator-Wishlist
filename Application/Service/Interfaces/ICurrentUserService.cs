namespace Application.Service.Interfaces
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// The Identifier for the currently logged in user
        /// </summary>
        public int? UserId { get; }
    }
}
