using Projet.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projet
{
    public static class UserSecurity
    {
        public static void Verification(string email, string clearTextPassword, string clearTextPassword2)
        {
            if (!IsValidEmail(email))
            {
                throw new UnauthorizedAccessException("This is not an email adress");
            }
            IsValidPassword(clearTextPassword, clearTextPassword2);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException )
            {
                return false;
            }
            catch (ArgumentException )
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static void IsValidPassword(string p1, string p2)
        {
            if (p1.IsNullOrEmpty() || p2.IsNullOrEmpty())
                throw new UnauthorizedAccessException("Please enter a valid password"); ;
            if (p1.Length < 4 || !p1.Any(char.IsDigit) || !p1.Any(char.IsUpper) || !p1.Any(char.IsLower))
                throw new UnauthorizedAccessException("Your password must have at least 4 characters, 1 number, and 1 capital");
            if (!p1.Equals(p2))
                throw new UnauthorizedAccessException("The passwords are not identical");
        }

        public static string Hash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
