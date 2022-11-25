using System.Reflection.Metadata.Ecma335;

namespace WebApplicationTestFile.Services
{
    public interface IPasswordValidatorService
    {
        bool ValidPass(verify request);
    }
    public class PasswordValidatorService : IPasswordValidatorService
    {
        public bool ValidPass(verify request)
        {
            bool valid = false;
            if (request.Password != null)
            {
                if (request.Password == request.Password)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }

            }
            else
            {
                valid = false;
            }
            return valid;
        }
    
    }
   
}
/////akwjdn