using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{

    //Inyector de Dependencias para generar las url de las imagenes

    //Modelo para procesar el resulta de las imagenes
    public class UrlImages
    {
        public string Vertical { get; set; }
        public string Horizontal { get; set; }
    }

    //Interfas para realizar poliformismo
    public interface IImage
    {
        /// <summary>
        /// Crea un nuevo objeto de tipo UrlImages
        /// </summary>
        /// <typeparam name="imagev">URL de la imagen vertical</typeparam>
        /// <typeparam name="imageh">URL de la imagen horizontal</typeparam>
        UrlImages GetImages(string imagev, string imageh);
    }

    //Clase base con los metrodos y atributos genericos
    public class URLsImages : IImage
    {
        //Modelo generico de la interfaz
        protected IImage images;

        /// <summary>
        /// Contructor para establece la intancia de las dependencias en la clase generica
        /// </summary>
        /// <typeparam name="_images">Instancia del la dependencia</typeparam>
        public URLsImages(IImage _images)
        {
            this.images = _images;
        }

        //Implementacion del metodo de la interface
        public UrlImages GetImages(string imagev, string imageh)
        {
            //Ejecuta el metodo de la dependencia y retorna el resultado
            return this.images.GetImages(imagev, imageh);
        }
    }

    //Clase para contruir las urls de las imagenes de los VCards
    public class GeneralImages : IImage
    {
        public UrlImages GetImages(string imagev, string imageh)
        {
            return new UrlImages()
            {
                Horizontal = imageh + "?size=290x163",
                Vertical = imagev + "?size=200x300"
            };
        }
    }

    //Clase para contruir las urls de las imagenes del detalle de la VCard
    public class DetailImages : IImage
    {
        public UrlImages GetImages(string imagev, string imageh)
        {
            return new UrlImages()
            {
                Horizontal = imageh + "?size=675x380",
                Vertical = imagev + "?size=200x300"
            };
        }
    }
}