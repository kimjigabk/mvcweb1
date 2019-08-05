using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    interface IMusicRepository
    {
        IEnumerable<Music> GetMusics();

        Music GetMusicById(int id);
        void InsertMusic(Music music);
        bool DeleteMusic(int id);

        bool UpdateMusic(int id, MusicDto musicDto);

        void Save();


    }
}