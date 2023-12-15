using System;
namespace VirtualArtGallery2.Models
{
	public class UserFavoriteArtwork
	{
        int userID, artworkID;
        public UserFavoriteArtwork(int userID,int artworkID)
		{
			this.userID = userID;
			this.artworkID = artworkID;
		}
        public int ArtworkID
        {
            get
            {
                return artworkID;
            }
            set
            {
                artworkID = value;
            }
        }
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
    }
}

