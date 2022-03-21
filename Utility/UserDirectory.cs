using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLibrary
{
    public static class UserDirectory
    {
        public static string GetUserSID(string userName)
        {
            try
            {
                NTAccount f = new NTAccount(userName);
                SecurityIdentifier s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
                return s.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static string GetUserProfilePath(string userName, string userSID = null)
        {
            try
            {
                if (userSID == null)
                {
                    userSID = GetUserSID(userName);
                }

                var keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + userSID;

                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath);
                if (key == null)
                {
                    //handle error
                    return null;
                }

                var profilePath = key.GetValue("ProfileImagePath") as string;

                return profilePath;
            }
            catch
            {
                //handle exception
                return null;
            }
        }
    }
}
