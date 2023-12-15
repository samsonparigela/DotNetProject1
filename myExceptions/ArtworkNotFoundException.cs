using System;
namespace VirtualArtGallery2.myExceptions
{
	public class ArtworkNotFoundException:Exception
	{
		public ArtworkNotFoundException(string message):
			base(message)
		{
		}
	}
}

