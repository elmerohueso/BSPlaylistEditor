/*
 * Class to define the properties of a SongModel object
 */

namespace BSPlaylistEditor
{
    public class SongModel
    {
        public string songID { get; set; } = ""; //SHA1 for the song
        public string songName { get; set; } = ""; //Song title
        public string songSubName { get; set; } = ""; //Song subtitle
        public string songAuthorName { get; set; } = ""; //Song artist
        public string levelAuthorName { get; set; } = ""; //Song mapper
        public string folderName { get; set; } = ""; //Folder containing the song's files
    }
}
