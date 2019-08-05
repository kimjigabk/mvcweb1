using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers.api
{
    public class MusicsController : ApiController
    {
        private ApplicationDbContext _context;
        IMusicRepository _musicRepository;

        public MusicsController()
        {
            
            _context = new ApplicationDbContext();
        }

        //GET /api/musics
        public IHttpActionResult GetMusics()
        {
            IEnumerable<Music> musics = _musicRepository.GetMusics();
            var musicDtos = musics.Select(Mapper.Map<Music, MusicDto>);

            return Ok(musicDtos);
        }

        //Get /api/musics/1
        public IHttpActionResult GetMusic(int id)
        {
            var music = _musicRepository.GetMusicById(id);
            if (music == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Music, MusicDto>(music));
        }

        //POST /api/musics
        [HttpPost]
        public IHttpActionResult CreateMusic(MusicDto musicDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var music = Mapper.Map<MusicDto, Music>(musicDto);
            _musicRepository.InsertMusic(music);
   
            musicDto.Id = music.Id;
            return Created(new Uri(Request.RequestUri + "/" + music.Id), musicDto);
        }

        // PUT /api/customers/musics/1
        [HttpPut]
        public IHttpActionResult UpdateMusic(int id, MusicDto musicDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool flag = _musicRepository.UpdateMusic(id, musicDto);
            if (!flag)
                return NotFound();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteMusic(int id)
        {
            var musicInDb = _context.Musics.SingleOrDefault(c => c.Id == id);
            bool flag = _musicRepository.DeleteMusic(id);
            if (!flag)
                return NotFound();

            return Ok();
        }


    }
}
