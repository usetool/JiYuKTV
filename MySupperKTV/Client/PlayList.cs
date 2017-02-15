using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    /// <summary>
    /// 播放类
    /// </summary>
    public class PlayList
    {
        /// <summary>
        /// 静态全局播放列表
        /// </summary>
        public static List<Song> songList = new List<Song>();
        /// <summary>
        /// 当前播放的歌曲的名称
        /// </summary>
        /// <returns></returns>
        public string PlayingSongName()
        {
            return songList[0].SongName;
        }
        /// <summary>
        /// 获取当前播放的歌曲对象
        /// </summary>
        /// <returns></returns>
        public Song GetPlayingSong()
        {
            return songList[0];
        }
        /// <summary>
        /// 获取下一首要播放的歌曲名称
        /// </summary>
        /// <returns></returns>
        public string NextSongName()
        {
            return songList[1].SongName;
        }
        /// <summary>
        /// 添加歌曲到列表
        /// </summary>
        /// <param name="song"></param>
        public void AddSong(Song song)
        {
            songList.Add(song);
        }
    }
}
