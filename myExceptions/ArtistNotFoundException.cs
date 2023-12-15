using System;
namespace VirtualArtGallery2.myExceptions
{
	public class ArtistNotFoundException:Exception
	{
		public ArtistNotFoundException(string message)
			:base(message)
		{
		}
	}
}

