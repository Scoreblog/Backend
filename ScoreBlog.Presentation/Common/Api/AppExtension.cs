namespace ScoreBlog.Presentation.Common.Api;
internal static class AppExtension
{
    #region ConfigureEnvironment
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseForwardedHeaders();
    }
    #endregion ConfigureEnvironment

    #region Security
    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
    #endregion
}