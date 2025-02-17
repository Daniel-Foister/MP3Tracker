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
    public class Playlist
    {
        private List<MP3> playlist;
        private string playlistName;
        private string creatorName;
        private string creationDate;
        private bool SaveNeeded;

        public Playlist()
        {
            SetPlaylistName("Unknown Playlist Name");
            SetCreatorName("Unknown Creator Name");
            SetCreationDate("Unknown Creation Date");
            playlist = new List<MP3>();
            SetSaveNeeded(false);
        }

        public Playlist(string playlistName, string creatorName, string creationDate)
        {
            SetPlaylistName(playlistName);
            SetCreatorName(creatorName);
            SetCreationDate(creationDate);
            playlist = new List<MP3>();
            SetSaveNeeded(false);
        }

        public void AddMP3(MP3 userMP3)
        {
            playlist.Add(userMP3);
            SetSaveNeeded(true);
        }

        public void EditMP3(int indexInsert, MP3 editMP3)
        {
            playlist.Insert(indexInsert, editMP3);
            SetSaveNeeded(true);
        }

        public void RemoveMP3(int indexRemoval)
        {
            playlist.RemoveAt(indexRemoval);
            SetSaveNeeded(true);
        }

        public void DisplayAllMP3()
        {
            for (int i = 0; i < playlist.Count; i++)
            {
                Console.WriteLine($"[{i}]\n" + $"{playlist[i]}");
            }
        }

        public void SongTitleDisplay(string titleToFind)
        {
            int index = 0;
            int foundPos = -1;

            bool found = false;

            while (index < playlist.Count && !found)
            {
                if (playlist[index].GetSongTitle() == titleToFind)
                {
                    found = true;
                    foundPos = index;
                }

                index++;
            }

            Console.WriteLine($"{playlist[foundPos]}");
        }

        public void DisplayAllMP3Genre(Genre genreToFind)
        {
            int index = 0;
            int foundPos = -1;

            while (index < playlist.Count)
            {
                if (playlist[index].GetGenre() == genreToFind)
                {
                    foundPos = index;
                    Console.WriteLine($"{playlist[foundPos]}");
                }

                index++;
            }

            if (foundPos == -1)
            {
                string invalid = "Invalid Input";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("Sorry, your input must be an existing Genre of an MP3 File. Please try again.\n");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void DisplayAllMP3Artist(string artistToFind)
        {
            int index = 0;
            int foundPos = -1;

            while (index < playlist.Count)
            {
                if (playlist[index].GetArtist() == artistToFind)
                {
                    foundPos = index;
                    Console.WriteLine($"{playlist[foundPos]}");
                }

                index++;
            }

            if (foundPos == -1)
            {
                string invalid = "Invalid Input";
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (invalid.Length / 2)) + "}", invalid));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("Sorry, your input must be an existing Artist Name of an MP3 File. Please try again.\n");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SongSortTitle()
        {
            for (int i = playlist.Count; i > 1; i--)
            {
                int posOfLargest = 0;

                for (int j = 1; j < i; j++)
                {
                    if (playlist[j].GetSongTitle().CompareTo(playlist[posOfLargest].GetSongTitle()) > 0)
                    {
                        posOfLargest = j;
                    }
                }

                if (posOfLargest != i - 1)
                {
                    MP3 temp = playlist[posOfLargest];
                    playlist[posOfLargest] = playlist[i - 1];
                    playlist[i - 1] = temp;
                }
            }
            SetSaveNeeded(true);

        }

        public int SortingDate(int size)
        {
            int i = 0;
            int max = 0;

            for (i = 1; i < size; i++)
            {
                string[] stringInitial = playlist[i].GetSongReleaseDate().Split("/");
                string[] stringMax = playlist[max].GetSongReleaseDate().Split("/");

                int yearInitial = int.Parse(stringInitial[2]);
                int yearMax = int.Parse(stringMax[2]);
                int dayInitial = int.Parse(stringInitial[1]);
                int dayMax = int.Parse(stringMax[1]);
                int monthInitial = int.Parse(stringInitial[0]);
                int monthMax = int.Parse(stringMax[0]);

                if (yearInitial > yearMax)
                {
                    max = i;
                }
                else if (yearInitial == yearMax)
                {
                    if (monthInitial > monthMax)
                    {
                        max = i;
                    }
                    else if (yearInitial == yearMax && monthInitial == monthMax)
                    {
                        if (dayInitial > dayMax)
                        {
                            max = i;
                        }
                    }
                }
            }
            SetSaveNeeded(true);

            return max;
        }

        public void SortSongReleaseDate()
        {
            for (int i = playlist.Count; i > 1; i--)
            {
                int largestPosition = SortingDate(i);

                if (largestPosition != i - 1)
                {
                    MP3 tempList = playlist[largestPosition];
                    playlist[largestPosition] = playlist[i - 1];
                    playlist[i - 1] = tempList;
                }
            }
            SetSaveNeeded(true);
        }

        public int GetNumMP3()
        {
            return playlist.Count;
        }

        public MP3 GetMP3(int n)
        {
            if (n >= 0 && n < GetNumMP3())
                return playlist[n];
            else
                throw new Exception($"There is no MP3 in the playlist.");
        }

        public string GetPlaylistName()
        {
            return playlistName;
        }

        public string GetCreatorName()
        {
            return creatorName;
        }

        public string GetCreationDate()
        {
            return creationDate;
        }

        public bool GetSaveNeeded()
        {
            return SaveNeeded;
        }

        public void SetPlaylistName(string playlistName)
        {
            this.playlistName = playlistName;
        }

        public void SetCreatorName(string creatorName)
        {
            this.creatorName = creatorName;
        }

        public void SetCreationDate(string creationDate)
        {
            this.creationDate = creationDate;
        }

        public void SetSaveNeeded(bool SaveNeeded)
        {
            this.SaveNeeded = SaveNeeded;
        }

        public override string ToString()
        {
            string playlistInfo = "";
            playlistInfo += $"\nPlaylist Name: {GetPlaylistName()}\n";
            playlistInfo += $"\nCreator Name: {GetCreatorName()}\n";
            playlistInfo += $"\nCreation Date: {GetCreationDate()}\n";
            playlistInfo += "\n------------------------------------------------------------------------------------------------------------------------\n";


            return playlistInfo;
        }
    }
}
