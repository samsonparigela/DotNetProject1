using System;
namespace VirtualArtGallery2.Models
{
	public class ArtworkGallery
	{
        int artworkID, galleryID;
        public ArtworkGallery(int artworkID,int galleryID)
		{
			this.artworkID = artworkID;
			this.galleryID = galleryID;
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
		public int GalleryID
		{
			get
			{
				return galleryID;
			}
			set
			{
				galleryID = value;
			}
		}
		
	}
}

