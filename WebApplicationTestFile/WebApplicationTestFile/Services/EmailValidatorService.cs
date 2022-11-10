using System.Reflection.Metadata.Ecma335;
using WebApplicationTestFile.Models;

namespace WebApplicationTestFile.Services
{
    public interface IUserIdValidatorService
    {
        bool ValidUser(verify request);
    }
    /// <summary>
    /// //
    /// </summary>
    public class UserIdValidatorService : IUserIdValidatorService
    {
        public bool ValidUser(verify request)
        {
            bool validUser = false;
        }
        verify gefunden = new verify();
            foreach (verify forEachVariable in LoginList)
            {
                if (forEachVariable.Userid==id)
                {
                    gefunden = forEachVariable;
                }
}

if (gefunden.Userid == 0)
{
    return NotFound();
}
else
{
    return Ok(gefunden);
}
        }
