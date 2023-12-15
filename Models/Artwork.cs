using System;
using System.Diagnostics;


namespace VirtualArtGallery2.Models
{
    public class Artwork
    {
        public int ArtworkId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Medium { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreationDate { get; set; }


        public override string ToString()
        {
            return $"ArtworkIDr::{ArtworkId}\tArtistId::{ArtistId}\tTitle::{Title}\tDescription::{Description}\t" +
                $"Medium::{Medium}\tImageURL::{ImageURL}::\tCreationDate::{CreationDate}";
        }

        
    }
}

