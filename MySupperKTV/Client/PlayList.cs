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
        private List<Song> songList = new List<Song>();
        /// <summary>
        /// 当前播放的歌曲的名称
        /// </summary>
        /// <returns></returns>
        public string PlayingSongName()
        {
            return "";
        }
        /// <summary>
        /// 获取当前播放的歌曲对象
        /// </summary>
        /// <returns></returns>
        public Song GetPlayingSong()
        {
            return null;
        }
        /// <summary>
        /// 获取下一首要播放的歌曲名称
        /// </summary>
        /// <returns></returns>
        public string NextSongName()
        {
            return "";
        }
        /// <summary>
        /// 添加歌曲到列表
        /// </summary>
        /// <param name="song"></param>
        public void AddSong(Song song)
        {

        }
    }
}
