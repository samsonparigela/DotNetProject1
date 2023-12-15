using System;
using Microsoft.Data.SqlClient;
using VirtualArtGallery2.Models;

namespace VirtualArtGallery2.ArtgalleryRepository
{
	public interface IIntermediate
	{

        public abstract List<Gallery> ViewGalleries(SqlConnection conn);
        public abstract List<Users> UserProfile(SqlConnection conn, int userID);
        public abstract List<Artist> SearchArtist(SqlConnection conn, int ArtistID);
        public abstract List<Artwork> SearchArtworkByID(SqlConnection conn, int artWorkID);
        public abstract List<Artwork> BrowseArtworks(SqlConnection conn);
        public abstract bool AddArtworktoFav(SqlConnection conn, int userID);
        public abstract bool RemoveArtworkFromFav(SqlConnection conn, int userID);
        public abstract List<Artwork> ShowFavList(SqlConnection conn, int userID);
        public abstract List<Artwork> SearchArtworkByKeyword(SqlConnection conn, string keyword);
        public abstract bool AddArtwork(SqlConnection conn, Artwork artwork);
        public abstract bool UpdateArtwork(SqlConnection conn, Artwork artwork);
        public abstract bool RemoveArtwork(SqlConnection conn, int artWorkID);
        public abstract void AdminLogin(SqlConnection conn);
        public abstract void Login(SqlConnection conn);
        public abstract bool Register(SqlConnection conn);

    }
}

