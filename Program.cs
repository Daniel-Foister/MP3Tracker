/**
*--------------------------------------------------------------------
* File name: 1260-002-FoisterDaniel-Project4
* Project name: Project4-MP3TrackerWithFiles
*--------------------------------------------------------------------
* Author’s name and email: Daniel Foister, foisterda@etsu.edu
* Course-Section: CSCI-1260-002
* Creation Date: 4/4/23
* -------------------------------------------------------------------
*/
namespace Project4_MP3TrackerWithFiles
{
    internal class Program
    {
        public static MP3 userMP3;
        public static Playlist userPlaylist;
        private static string filePath;

        static void Main(string[] args)
        {
            Welcome();

            string userName = "";
            bool userNameSuccess = false;
            while (!userNameSuccess)
            {
                Console.Write("Please enter your name: ");
                userName = Console.ReadLine();
                Console.WriteLine();

                if (userName == "")
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                }
                else
                {
                    userNameSuccess = true;
                }
            }

            int userInput = 0;
            do
            {
                bool menuSuccess = false;
                while (!menuSuccess)
                {
                    try
                    {
                        DisplayMenu();
                        Console.Write("\tMenu Choice: ");
                        userInput = int.Parse(Console.ReadLine());

                        menuSuccess = true;
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    }
                }
                Console.WriteLine();
                MenuChoice(userInput);
            }
            while (userInput != 13);

            if (userPlaylist != null)
            {
                EndSave();
            }

