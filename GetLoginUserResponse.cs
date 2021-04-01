namespace MyLibrary
{
    public class GetLoginUserResponse
    {
        public bool IsLoginSuucess { get; set; }
        public bool IsAdmin { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
