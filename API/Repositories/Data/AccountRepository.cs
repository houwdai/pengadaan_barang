using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //Login
        public ResponseLogin Login(Login login)
        {
            var data = myContext.User.Include(x => x.Role).FirstOrDefault(x => x.email.Equals(login.email));

            if (data != null)
            {
                if (ValidatePassword(login.password, data.password))
                {
                    ResponseLogin responseLogin = new ResponseLogin();
                    {
                        responseLogin.id = data.id;
                        responseLogin.fullName = data.fullName;
                        responseLogin.email = data.email;
                        responseLogin.role = data.Role.name;
                    };
                    return responseLogin;
                } 
            }
            return null;
        }

        public ResponseRegister Register(Register register)
        {
            User user = new User()
            {
                fullName = register.fullName,
                email = register.email,
                password = HashPassword(register.password),
                RoleId = register.roleId
            };
            myContext.User.Add(user);

            if (myContext.SaveChanges() > 0)
            {
                ResponseRegister response = new ResponseRegister()
                {
                    id = user.id,
                    fullName = register.fullName,
                    email = register.email,
                    password = register.password,
                    roleId = register.roleId
                };
                return response;
            }
            return null;
        }

        public bool ForgotPassword(ForgotPassword forgotPassword)
        {
            var data = myContext.User.Where(x => x.email.Equals(forgotPassword.email)).FirstOrDefault();

            if(data != null)
            {
                var user = myContext.User.Where(x => x.id == data.id).FirstOrDefault();
                
                if (user!= null)
                {
                    if(forgotPassword.newPassword == forgotPassword.confirmNewPassword)
                    {
                        user.password = HashPassword(forgotPassword.newPassword);
                        myContext.User.Update(user);
                        
                        if (myContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Hashing and Validating Password
        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
