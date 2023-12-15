using System.Text;
using Microsoft.Data.SqlClient;
using VirtualArtGallery2.Models;
using VirtualArtGallery2.myExceptions;

namespace VirtualArtGallery2.ArtgalleryRepository
{
	public class Intermediate: IIntermediate
    {

        #region ViewGalleries - V
        public List<Gallery> ViewGalleries(SqlConnection conn)
        {
            string query = "SELECT * FROM GALLERY";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            List<Gallery> galList = new List<Gallery>();
            Gallery gallery;

            while(rd.Read())
            {
                gallery = new Gallery();
                gallery.GalleryID =(int)rd["GalleryID"];
                gallery.ArtistID = (int)rd["ArtistID"];
                gallery.Name = (string)rd["Name"];
                gallery.Description = (string)rd["Description"];
                gallery.ArtistID = (int)rd["ArtistID"];
                gallery.OpeningHours = (DateTime)rd["OpeningHours"];
                gallery.Location = (string)rd["Location"];

                galList.Add(gallery);
            }
            rd.Close();
            return galList;
        }
        #endregion

        #region UserProfile - V
        public List<Users> UserProfile(SqlConnection conn,int userID)
        {
            string query = $"SELECT * FROM Users WHERE UserID={userID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            Users user;
            List<Users> userslist = new List<Users>();

            while(rd.Read())
            {
                user = new Users();
                user.UserID = (int)rd["UserID"];
                user.UserName = (string)rd["UserName"];
                user.FirstName = (string)rd["First_Name"];
                user.LastName = (string)rd["Last_Name"];
                user.Email = (string)rd["Email"];
                user.DateOfBirth = (DateTime)rd["Date_Of_Birth"];
                user.ProfilePicture = (string)rd["Profile_Picture"];

                userslist.Add(user);
            }
            rd.Close();
            return userslist;
        }
        #endregion

        #region SearchArtist - V
        public List<Artist> SearchArtist(SqlConnection conn,int ArtistID)
        {

            string query = $"SELECT * FROM Artist where ArtistID={ArtistID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            Artist artist = new Artist();
            List<Artist> artistList = new List<Artist>();

            while (rd.Read())
            {
                artist = new Artist();
                artist.ArtistID = (int)rd["ArtistID"];

                if (artist.ArtistID == ArtistID)
                {
                    artist.Name = (string)rd["name"];
                    artist.Biography = (string)rd["biography"];
                    artist.Nationality = (string)rd["Nationality"];
                    artist.Birthday = (DateTime)rd["Birthdate"];
                    artist.ContactInformation = (string)rd["Contact_Information"];
                    artist.Website = (string)rd["Website"];
                    artistList.Add(artist);
                }
            }
            rd.Close();
            return artistList;
        }
        #endregion

        #region SearchArtworkByID - V
        public List<Artwork> SearchArtworkByID(SqlConnection conn,int artWorkID)
        {

            string query = $"SELECT * FROM Artwork where ArtworkID={artWorkID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            List<Artwork> artList = new List<Artwork>();
            Artwork art = new Artwork();

            while (rd.Read())
            {
                art = new Artwork();
                art.ArtworkId = (int)rd["ArtworkID"];

                if(art.ArtworkId==artWorkID)
                {
                    art.ArtistId = (int)rd["ArtistID"];
                    art.Title = (string)rd["Title"];
                    art.Description = (string)rd["Description"];
                    art.CreationDate = (DateTime)rd["creationDate"];
                    art.Medium = (string)rd["medium"];
                    art.ImageURL = (string)rd["ImageURL"];
                    artList.Add(art);
                }
            }
            rd.Close();
            return artList;

        }
        #endregion

        #region BrowseArtworks - V
        public List<Artwork> BrowseArtworks(SqlConnection conn)
        {
            string query = "SELECT * FROM Artwork";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            List<Artwork> artList = new List<Artwork>();
            Artwork art = new Artwork();

            while (rd.Read())
            {
                art = new Artwork();
                art.ArtistId = (int)rd["ArtistID"];
                art.ArtworkId = (int)rd["ArtworkID"];
                art.Title = (string)rd["Title"];
                art.Description = (string)rd["Description"];
                art.CreationDate = (DateTime)rd["creationDate"];
                art.Medium = (string)rd["medium"];
                art.ImageURL = (string)rd["ImageURL"];
                artList.Add(art);
            }
            rd.Close();
            return artList;

        }

#endregion

