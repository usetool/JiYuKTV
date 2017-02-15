using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    /// <summary>
    /// 歌曲类
    /// </summary>
    public class Song
    {
        private string songName;
        private string songUrl;
        private string singerName;
        private SongPlayState playState = SongPlayState.unplayed;
        /// <summary>
        /// 歌曲名称
        /// </summary>
        public string SongName
        {
            get
            {
                return songName;
            }

            set
            {
                songName = value;
            }
        }
        /// <summary>
        /// 歌曲存放的路径
        /// </summary>
        public string SongUrl
        {
            get
            {
                return songUrl;
            }

            set
            {
                songUrl = value;
            }
        }
        /// <summary>
        /// 歌曲播放状态
        /// </summary>
        public SongPlayState PlayState
        {
            get
            {
                return playState;
            }

            set
            {
                playState = value;
            }
        }
        /// <summary>
        /// 歌手名字
        /// </summary>
        public string SingerName
        {
            get
            {
                return singerName;
            }

            set
            {
                singerName = value;
            }
        }
    }
    /// <summary>
    /// 歌曲播放状态
    /// </summary>
    public enum SongPlayState
    {
        /// <summary>
        /// 未播放
        /// </summary>
        unplayed,
        /// <summary>
        /// 已经播放
        /// </summary>
        played,
        /// <summary>
        /// 重唱
        /// </summary>
        again,
        /// <summary>
        /// 切歌
        /// </summary>
        cut
    }

}
