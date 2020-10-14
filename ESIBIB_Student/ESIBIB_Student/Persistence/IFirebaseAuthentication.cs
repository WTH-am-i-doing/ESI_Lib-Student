using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESIBIB_Student.Persistence
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailAndPassword(string email, string password);

        string SignUp(string email, string password);

        string GetUserEmail();
    }
}
