using System;
namespace VirtualArtGallery2.Models
{
    public class Artist
    {
        public int ArtistID { set; get; }
        public string ContactInformation { set; get; }
        public string Name { set; get; }
        public string Biography { set; get; }
        public string Nationality { set; get; }
        public string Website{ set; get; }
        public DateTime Birthday { set; get; }

        public override string ToString()
        {
            return $"ArtistID::{ArtistID}\tContactInformation::{ContactInformation}\tName::{Name}\tFBiography::{Biography}\t" +
                $"Nationality::{Nationality}\tWebsite::{Website}::\tBirthday::{Birthday}";
        }

    }
}

