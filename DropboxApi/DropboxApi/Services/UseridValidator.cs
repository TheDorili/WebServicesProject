using DropboxApi.Models;

namespace DropboxApi.Services
{
    public interface IUserIdValidatorService
    {
        bool ValidUser(int id, List<verify> validUsers);
    }
    /// <summary>
    /// //
    /// </summary>
    public class UserIdValidatorService : IUserIdValidatorService
    {
        public bool ValidUser(int id, List<verify> validUsers)
        {
            verify gefunden = new verify();
            foreach (verify forEachVariable in validUsers)
            {
                if (forEachVariable.Userid == id)
                {
                    gefunden = forEachVariable;
                }
            }

            return false;

        }
    }

}

