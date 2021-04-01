using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetLoginUser")]
        public string GetLoginUser(string userName,string password)
        {
            GetLoginUserResponse result = new GetLoginUserResponse();

            //Return the admin only
            if (userName == "Ben" && password == "Tsabari")
            {
                result.IsLoginSuucess = true;
                result.IsAdmin = true;
                return JsonConvert.SerializeObject(result);
            }



            List<User> userList = DB.PullData<User>($"SELECT UserID, UserName, Password FROM Users Where UserName = @userName"
               , (dr) =>
               {
                   return new User
                   {
                       UserID = dr.GetInt32(0),
                       UserName = dr.GetString(1),
                       Password = dr.GetString(2)
                   };
               }, (cmd) => cmd.AddWithValue("@userName", userName));

            if(userList.Count > 0)
            {
                User user = userList[0];
                if(user.Password == password)
                {
                    result.IsLoginSuucess = true;
                }
                else
                {
                    result.ErrorMessage = "Worng Password,Try again.";
                }
            }
            else
            {
                result.ErrorMessage = "User Was not found,Please register.";
            }

            string jsonResult =  JsonConvert.SerializeObject(result);
            return jsonResult;
        }


        [HttpGet("pull")]
        public List<User> Pull() 
        {
            return DB.PullData<User>("SELECT UserID, UserName, Password FROM Users"
                , (dr) =>
                {
                    return new User
                    {
                        UserID = dr.GetInt32(0),
                        UserName = dr.GetString(1),
                        Password = dr.GetString(2)
                    };
                });
        }

        [HttpPost("update")]
        public bool Update(User user) 
        {
            return DB.Modify("UPDATE Users SET UserName = @UserName, Password = @Password WHERE UserID=@UserID",
            (cmd) =>
            {
                cmd
                .AddWithValue("@UserID", user.UserID)
                .AddWithValue("@UserName", user.UserName.TrimEnd())
                .AddWithValue("@Password", user.Password.TrimEnd());
                
            }) == 1;
        }

        [HttpPost("insert")]
        public bool Insert(User user) 
        {
            List<User> existUsers = DB.PullData<User>($"SELECT UserID, UserName, Password FROM Users Where UserName = @userName"
               , (dr) =>
               {
                   return new User
                   {
                       UserID = dr.GetInt32(0),
                       UserName = dr.GetString(1),
                       Password = dr.GetString(2)
                   };
               }, (cmd) => cmd.AddWithValue("@userName", user.UserName));

            if(existUsers.Count > 0)
            {
                return false;
            }


            return DB.Modify("INSERT INTO Users " +
              "(UserName, Password) " +
              "VALUES (@UserName, @Password)",
              (cmd) =>
              {
                  cmd
                  .AddWithValue("@UserName", user.UserName.TrimEnd())
                  .AddWithValue("@Password", user.Password.TrimEnd());

              }) == 1;
        }

        [HttpGet("delete")]
        public bool Delete(int id) 
        {
            return DB.Modify("DELETE FROM Users WHERE UserID=@UserID",
              (cmd) => cmd.AddWithValue("@UserID", id)) == 1;

     
        }


     
    }
}
