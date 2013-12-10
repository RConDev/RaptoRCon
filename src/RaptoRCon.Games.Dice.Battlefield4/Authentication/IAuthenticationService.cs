using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice.Battlefield4.Authentication
{
    /// <summary>
    /// This interface describes the functionality needed to login into an 
    /// Battlefield 4 Console
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task SecureLoginAsync(string password);

        Task LogoutAsync();
    }
}
