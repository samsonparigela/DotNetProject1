using System;
namespace VirtualArtGallery2.Models
{
	public class Gallery
	{
        public int GalleryID { set; get; }
        public int ArtistID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Location { set; get; }
        public DateTime OpeningHours { set; get; }

        public override string ToString()
        {
            return $"GalleryID::{GalleryID}\tArtistID::{ArtistID}\tName::{Name}\tDescription::{Description}\t" +
                $"Location::{Location}\tOpeningHours::{OpeningHours}";
        }
    }
}

