using System;
using System.Xml.Linq;

namespace VirtualArtGallery2.Models
{
	public class Users
	{
        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ProfilePicture { set; get; }
        public DateTime DateOfBirth { set; get; }

        public override string ToString()
        {
            return $"UserID::{UserID}\tUserName::{UserName}\tEmail::{Email}\tFirstName::{FirstName}\t" +
                $"LastName::{LastName}\tProfilePicture::{ProfilePicture}::\tDateOfBirth::{DateOfBirth}";
        }

    }
}

