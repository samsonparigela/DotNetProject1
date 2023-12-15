using Microsoft.Data.SqlClient;
using VirtualArtGallery2.ArtgalleryRepository;

namespace VirtualArtGallery2;
internal class Program
{
    private static void Main(string[] args)
    {
        trail:
        try
        {
            SqlConnection conn = DBConnection.Connect();
            IIntermediate intermediate=new Intermediate();

            #region Menu
            do
            {
                int choice;
                Console.WriteLine(" ");
                Console.WriteLine("-----VIRTUAL ART GALLERY-----\n\n");
                Console.WriteLine("1. Login\n" +
                    "2. Register\n");

                Console.WriteLine("Please Enter Your Choice ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        intermediate.Login(conn);
                        break;
                    case 2:
                        intermediate.Register(conn);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice! Unlike the ones you make in Life\n");
                        break;

                }



            } while (true);
            #endregion
        }
        catch(IOException IOex)
        {
            Console.WriteLine("Input Error! Try AGAIN");
            Console.WriteLine(IOex.Message, IOex.StackTrace);
        }
        catch(SqlException Sqlex)
        {
            Console.WriteLine("Database Error! Try exploring again");
            Console.WriteLine(Sqlex.Message, Sqlex.StackTrace);
        }
        catch(FormatException Fex)
        {
            Console.WriteLine("Input expected different data type! Given different one");
            Console.WriteLine(Fex.Message, Fex.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message, e.StackTrace);
        }
        finally
        {
            Console.WriteLine("Try Again Now!");
        }
        goto trail;

    }

}