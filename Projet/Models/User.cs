using Projet.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public DateTime UserDateOfBirth { get; set; }
        public string UserAdress { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            User that = obj as User;

            if (UserId != that.UserId) return false;
            if (UserName != that.UserName) return false;
            if (UserFirstName != that.UserFirstName) return false;
            if (UserDateOfBirth != that.UserDateOfBirth) return false;
            if (UserAdress != that.UserAdress) return false;
            if (UserEmail != that.UserEmail) return false;
            if (UserPhoneNumber != that.UserPhoneNumber) return false;
            if (UserPassword != that.UserPassword) return false;
            if (UserRole != that.UserRole) return false;

            return true;
        }

        public override int GetHashCode()
        {
            long result = UserId;
            result += 31 * result + (UserName != null ? UserName.GetHashCode() : 0);
            result += 31 * result + (UserFirstName != null ? UserFirstName.GetHashCode() : 0);
            result += 31 * result + (UserDateOfBirth != null ? UserDateOfBirth.GetHashCode() : 0);
            result += 31 * result + (UserAdress != null ? UserAdress.GetHashCode() : 0);
            result += 31 * result + (UserEmail != null ? UserEmail.GetHashCode() : 0);
            result += 31 * result + (UserPhoneNumber != null ? UserPhoneNumber.GetHashCode() : 0);
            result += 31 * result + (UserPassword != null ? UserPassword.GetHashCode() : 0);
            result += 31 * result + (UserRole != null ? UserRole.GetHashCode() : 0);

            return result.ToInt();
        }
    }
}
