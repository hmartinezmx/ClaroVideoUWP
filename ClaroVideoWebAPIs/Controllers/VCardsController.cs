﻿using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ClaroVideoWebAPIs.Models;

namespace ClaroVideoWebAPIs.Controllers
{
    //Establece el permiso de acceso de la aplicacional al webapi
    [EnableCors(origins: "ms-appx-web:///index.html", headers: "*", methods: "*")]
    public class VCardsController : ApiController
    {
        private ClaroVideoWebAPIsContext db = new ClaroVideoWebAPIsContext();

        // GET: api/VCards
        public IQueryable<VCardDTO> GetVCards()
        {
            //Instincia de iyector con la dependencia para imagenes generales
            var images = new URLsImages(new GeneralImages());

            //Obtiene todos los elementos de la tabla VCards, cada item genera una copia de datos a un nuevo modelo de tipo VCardDTO
            var vcard = (from b in db.VCards
                        select new VCardDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            UrlImages = new UrlImages() { Horizontal = b.URLImageH, Vertical = b.URLImageV } 
                        }).ToList();

            //Itera los elementos para obtener las url de las imagenes generales
            foreach (VCardDTO item in vcard)
            {
                item.UrlImages = images.GetImages(item.UrlImages.Vertical, item.UrlImages.Horizontal);
            }

            return vcard.AsQueryable();
        }

        // GET: api/StringSearch
        public IQueryable<VCardDTO> GetVCards(string text)
        {
            //Instincia de iyector con la dependencia para imagenes generales
            var images = new URLsImages(new GeneralImages());

            //Obtiene todos los elementos de la tabla VCards que contengan en el titulo el string de busqueda, cada item genera una copia de datos a un nuevo modelo de tipo VCardDTO
            var vcard = (from b in db.VCards
                        where b.Title.Contains(text)
                        select new VCardDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            UrlImages = new UrlImages() { Horizontal = b.URLImageH, Vertical = b.URLImageV }
                        }).ToList();

            //Itera los elementos para obtener las url de las imagenes generales
            foreach (VCardDTO item in vcard)
            {
                item.UrlImages = images.GetImages(item.UrlImages.Vertical, item.UrlImages.Horizontal);
            }

            return vcard.AsQueryable();
        }

        // GET: api/VCards/5
        [ResponseType(typeof(VCardDetailDTO))]
        public async Task<IHttpActionResult> GetVCard(int id)
        {
            //Instincia de iyector con la dependencia para imagenes del detalle
            var images = new URLsImages(new DetailImages());

            //Obtiene el elementos de la tabla VCards con el id de busqueda, se genera un copia de datos al modelo VCardDetailDTO
            //Se incluyen la relacion con las tablas Category y RatingCode
            var vCard = await db.VCards.Include(b => b.Category).Include(b => b.RatingCode).Select(b =>
                new VCardDetailDTO()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    DescriptionLarge = b.DescriptionLarge,
                    Duration = b.Duration,
                    TitleOriginal = b.TitleOriginal,
                    VotesAverage = b.VotesAverage,
                    Year = b.Year,
                    RatingCode = b.RatingCode.Name,
                    UrlImages = new UrlImages() { Horizontal = b.URLImageH, Vertical = b.URLImageV },
                    Category = b.Category.Name,
                    Actors = b.Actors,
                    Directors = b.Directors
                }).SingleOrDefaultAsync(b => b.Id == id);

            //Obtiene las urls de la imagenes para detalle
            vCard.UrlImages = images.GetImages(vCard.UrlImages.Vertical, vCard.UrlImages.Horizontal);

            //Formatea la propiedad Duration {0}:{1}:{2} to {0}h {1} min {2}s
            var duration = vCard.Duration.Split(':');
            vCard.Duration = String.Format("{0}h {1} min {2}s", duration[0], duration[1], duration[2]);

            if (vCard == null)
            {
                return NotFound();
            }

            return Ok(vCard);
        }

        // PUT: api/VCards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVCard(int id, VCard vCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vCard.Id)
            {
                return BadRequest();
            }

            db.Entry(vCard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VCards
        [ResponseType(typeof(VCard))]
        public async Task<IHttpActionResult> PostVCard(VCard vCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VCards.Add(vCard);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vCard.Id }, vCard);
        }

        // DELETE: api/VCards/5
        [ResponseType(typeof(VCard))]
        public async Task<IHttpActionResult> DeleteVCard(int id)
        {
            VCard vCard = await db.VCards.FindAsync(id);
            if (vCard == null)
            {
                return NotFound();
            }

            db.VCards.Remove(vCard);
            await db.SaveChangesAsync();

            return Ok(vCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VCardExists(int id)
        {
            return db.VCards.Count(e => e.Id == id) > 0;
        }
    }
}