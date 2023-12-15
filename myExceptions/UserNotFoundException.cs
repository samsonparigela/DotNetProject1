using System;
namespace VirtualArtGallery2.myExceptions
{
	public class UserNotFoundException:Exception
	{
		public UserNotFoundException(string message):
			base(message)
		{
		
		}
	}
}

