using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers.api
{
    public class MusicsController : ApiController
    {
        private ApplicationDbContext _context;

        public MusicsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/musics
        public IHttpActionResult GetMusics()
        {
            var musicDtos = _context.Musics.ToList().Select(Mapper.Map<Music, MusicDto>);

            return Ok(musicDtos);
        }

        //Get /api/musics/1
        public IHttpActionResult GetMusic(int id)
        {
            var music = _context.Musics.SingleOrDefault(m => m.Id == id);
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
            _context.Musics.Add(music);
            _context.SaveChanges();

            musicDto.Id = music.Id;
            return Created(new Uri(Request.RequestUri + "/" + music.Id), musicDto);
        }

        // PUT /api/customers/musics/1
        [HttpPut]
        public IHttpActionResult UpdateMusic(int id, MusicDto musicDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var musicInDb = _context.Musics.SingleOrDefault(c => c.Id == id);

            if (musicInDb == null)
                return NotFound();

            Mapper.Map(musicDto, musicInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteMusic(int id)
        {
            var musicInDb = _context.Musics.SingleOrDefault(c => c.Id == id);

            if (musicInDb == null)
                return NotFound();

            _context.Musics.Remove(musicInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
