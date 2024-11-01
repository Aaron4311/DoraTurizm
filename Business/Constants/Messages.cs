using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        #region Tour Messages
        public static string tourIsAdded = "Tour is Added";
        public static string tourIsRemoved = "Tour is Removed";
        public static string tourIsListed = "Tour is Listed";
        public static string toursAreListed = "Tours are Listed";
        public static string tourIsUpdated = "Tour is Updated";
        #endregion

        #region User Messages
        public static string userDidNotFound = "User did not found";
        public static string userIsRegistered = "User has been registered";
        public static string userExists = "This user already exists";
        public static string userIsAdded = "User has been added";
        #endregion

        #region Login Messages
        public static string loginSuccessful = "Login is successful";
        public static string accessTokenCreated = "Access token is created";
        public static string authorizationDenied = "Authorization is denied";

        #endregion

        #region Message Messages
        public static string messageIsAdded = "Message is Added";
        public static string messageIsDeleted = "Message is Deleted";
        public static string messagesAreListed = "Messages are Listed";
        public static string messageIsListed = "Message is Listed";
        public static string messageIsUpdated = "Message is Updated";
        #endregion
    }
}
