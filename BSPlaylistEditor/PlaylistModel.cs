/*
 * Class to define the properties of a PlaylistModel object
 */

using Newtonsoft.Json.Linq;
using System;

namespace BSPlaylistEditor
{
    public class PlaylistModel
    {
        public string devicePath { get; set; } //Path to the playlist on the headset
        public string tempPath { get; set; } //Path to local stored playlist copy
        public string playlistTitle { get; set; } //Name of the playlist
        public JArray songs { get; set; } //List of hash & songName values of songs in the playlist
        public string imageString { get; set; } //Base64 representation of the playlist cover image
        public DateTime backupDate { get; set; } //Date a backup was made, parsed from the file name
    }
}
