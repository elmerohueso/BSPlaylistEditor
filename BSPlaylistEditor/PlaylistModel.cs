/*
 * Class to define the properties of a PlaylistModel object
 */

using Newtonsoft.Json.Linq;

namespace BSPlaylistEditor
{
    public class PlaylistModel
    {
        public string fileName { get; set; } //Name of the playlist JSON file
        public string playlistTitle { get; set; } //Name of the playlist
        public JArray songs { get; set; } //List of hash & songName values of songs in the playlist
        public string imageString { get; set; } //Base64 representation of the playlist cover image
    }
}
