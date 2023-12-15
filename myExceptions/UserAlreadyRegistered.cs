using System;
namespace VirtualArtGallery2.myExceptions
{
	public class UserAlreadyRegistered:Exception
	{
		public UserAlreadyRegistered(string message)
			:base(message)
		{
		}
	}
}

