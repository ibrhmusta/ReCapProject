namespace Core.Constants
{
    public static class AspectMessages
    {
        // ValidationAspectMessages
        public static string WrongValidationType = "Wrong Validation Type";
        public static string CanNotBeBlank = "Can not be blank.";
        public static string InvalidEmailAddress = "Email Address in Invalid Format.";



        //SecuredAspectMessages
        public static string AuthorizationDenied = "You are not authorized."; public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password is wrong.";
        public static string SuccessfulLogin = "Login to the system is successful.";
        public static string UserAlreadyExists = "This user already exists.";
        public static string UserRegistered = "User successfully registered.";
        public static string AccessTokenCreated = "Access token successfully created. ";
    }
}