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
    public class MP3
    {
        private string songTitle;
        private string artist;
        private string songReleaseDate;
        private double playbackInMins;
        private Genre genre;
        private decimal downloadCost;
        private double fileSizeInMB;
        private string albumPhotoPath;

        public MP3()
        {
            SetSongTitle("Unknown Song");
            SetArtist("Unknown Artist");
            SetSongReleaseDate("Unknown Song Release Date");
            SetPlaybackInMins(0);
            SetGenre(Genre.OTHER);
            SetDownloadCost(0);
            SetFileSizeInMB(0);
            SetAlbumPhotoPath("Unknown File Type");
        }

        public MP3(string songTitle, string artist, string songReleaseDate, double playbackInMins, Genre genre, decimal downloadCost, double fileSizeInMB, string albumPhotoPath)
        {
            SetSongTitle(songTitle);
            SetArtist(artist);
            SetSongReleaseDate(songReleaseDate);
            SetPlaybackInMins(playbackInMins);
            SetGenre(genre);
            SetDownloadCost(downloadCost);
            SetFileSizeInMB(fileSizeInMB);
            SetAlbumPhotoPath(albumPhotoPath);
        }

        public MP3(MP3 existing)
        {
            SetSongTitle(existing.GetSongTitle());
            SetArtist(existing.GetArtist());
            SetSongReleaseDate(existing.GetSongReleaseDate());
            SetPlaybackInMins(existing.GetPlaybackInMins());
            SetGenre(existing.GetGenre());
            SetDownloadCost(existing.GetDownloadCost());
            SetFileSizeInMB(existing.GetFileSizeInMB());
            SetAlbumPhotoPath(existing.GetAlbumPhotoPath());
        }

        public string GetSongTitle()
        {
            return songTitle;
        }

        public string GetArtist()
        {
            return artist;
        }

        public string GetSongReleaseDate()
        {
            return songReleaseDate;
        }

        public double GetPlaybackInMins()
        {
            return playbackInMins;
        }

        public Genre GetGenre()
        {
            return genre;
        }

        public decimal GetDownloadCost()
        {
            return downloadCost;
        }

        public double GetFileSizeInMB()
        {
            return fileSizeInMB;
        }

        public string GetAlbumPhotoPath()
        {
            return albumPhotoPath;
        }

        public void SetSongTitle(string songTitle)
        {
            this.songTitle = songTitle;
        }

        public void SetArtist(string artist)
        {
            this.artist = artist;
        }

        public void SetSongReleaseDate(string songReleaseDate)
        {
            this.songReleaseDate = songReleaseDate;
        }

        public void SetPlaybackInMins(double playbackInMins)
        {
            this.playbackInMins = Math.Round(playbackInMins, 2);
        }

        public void SetGenre(Genre genre)
        {
            this.genre = genre;
        }

        public void SetDownloadCost(decimal downloadCost)
        {
            this.downloadCost = Math.Round(downloadCost, 2);
        }

        public void SetFileSizeInMB(double fileSizeInMB)
        {
            this.fileSizeInMB = Math.Round(fileSizeInMB, 2);
        }

        public void SetAlbumPhotoPath(string albumPhotoPath)
        {
            this.albumPhotoPath = albumPhotoPath;
        }

        public override string ToString()
        {
            string info = "";

            info += "------------------------------------------------------------------------------------------------------------------------";
            info += $"\nMP3 Title: {GetSongTitle()}\n";
            info += $"\nArtist: {GetArtist()}\n";
            info += $"\nRelease Date: {GetSongReleaseDate()}\n";
            info += $"\nSong Playtime: {GetPlaybackInMins()} minutes\n";
            info += $"\nGenre: {GetGenre()}\n";
            info += $"\nDownload Cost: ${GetDownloadCost()}\n";
            info += $"\nFile Size: {GetFileSizeInMB()} MBs\n";
            info += $"\nAlbum Photo: {GetAlbumPhotoPath()}.jpg\n";
            info += "\n------------------------------------------------------------------------------------------------------------------------\n";

            return info;
        }
    }
}
