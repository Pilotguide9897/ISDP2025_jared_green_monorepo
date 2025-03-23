namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface ILogin
    {
        public Task<bool> AttemptLogin(string username, string password);

        public Task<string> DecryptPassword(string username);

    }
}
