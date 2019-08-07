using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private static ApplicationDbContext _context;
        public MusicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool DeleteMusic(int id)
        {
            Music music = GetMusicById(id);
            if (music == null)
                return false;
            _context.Musics.Remove(music);
            _context.SaveChanges();

            return true;
        }

        public Music GetMusicById(int id)
        {
            
            Music music = _context.Musics.SingleOrDefault(m => m.Id == id);
            return music;
        }

        public IEnumerable<Music> GetMusics()
        {
            var musics = _context.Musics.ToList();
            return musics;
        }

        //returns id of the music
        public void InsertMusic(Music music)
        {
            _context.Musics.Add(music);
            _context.SaveChanges();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateMusic(int id, MusicDto musicDto)
        {
            var musicInDb = _context.Musics.SingleOrDefault(c => c.Id == id);
            if (musicInDb == null)
                return false;
            Mapper.Map(musicDto, musicInDb);
            _context.SaveChanges();

            return true;
        }
    }
}