        #region AddArtworktoFav - V
        public bool AddArtworktoFav(SqlConnection conn,int userID)
        {
            Console.WriteLine("Enter artwork ID to add to favorites");
            int favID = int.Parse(Console.ReadLine());

            string query = $"INSERT INTO USER_FAVORITE_ARTWORK VALUES({userID},{favID});";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n=cmd.ExecuteNonQuery();

            if (n==0)
            {
                Console.WriteLine("Error ! Not added");
                return false;
            }
                
            else
            {
                return true;
            }

        }
        #endregion

        #region RemoveArtworkFromFav - V
        public bool RemoveArtworkFromFav(SqlConnection conn, int userID)
        {
            Console.WriteLine("Enter artwork ID to remove from favorites");
            int favID = int.Parse(Console.ReadLine());

            string query = $"DELETE FROM USER_FAVORITE_ARTWORK WHERE UserID={userID} AND ArtworkID={favID};";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n = cmd.ExecuteNonQuery();

            if (n == 0)
            {
                Console.WriteLine("Error ! Cannot remove the artwork since it doesnot exist");
                return false;
            }

            else
            {
                return true;
            }


        }
        #endregion

        #region ShowFavList - V
        public List<Artwork> ShowFavList(SqlConnection conn, int userID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT P3.ARTWORKID, P3.ARTISTID, ");
            sb.Append("P3.TITLE, P3.DESCRIPTION, P3.CREATIONDATE, P3.MEDIUM, P3.IMAGEURL ");
            sb.Append("FROM USERS P1 ");
            sb.Append("INNER JOIN USER_FAVORITE_ARTWORK P2 ");
            sb.Append("ON P1.UserID = P2.UserID ");
            sb.Append("INNER JOIN ARTWORK P3 ");
            sb.Append("ON P2.ArtworkID = P3.ArtworkID ");
            sb.Append($"WHERE P1.UserID = {userID}");

            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            SqlDataReader n = cmd.ExecuteReader();

            Artwork art;
            List<Artwork> artList = new List<Artwork>();
            while(n.Read())
            {
                art = new Artwork();
                art.ArtworkId = (int)n["ArtworkID"];
                art.ArtistId = (int)n["ArtistID"];
                art.Title = (string)n["Title"];
                art.Description = (string)n["Description"];
                //art.CreationDate = (DateOnly)n["creationDate"];
                art.Medium = (string)n["medium"];
                art.ImageURL = (string)n["ImageURL"];
                artList.Add(art);
            }
            n.Close();
            return artList;

        }

        #endregion

        #region SearchArtworkByKeyword - V
        public List<Artwork> SearchArtworkByKeyword(SqlConnection conn, string keyword)
        {

            string query = "SELECT * FROM Artwork";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            List<Artwork> artList = new List<Artwork>();
            Artwork art = new Artwork();

            while (rd.Read())
            {
                art = new Artwork();

                StringBuilder sb = new StringBuilder();
                sb.Append(rd[0]);
                sb.Append(rd[1]);
                sb.Append(rd[2]);
                sb.Append(rd[3]);
                sb.Append(rd[4]);
                sb.Append(rd[5]);

                if (sb.ToString().Contains(keyword))
                {
                    art.ArtistId = (int)rd["ArtistID"];
                    art.Title = (string)rd["Title"];
                    art.Description = (string)rd["Description"];
                    art.CreationDate = (DateTime)rd["creationDate"];
                    art.Medium = (string)rd["medium"];
                    art.ImageURL = (string)rd["ImageURL"];
                    artList.Add(art);
                }
            }
            rd.Close();
            return artList;

        }
        #endregion

        #region AddArtwork - V
        public bool AddArtwork(SqlConnection conn,Artwork artwork)
        {
            string query;

            query = "INSERT INTO ARTWORK VALUES(@artworkID,@artistID,@title,@description,@creationDate,@medium,@ImageURL)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@artworkID", artwork.ArtworkId);
            cmd.Parameters.AddWithValue("@artistID", artwork.ArtistId);
            cmd.Parameters.AddWithValue("@title", artwork.Title);
            cmd.Parameters.AddWithValue("@description", artwork.Description);
            cmd.Parameters.AddWithValue("@creationDate", artwork.CreationDate);
            cmd.Parameters.AddWithValue("@medium", artwork.Medium);
            cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);

