using System;
using Microsoft.Data.SqlClient;

namespace VirtualArtGallery2.ArtgalleryRepository
{
	public class DBConnection
	{
		public static SqlConnection Connect()
		{

			string connectionString = @"Server=localhost;Database=Virtual_Art_Gallery;User ID=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			return conn;

		}
	}
}

