namespace Infrastructure.Identity.Claims
{
    public interface ITwitterClaimsHelper
    {
        string GetOAuthAccessToken();
        string GetOAuthAccessTokenSecret();
        string GetUserId();
    }
}