            string exit1 = "Goodbye and thank you for using the MP3 Tracker,";
            string exit2 = $"{userName.ToUpper()}\n";
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (exit1.Length / 2)) + "}", exit1));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (exit2.Length / 2)) + "}", exit2));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
        }

        private static void Welcome()
        {
            string intro1 = "Project: MP3 Tracker";
            string intro2 = "This project demonstrates the functionality of the MP3 Class.";
            string intro3 = "----";
            string intro4 = "Created by Daniel Foister";

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro1.Length / 2)) + "}", intro1));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro2.Length / 2)) + "}", intro2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro3.Length / 2)) + "}", intro3));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro4.Length / 2)) + "}", intro4));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
        }

        private static void DisplayMenu()
        {
            string menu = "Menu";
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (menu.Length / 2)) + "}", menu));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t1.  Create a new Playlist for the MP3 Tracker");
            Console.WriteLine("\t2.  Create a new MP3 File");
            Console.WriteLine("\t3.  Edit an Existing MP3 File from the Playlist");
            Console.WriteLine("\t4.  Drop an MP3 File from the Playlist");
            Console.WriteLine("\t5.  Display all MP3 Files in the Playlist");
            Console.WriteLine("\t6.  Find and Display an MP3 File by Song Title");
            Console.WriteLine("\t7.  Display all MP3 Files of a given Genre");
            Console.WriteLine("\t8.  Display all MP3 Files of a given Artist");
            Console.WriteLine("\t9.  Sort MP3 Files by Song Title");
            Console.WriteLine("\t10. Sort MP3 Files by Song Release Date");
            Console.WriteLine("\t11. Restore the Previous Playlist");
            Console.WriteLine("\t12. Save the Current Playlist");
            Console.WriteLine("\t13. Exit");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
        }

        private static void MenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    CreatePlaylist();
                    break;
                case 2:
                    CreateMP3();
                    break;
                case 3:
                    EditMP3();
                    break;
                case 4:
                    DropMP3();
                    break;
                case 5:
                    DisplayMP3();
                    break;
                case 6:
                    DisplaySongTitle();
                    break;
                case 7:
                    DisplayGenre();
                    break;
                case 8:
                    DisplayArtist();
                    break;
                case 9:
                    SortMP3Title();
                    break;
                case 10:
                    SortMP3ReleaseDate();
                    break;
                case 11:
                    RestorePlaylist();
                    break;
                case 12:
                    SavePlaylist();
                    break;
                case 13:
                    break;
                default:
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Please try again using a number between 1 and 13.\n");
                    break;
            }
        }

        private static void CreatePlaylist()
        {
            //I made the assumption that if a user creates a playlist but does not add anything to it,
            //then the program should not ask them if they want to save. However, they can save it manually 
            //using option 12.
            if (userMP3 != null)
            {
                //Might need something extra here - Daniel Note
                string endSave = "Would you like to save your current playlist before creating a new one?";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (endSave.Length / 2)) + "}", endSave));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string saveChoice = "";
                bool endSaveSuccess = false;
                while (!endSaveSuccess)
                {
                    Console.Write("Y/N: ");
                    saveChoice = Console.ReadLine().ToUpper();

                    if (saveChoice == "Y" || saveChoice == "N")
                    {
                        Console.WriteLine();
                        endSaveSuccess = true;
                    }
                    else
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"Invalid input, you can only enter a Y (yes) or N (no). Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
                if (saveChoice == "Y")
                {
                    SavePlaylist();
                }

                Console.WriteLine();
            }

            string createPlaylist = "Create a Playlist";
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (createPlaylist.Length / 2)) + "}", createPlaylist));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

            string playlistName = "";
            bool playlistNameSuccess = false;
            while (!playlistNameSuccess)
            {
                Console.Write("Please enter the playlist's name: ");
                playlistName = Console.ReadLine().Trim();

                if (playlistName == "")
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    playlistNameSuccess = true;
                }
            }

            string playlistCreator = "";
            bool playlistCreatorSuccess = false;
            while (!playlistCreatorSuccess)
            {
                Console.Write("Please enter the creator name: ");
                playlistCreator = Console.ReadLine().Trim();

                if (playlistCreator == "")
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    playlistCreatorSuccess = true;
                }
            }

            string playlistCreationDate = "";
            bool playlistDateSuccess = false;
            while (!playlistDateSuccess)
            {
                Console.Write("Please enter the creation date: ");
                playlistCreationDate = Console.ReadLine().Trim();

                if (playlistCreationDate == "")
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    playlistDateSuccess = true;
                }
            }

            userPlaylist = new Playlist(playlistName, playlistCreator, playlistCreationDate);
        }

        private static void CreateMP3()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else
            {
                string createMP3 = "Create an MP3";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (createMP3.Length / 2)) + "}", createMP3));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                string userSong = "";
                bool titleSuccess = false;
                while (!titleSuccess)
                {
                    Console.Write("\nPlease enter the song's title: ");
                    userSong = Console.ReadLine().Trim();

                    if (userSong == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        titleSuccess = true;
                    }
                }

                string userArtist = "";
                bool artistSuccess = false;
                while (!artistSuccess)
                {
                    Console.Write("\nPlease enter the artist's name: ");
                    userArtist = Console.ReadLine().Trim();

                    if (userArtist == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        artistSuccess = true;
                    }
                }

                string userReleaseDate = "";
                bool releaseDateSuccess = false;
                while (!releaseDateSuccess)
                {
                    Console.Write("\nPlease enter the release date (mm/dd/yyyy): ");
                    userReleaseDate = Console.ReadLine().Trim();

                    if (userReleaseDate == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        releaseDateSuccess = true;
                    }
                }

                double userPlaybackTime = 0.0;
                bool playbackTimeSuccess = false;
                while (!playbackTimeSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the playback time (minutes): ");
                        userPlaybackTime = double.Parse(Console.ReadLine().Trim());

                        if (userPlaybackTime <= 0.0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            playbackTimeSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                Genre userGenre = Genre.POP;
                string userStringGenre = "";
                bool genreSuccess = false;
                while (!genreSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the song's genre (Rock, Pop, Jazz, Country, Classical, Other): ");
                        userStringGenre = Console.ReadLine().Trim().ToUpper();

                        //I know there is a better way to do this, but I could not figure out how. This should suffice even though it looks awful.
                        //Also, the try-catch really isn't neccessary anymore, but I kept it because I am changing this once I figure out the better way to do it.
                        if (userStringGenre == "ROCK" || userStringGenre == "POP" || userStringGenre == "JAZZ" || userStringGenre == "COUNTRY" || userStringGenre == "CLASSICAL" || userStringGenre == "OTHER")
                        {
                            userGenre = (Genre)Enum.Parse(typeof(Genre), userStringGenre);
                            genreSuccess = true;
                        }
                        else
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be one of the listed Genre's above. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be one of the listed Genre's above. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                decimal userCostToDownload = 0;
                bool costDownloadSuccess = false;
                while (!costDownloadSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the cost to download: $");
                        userCostToDownload = decimal.Parse(Console.ReadLine().Trim());

                        if (userCostToDownload < 0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            costDownloadSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                double userFileSize = 0;
                bool fileSizeSuccess = false;
                while (!fileSizeSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the size of the file (MB): ");
                        userFileSize = double.Parse(Console.ReadLine().Trim());

                        if (userFileSize <= 0.0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            fileSizeSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                string userAlbumCover = "";
                bool albumCoverSuccess = false;
                while (!albumCoverSuccess)
                {
                    Console.Write("\nPlease enter the path of the album cover photo: ");
                    userAlbumCover = Console.ReadLine().Trim();

                    if (userAlbumCover == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        albumCoverSuccess = true;
                    }
                }

                userMP3 = new MP3(userSong, userArtist, userReleaseDate, userPlaybackTime, userGenre, userCostToDownload, userFileSize, userAlbumCover);

                userPlaylist.AddMP3(userMP3);
            }
        }

        private static void EditMP3()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string edit = "Edit a MP3 File";
                string arrow1 = "| | |";
                string arrow2 = "V V V";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (edit.Length / 2)) + "}", edit));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (arrow1.Length / 2)) + "}", arrow1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (arrow2.Length / 2)) + "}", arrow2));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                DisplayMP3();

                int userEdit = 0;
                bool editSuccess = false;
                while (!editSuccess)
                {
                    try
                    {
                        Console.Write("Please enter the numbered index of the MP3 File above that you wish to edit: ");
                        userEdit = int.Parse(Console.ReadLine().Trim());

                        userPlaylist.RemoveMP3(userEdit);

                        editSuccess = true;
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must an integer of the numbered index above. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                string userEditSong = "";
                bool titleSuccess = false;
                while (!titleSuccess)
                {
                    Console.Write("\nPlease enter the song's title: ");
                    userEditSong = Console.ReadLine().Trim();

                    if (userEditSong == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        titleSuccess = true;
                    }
                }

                string userEditArtist = "";
                bool artistSuccess = false;
                while (!artistSuccess)
                {
                    Console.Write("\nPlease enter the artist's name: ");
                    userEditArtist = Console.ReadLine().Trim();

                    if (userEditArtist == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        artistSuccess = true;
                    }
                }

                string userEditReleaseDate = "";
                bool releaseDateSuccess = false;
                while (!releaseDateSuccess)
                {
                    Console.Write("\nPlease enter the release date (mm/dd/yyyy): ");
                    userEditReleaseDate = Console.ReadLine().Trim();

                    if (userEditReleaseDate == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        releaseDateSuccess = true;
                    }
                }

                double userEditPlaybackTime = 0.0;
                bool playbackTimeSuccess = false;
                while (!playbackTimeSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the playback time (minutes): ");
                        userEditPlaybackTime = double.Parse(Console.ReadLine().Trim());

                        if (userEditPlaybackTime <= 0.0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            playbackTimeSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                Genre userEditGenre = Genre.POP;
                string userStringGenre = "";
                bool genreSuccess = false;
                while (!genreSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the song's genre (Rock, Pop, Jazz, Country, Classical, Other): ");
                        userStringGenre = Console.ReadLine().Trim().ToUpper();

                        //I know there is a better way to do this, but I could not figure out how. This should suffice even though it looks awful.
                        //Also, the try-catch really isn't neccessary anymore, but I kept it because I am changing this once I figure out the better way to do it.
                        if (userStringGenre == "ROCK" || userStringGenre == "POP" || userStringGenre == "JAZZ" || userStringGenre == "COUNTRY" || userStringGenre == "CLASSICAL" || userStringGenre == "OTHER")
                        {
                            userEditGenre = (Genre)Enum.Parse(typeof(Genre), userStringGenre);
                            genreSuccess = true;
                        }
                        else
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be one of the listed Genre's above. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be one of the listed Genre's above. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                decimal userEditCostToDownload = 0;
                bool costDownloadSuccess = false;
                while (!costDownloadSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the cost to download: $");
                        userEditCostToDownload = decimal.Parse(Console.ReadLine().Trim());

                        if (userEditCostToDownload < 0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            costDownloadSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                double userEditFileSize = 0;
                bool fileSizeSuccess = false;
                while (!fileSizeSuccess)
                {
                    try
                    {
                        Console.Write("\nPlease enter the size of the file (MB): ");
                        userEditFileSize = double.Parse(Console.ReadLine().Trim());

                        if (userEditFileSize <= 0.0)
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must be a positve integer. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            fileSizeSuccess = true;
                        }
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

                string userEditAlbumCover = "";
                bool albumCoverSuccess = false;
                while (!albumCoverSuccess)
                {
                    Console.Write("\nPlease enter the path of the album cover photo: ");
                    userEditAlbumCover = Console.ReadLine().Trim();

                    if (userEditAlbumCover == "")
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        albumCoverSuccess = true;
                    }
                }

                userMP3 = new MP3(userEditSong, userEditArtist, userEditReleaseDate, userEditPlaybackTime, userEditGenre, userEditCostToDownload, userEditFileSize, userEditAlbumCover);

                userPlaylist.EditMP3(userEdit, userMP3);
            }
        }

        private static void DropMP3()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string remove = "Remove a MP3 File";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (remove.Length / 2)) + "}", remove));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                DisplayMP3();

                bool removalSuccess = false;
                while (!removalSuccess)
                {
                    try
                    {
                        Console.Write("Please enter the numbered index of the MP3 File above that you wish to remove: ");
                        int userRemoval = int.Parse(Console.ReadLine().Trim());

                        userPlaylist.RemoveMP3(userRemoval);

                        removalSuccess = true;
                    }
                    catch (FormatException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be an integer. Please try again\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must an integer of the listed numbered index. Please try again\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }

            }
        }

        private static void DisplayMP3()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string display = "Available MP3 Files";
                string arrow1 = "| | |";
                string arrow2 = "V V V";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (display.Length / 2)) + "}", display));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (arrow1.Length / 2)) + "}", arrow1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (arrow2.Length / 2)) + "}", arrow2));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string displayPlaylist = $"Custom Playlist";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displayPlaylist.Length / 2)) + "}", displayPlaylist));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine(userPlaylist.ToString());
                userPlaylist.DisplayAllMP3();
            }
        }

        private static void DisplaySongTitle()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string displaySongTitle = "Display an MP3 (Song Title)";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displaySongTitle.Length / 2)) + "}", displaySongTitle));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string songTitle = "";
                bool displayTitleSuccess = false;
                while (!displayTitleSuccess)
                {
                    try
                    {
                        Console.Write("Please enter the Song Title of the MP3 File you are searching for: ");
                        songTitle = Console.ReadLine().Trim();

                        userPlaylist.SongTitleDisplay(songTitle);

                        displayTitleSuccess = true;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be the Song Title of an already existing MP3 File. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        private static void DisplayGenre()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string displayGenre = "Display all MP3 Files (Genre)";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displayGenre.Length / 2)) + "}", displayGenre));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                Genre searchGenre = Genre.POP;
                string searchStringGenre = "";
                bool genreSuccess = false;
                while (!genreSuccess)
                {
                    try
                    {
                        Console.Write("Please enter the Genre of the MP3 Files you wish to display (Rock, Pop, Jazz, Country, Classical, Other): ");
                        searchStringGenre = Console.ReadLine().Trim().ToUpper();

                        //I know there is a better way to do this, but I could not figure out how. This should suffice even though it looks awful.
                        //Also, the try-catch really isn't neccessary anymore, but I kept it because I am changing this once I figure out the better way to do it.
                        if (searchStringGenre == "ROCK" || searchStringGenre == "POP" || searchStringGenre == "JAZZ" || searchStringGenre == "COUNTRY" || searchStringGenre == "CLASSICAL" || searchStringGenre == "OTHER")
                        {
                            searchGenre = (Genre)Enum.Parse(typeof(Genre), searchStringGenre);
                            userPlaylist.DisplayAllMP3Genre(searchGenre);

                            genreSuccess = true;
                        }
                        else
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, your input must one of the listed Genre's above. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be the Genre of an already existing MP3 File. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        private static void DisplayArtist()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string displayArtist = "Display all MP3 Files (Artist)";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displayArtist.Length / 2)) + "}", displayArtist));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string searchArtist = "";
                bool displayArtistSuccess = false;
                while (!displayArtistSuccess)
                {
                    try
                    {
                        Console.Write("Please enter the existing Artist Name of the MP3 Files you wish to display: ");
                        searchArtist = Console.ReadLine().Trim();

                        if (searchArtist == "")
                        {
                            string invalid = "Invalid Input";
                            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Sorry, you have to enter something. Please try again.\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        }
                        else
                        {
                            userPlaylist.DisplayAllMP3Artist(searchArtist);
                            displayArtistSuccess = true;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Sorry, your input must be the Song Artist of an already existing MP3 File. Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"An unexpected error occured: {e.Message} Please try again.");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        private static void SortMP3Title()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string displaySortedTitle = "MP3 Files Have Been Sorted By Song Title";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displaySortedTitle.Length / 2)) + "}", displaySortedTitle));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                userPlaylist.SongSortTitle();
            }
        }

        private static void SortMP3ReleaseDate()
        {
            if (userPlaylist == null)
            {
                Console.WriteLine("No Playlist was found. Please use option 1 before using this option\n");
            }
            else if (userMP3 == null)
            {
                Console.WriteLine("No MP3 File was found. Please use option 2 before using this option\n");
            }
            else
            {
                string displaySortedDate = "MP3 Files Have Been Sorted by Song Release Date";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (displaySortedDate.Length / 2)) + "}", displaySortedDate));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                userPlaylist.SortSongReleaseDate();
            }
        }

        private static void RestorePlaylist()
        {
            string restorePlaylist = "Playlist Restoration";
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (restorePlaylist.Length / 2)) + "}", restorePlaylist));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            bool playlistSuccess = false;
            while (!playlistSuccess)
            {
                try
                {
                    //  ..\..\..\PlaylistData\Songs.Txt
                    Console.WriteLine(@"Psst --> ..\\..\\..\\PlaylistData\\Songs.Txt");
                    Console.Write("\nPlease enter the file path of the Playlist you want to restore: ");
                    filePath = Console.ReadLine();

                    using (StreamReader readPlaylist = new StreamReader(filePath))
                    {
                        string lineText = readPlaylist.ReadLine();
                        string[] fields = lineText.Split("|");

                        userPlaylist = new Playlist(fields[0], fields[1], fields[2]);

                        while (readPlaylist.Peek() != -1)
                        {
                            lineText = readPlaylist.ReadLine();

                            fields = lineText.Split("|");

                            userMP3 = new MP3(fields[0], fields[1], fields[2], double.Parse(fields[3]), (Genre)Enum.Parse(typeof(Genre), fields[4]), decimal.Parse(fields[5]), double.Parse(fields[6]), fields[7]);
                            userPlaylist.AddMP3(userMP3);
                        }
                    }

                    playlistSuccess = true;
                }
                catch (ArgumentException e)
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("The file path entered contains nothing. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                catch (FileNotFoundException e)
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("The file at the end of the path cannot be found. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                catch (DirectoryNotFoundException e)
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("The file path entered does not exist. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                catch (IOException e)
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("The file path entered has incorrect syntax. Please try again.\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                catch (Exception e)
                {
                    string invalid = "Invalid Input";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine($"Something went wrong with accessing the file: {e.Message}\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
            }

            userPlaylist.SetSaveNeeded(false);
            string restoreSuccess = "The Previous Playlist Has Been Restored!";
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (restoreSuccess.Length / 2)) + "}", restoreSuccess));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
        }

        private static void SavePlaylist()
        {
            if (userPlaylist != null && userMP3 == null)
            {
                string endSave = "You are about to save any Empty Playlist. Would you still like to save?";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (endSave.Length / 2)) + "}", endSave));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string saveChoice = "";
                bool endSaveSuccess = false;
                while (!endSaveSuccess)
                {
                    Console.Write("Y/N: ");
                    saveChoice = Console.ReadLine().ToUpper();

                    if (saveChoice == "Y" || saveChoice == "N")
                    {
                        Console.WriteLine();
                        endSaveSuccess = true;
                    }
                    else
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"Invalid input, you can only enter a Y (yes) or N (no). Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                    filePath = @"..\\..\\..\\PlaylistData\\Songs.Txt";
                    try
                    {
                        using (StreamWriter writeBook = new StreamWriter(filePath))
                        {
                            Playlist savedPlaylist = userPlaylist;

                            writeBook.WriteLine(savedPlaylist.GetPlaylistName() + "|" + savedPlaylist.GetCreatorName() + "|" + savedPlaylist.GetCreationDate());
                        }
                        string savePlaylist = "Playlist Has Been Saved!";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (savePlaylist.Length / 2)) + "}", savePlaylist));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    }
                    catch (Exception e)
                    {
                        string invalid = "Playlist Was Not Saved";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"Something went wrong with accessing the file: {e.Message}\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }

                    userPlaylist.SetSaveNeeded(false);
                }
            }
            else
            {
                filePath = @"..\\..\\..\\PlaylistData\\Songs.Txt";
                try
                {
                    using (StreamWriter writeBook = new StreamWriter(filePath))
                    {
                        Playlist savedPlaylist = userPlaylist;

                        writeBook.WriteLine(savedPlaylist.GetPlaylistName() + "|" + savedPlaylist.GetCreatorName() + "|" + savedPlaylist.GetCreationDate());

                        for (int i = 0; i < userPlaylist.GetNumMP3(); i++)
                        {
                            MP3 savedMP3 = userPlaylist.GetMP3(i);

                            writeBook.WriteLine(savedMP3.GetSongTitle() + "|" + savedMP3.GetArtist() + "|" + savedMP3.GetSongReleaseDate() + "|" + savedMP3.GetPlaybackInMins() + "|" + savedMP3.GetGenre() + "|" + savedMP3.GetDownloadCost() + "|" + savedMP3.GetFileSizeInMB() + "|" + savedMP3.GetAlbumPhotoPath());
                        }
                    }
                    string savePlaylist = "Playlist Has Been Saved!";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (savePlaylist.Length / 2)) + "}", savePlaylist));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                }
                catch (Exception e)
                {
                    string invalid = "Playlist Was Not Saved";
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine($"Something went wrong with accessing the file: {e.Message}\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }

                userPlaylist.SetSaveNeeded(false);
            }
        }

        private static void EndSave()
        {
            if (userPlaylist.GetSaveNeeded() == true)
            {
                string endSave = "You have unsaved changes! Would you like to save?";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (endSave.Length / 2)) + "}", endSave));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

                string saveChoice = "";
                bool endSaveSuccess = false;
                while (!endSaveSuccess)
                {
                    Console.Write("Y/N: ");
                    saveChoice = Console.ReadLine().ToUpper();

                    if (saveChoice == "Y" || saveChoice == "N")
                    {
                        Console.WriteLine();
                        endSaveSuccess = true;
                    }
                    else
                    {
                        string invalid = "Invalid Input";
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"Invalid input, you can only enter a Y (yes) or N (no). Please try again.\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
                if (saveChoice == "Y")
                {
                    SavePlaylist();
                }

                Console.WriteLine();
            }
        }
    }
}