            int n = cmd.ExecuteNonQuery();
            if (n == 1)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region Update Artwork - V
        public bool UpdateArtwork(SqlConnection conn,Artwork artwork)
        {
            SqlCommand cmd;
            int t;
            string query;
            do
            {
                Console.WriteLine("Enter what you want to update\n1. ArtistID \n2. Title\n" +
                    "3. Description\n4. Medium \n5. Creation Date\n");
                int choice = int.Parse(Console.ReadLine()), n;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Enter the new ArtistID");
                        int artistID = int.Parse(Console.ReadLine());
                        query = $"UPDATE ARTWORK SET artistID={artistID} WHERE ARTWORKID={artwork.ArtworkId}";
                        artwork.ArtistId = artistID;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;

                    case 2:
                        Console.WriteLine("Enter new Title");
                        string title = Console.ReadLine();
                        query = $"UPDATE ARTWORK SET title={title} WHERE ARTWORKID={artwork.ArtworkId}";
                        artwork.Title = title;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;
                    case 3:
                        Console.WriteLine("Enter new Description");
                        string description = Console.ReadLine();
                        query = $"UPDATE ARTWORK SET description={description} WHERE ARTWORKID={artwork.ArtworkId}";
                        artwork.Description = description;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;
                    case 4:
                        Console.WriteLine("Enter new Medium");
                        string medium = Console.ReadLine();
                        query = $"UPDATE ARTWORK SET Medium={medium} WHERE ARTWORKID={artwork.ArtworkId}";
                        artwork.Medium = medium;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;

                    default:
                        n = 0;
                        Console.WriteLine("Wrong Option! Try Again");
                        break;

                }
                if (n == 1)
                    Console.WriteLine("Successfully Changed");

                Console.WriteLine("Update other attributes ? -1 ;Exit? - 0");
                t = int.Parse(Console.ReadLine());
                if (t == 0)
                    break;
            } while (true);
            return true;

        }
        #endregion

        #region RemoveArtwork - V
        public bool RemoveArtwork(SqlConnection conn,int artWorkID)
        {

            string query = $"DELETE FROM ARTWORK WHERE ARTWORKID={artWorkID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n = cmd.ExecuteNonQuery();
            if (n == 0)
            {
                throw new ArtworkNotFoundException($"No Artwork found with this {artWorkID}");
            }
            else
            {
                return true;
            }
                
        }
        #endregion

        #region AdminLogin - V

        public void AdminLogin(SqlConnection conn)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Admin Logged in Successfully");
            Console.WriteLine("");

            List<Artwork> artList = new List<Artwork>();

            bool result;

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("1. Add Artwork\n2. Update Artwork\n3. Remove Artwork\n4. Browse Artworks\n5. Logout");
                Console.WriteLine(" ");
                Console.WriteLine("Choose 1-5");
                int choice = int.Parse(Console.ReadLine());

                Artwork artwork;


                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Enter ArtworkID");
                        int artworkID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter ArtistID");
                        int artistID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Title");
                        string title = Console.ReadLine();

                        Console.WriteLine("Enter Description");
                        string description = Console.ReadLine();

                        Console.WriteLine("Enter Medium");
                        string medium = Console.ReadLine();

                        DateTime creationDate = new DateTime(2023, 10, 12);

                        Console.WriteLine("Enter Picture URL");
                        string ImageURL = Console.ReadLine();

                        artwork = new Artwork();
                        artwork.ArtworkId = artworkID;
                        artwork.ArtistId = artistID;
                        artwork.Title = title;
                        artwork.Description = description;
                        artwork.Medium = medium;
                        artwork.CreationDate = creationDate;
                        artwork.ImageURL = ImageURL;

                        result=AddArtwork(conn,artwork);
                        if(result==true)
                            Console.WriteLine("Artwork Added Successfully");
                        else
                            Console.WriteLine("Could not add Artwork");
                        break;
                    case 2:
                        Console.WriteLine("Enter the ArtworkID you want to update?");
                        int artWorkID = int.Parse(Console.ReadLine());

                        string query = $"SELECT * FROM ARTWORK WHERE ARTWORKID={artWorkID}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader rd = cmd.ExecuteReader();

                        if(!rd.HasRows)
                        {
                            Console.WriteLine("Artwork Not Found");
                            break;
                        }
                        rd.Read();
                        artwork = new Artwork();
                        artwork.ArtworkId = artWorkID;
                        artwork.ArtistId = (int)rd["ArtistID"];
                        artwork.Title = (string)rd["title"];
                        artwork.Description = (string)rd["description"];
                        artwork.Medium = (string)rd["medium"];
                        artwork.CreationDate = (DateTime)rd["creationDate"];
                        artwork.ImageURL = (string)rd["ImageURL"];
                        rd.Close();
                        result=UpdateArtwork(conn,artwork);

                        if (result == true)
                            Console.WriteLine("Artwork Updates Successfull");
                        else
                            Console.WriteLine("Could not update Artwork");

                        break;
                    case 3:
                        Console.WriteLine("Enter the ArtworkID you want to remove");
                        int artID = int.Parse(Console.ReadLine());
                        result=RemoveArtwork(conn,artID);
                        if(result==true)
                            Console.WriteLine("Artwork Successfully Removed");
                        else
                            Console.WriteLine("Cannot remove Artwork");
                        break;
                    case 4:
                        artList=BrowseArtworks(conn);
                        Console.WriteLine("The present Artworks are \n");
                        foreach(Artwork art in artList)
                            Console.WriteLine(art);
                        break;
                    case 5:
                    default:
                        Console.WriteLine("Logged out successfully");
                        break;
                }
                if (choice == 5)
                    break;
            } while (true);

        }

        #endregion

        #region login - V
        public void Login(SqlConnection conn)
		{
            List<Artwork> artList = new List<Artwork>();
            List<Artist> artistList = new List<Artist>();
            List<Users> usersList = new List<Users>();
            List<Gallery> galList = new List<Gallery>();
            bool result;

            Console.WriteLine("Enter Username");
            string userName = (Console.ReadLine());

            Console.WriteLine("Enter Password");
            string passWord = (Console.ReadLine());

            if (userName == "admin" && passWord == "admin")
                AdminLogin(conn);
            else
            {


                Console.WriteLine("Enter User ID");
                int userID = int.Parse(Console.ReadLine());

                string query = $"SELECT * FROM USERS WHERE USERID={userID};";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (!dataReader.HasRows)
                {
                    throw new UserNotFoundException("User does not exist");
                }



                if ((int)dataReader[0] == userID && (string)dataReader[1] == userName && (string)dataReader[2] == passWord)
                {
                    dataReader.Close();
                    Console.WriteLine("");
                    Console.WriteLine("Successfully Logged In !");
                    Console.WriteLine("");
                trail:
                    Console.WriteLine("");
                    Console.WriteLine("1. Add artwork to favorite\n2. Remove artwork from favorite\n" +
                        "3. Get favorite list\n4. View Galleries\n5. User Profile\n" +
                        "6. Browse ArtWorks\n7. Search Artist By ID\n8. Search Art by ID\n" +
                        "9. Search Art By Keyword\n10. Logout");
                    Console.WriteLine("");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            result=AddArtworktoFav(conn, userID);
                            if(result==true)
                            {
                                Console.WriteLine("Artwork Successfully added to Favorites\n");
                            }
                            goto trail;

                        case 2:
                            result=RemoveArtworkFromFav(conn, userID);
                            if (result == true)
                            {
                                Console.WriteLine("Artwork Successfully removed from Favorites\n");
                            }
                            goto trail;

                        case 3:
                            artList=ShowFavList(conn, userID);
                            Console.WriteLine("Your Favorite Artworks are\n\n");

                            if(artList.Count==0)
                                Console.WriteLine("None to show");

                            foreach(Artwork art in artList)
                                Console.WriteLine(art);

                            goto trail;
                        case 4:
                            galList=ViewGalleries(conn);
                            Console.WriteLine("The Galleries Present are !");

                            if(galList.Count==0)
                                Console.WriteLine("None to show");

                            foreach (Gallery gal in galList)
                                Console.WriteLine(gal);

                            goto trail;
                        case 5:
                            usersList=UserProfile(conn, userID);
                            Console.WriteLine("Your User Profile is\n");

                            foreach(Users u in usersList)
                            Console.WriteLine(u);
                            goto trail;
                        case 6:
                            artList=BrowseArtworks(conn);
                            Console.WriteLine("Artworks present in the Gallery : \n\n");

                            if (artList.Count == 0)
                                Console.WriteLine("None to show");

                            foreach (Artwork art in artList)
                                Console.WriteLine(art);

                            goto trail;
                        case 7:
                            Console.WriteLine("Enter ArtistID to search for");
                            int artistID = int.Parse(Console.ReadLine());
                            artistList = SearchArtist(conn, artistID);

                            if (artistList.Count == 0)
                                Console.WriteLine("None to show");

                            foreach (Artist artist in artistList)
                                Console.WriteLine(artist);

                            goto trail;
                        case 8:
                            Console.WriteLine("Enter Artwork ID to search for");
                            int artWorkID = int.Parse(Console.ReadLine());
                            artList=SearchArtworkByID(conn,artWorkID);

                            if (artList.Count == 0)
                                Console.WriteLine("None to show");

                            foreach (Artwork art in artList)
                                Console.WriteLine(art);

                            goto trail;
                        case 9:
                            Console.WriteLine("Enter the keyword to search for");
                            string keyword = Console.ReadLine();
                            artList=SearchArtworkByKeyword(conn,keyword);
                            if (artList.Count == 0)
                                Console.WriteLine("None to show");
                            foreach (Artwork art in artList)
                                Console.WriteLine(art);
                            goto trail;
                        case 10:
                        default:
                            Console.WriteLine("Logout? Yes -1 No -0");
                            int c = int.Parse(Console.ReadLine());
                            if (c == 0)
                                goto trail;
                            else
                                break;
                    }

                }
                else if ((int)dataReader[0] == userID)
                    Console.WriteLine("User Exists. But Wrong Credentials given");
                else
                    throw new UserNotFoundException("The UserID you entered is not found!");

            }
        }
        #endregion

        #region Register
        public bool Register(SqlConnection conn)
        {
            Users users = new Users();

            Console.WriteLine("Hello New User!");
            Console.WriteLine("Enter userID");
            users.UserID = int.Parse(Console.ReadLine());

            string query = $"SELECT * FROM USERS WHERE UserID={users.UserID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n;
            SqlDataReader rd= cmd.ExecuteReader();

            if(rd.HasRows)
                throw new UserAlreadyRegistered("You have already been registered");
            rd.Close();
            Console.WriteLine("Enter username");
            users.UserName = (Console.ReadLine());

            Console.WriteLine("Enter password");
            users.Password= (Console.ReadLine());

            Console.WriteLine("Enter email");
            users.Email = (Console.ReadLine());

            Console.WriteLine("Enter first name");
            users.FirstName = (Console.ReadLine());

            Console.WriteLine("Enter last name");
            users.LastName = (Console.ReadLine());

            Console.WriteLine("Enter profile picture URL");
            users.ProfilePicture = (Console.ReadLine());

            users.DateOfBirth = new DateTime(2023, 10, 12);

            query = "INSERT INTO USERS VALUES(@userID,@userName,@passWord,@email,@first_Name,@last_Name,@date_Of_Birth,@profile_Picture)";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", users.UserID);
            cmd.Parameters.AddWithValue("@userName", users.UserName);
            cmd.Parameters.AddWithValue("@password", users.Password);
            cmd.Parameters.AddWithValue("@email", users.Email);
            cmd.Parameters.AddWithValue("@first_Name", users.FirstName);
            cmd.Parameters.AddWithValue("@last_Name", users.LastName);
            cmd.Parameters.AddWithValue("@date_Of_Birth", users.DateOfBirth);
            cmd.Parameters.AddWithValue("@profile_Picture", users.ProfilePicture);
            
            n = cmd.ExecuteNonQuery();
            if (n == 1)
            {
                Console.WriteLine("Succesfully Registered");
                return true;
            }
            return false;

        }
        #endregion
    }
}

