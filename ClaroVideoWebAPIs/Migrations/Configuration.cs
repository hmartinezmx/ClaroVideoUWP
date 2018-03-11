namespace ClaroVideoWebAPIs.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClaroVideoWebAPIs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ClaroVideoWebAPIs.Models.ClaroVideoWebAPIsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClaroVideoWebAPIs.Models.ClaroVideoWebAPIsContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id,
            new Category() { Id = 1, Name = "Comedia" },
            new Category() { Id = 2, Name = "Acción" },
            new Category() { Id = 3, Name = "Ciencia Ficción" },
            new Category() { Id = 4, Name = "Horror" }
            );

            context.RatingCodes.AddOrUpdate(x => x.Id,
            new RatingCode() { Id = 1, Name = "PG-13" },
            new RatingCode() { Id = 2, Name = "R" }
            );

            context.VCards.AddOrUpdate(x => x.Id,
            new VCard() {
                Id = 1,
                Title = "Buffy, la caza vampiros",
                TitleOriginal = "Buffy, the Vampire Slayer",
                Description = "Buffy es una adolescente normal, o eso cree ella, hasta que descubre que es una caza vampiros.",
                DescriptionLarge = "Buffy Summers es sólo una adolescente, o eso cree ella. Es una animadora. Tiene una vida agradable y normal en la cima de la popularidad de su escuela hasta que se entera de que ella es la reencarnación de una guerrera pura: una Vampira Cazadora.",
                URLImageH = @"https://clarovideocdn1.clarovideo.net/PELICULAS/BUFFYTHEVAMPIRESLAYER/EXPORTACION_WEB/SS/BUFFYTHEVAMPIRESLAYERWHORIZONTAL.jpg",
                URLImageV = @"https://clarovideocdn9.clarovideo.net/PELICULAS/BUFFYTHEVAMPIRESLAYER/EXPORTACION_WEB/SS/BUFFYTHEVAMPIRESLAYERWVERTICAL.jpg",
                Year = 1992,
                Actors = "Perry, Luke|Jenson, Sasha|Batinkoff, Randall",
                Directors = "Kuzui, Fran",
                Duration = "01:25:32",
                RatingCodeId = 1,
                CategoryId = 1,
                VotesAverage = 4
            },
            new VCard() {
                Id = 2,
                Title = "Gigantes de acero",
                TitleOriginal = "Real Steel",
                Description = "Anímate a experimentar la lucha de robots, un deporte del futuro donde sólo el mejor vencerá.",
                DescriptionLarge = "Experimenta la adrenalina y el frenesí de una actividad como la lucha de robots. Esta es la historia de un excampeón de boxeo que, empujado por el fuerte deseo de un niño, regresa al mundo de la pelea de la mano de un misterioso androide.",
                URLImageH = @"https://clarovideocdn7.clarovideo.net/PELICULAS/REALSTEEL/EXPORTACION_WEB/SS/REALSTEELWHORIZONTAL.jpg",
                URLImageV = @"https://clarovideocdn5.clarovideo.net/PELICULAS/REALSTEEL/EXPORTACION_WEB/SS/REALSTEELWVERTICAL.jpg",
                Year = 2011,
                Actors = "Jackman, Hugh|Goyo, Dakota|Lilly, Evangeline",
                Directors = "Levy, Shawn",
                Duration = "02:06:47",
                RatingCodeId = 1,
                CategoryId = 2,
                VotesAverage = 4
            },
            new VCard()
            {
                Id = 3,
                Title = "Hulk: El hombre increíble",
                TitleOriginal = "Incredible Hulk, The ('08)",
                DescriptionLarge = "El científico Bruce Banner vive en las sombras con la esperanza de encontrar una cura para librarse de su incontrolable alter ego que sale cada vez que se enoja. Pero la posibilidad de un antídoto y su enamorada, lo hacen volver a la civilización.",
                Description = "Bruce Banner y su incontrolable doble personalidad verde se enfrentan al ejército.",
                URLImageH = @"https://clarovideocdn7.clarovideo.net/PELICULAS/INCREDIBLEHULKTHE08/EXPORTACION_WEB/SS/INCREDIBLEHULKTHE08WHORIZONTAL.jpg",
                URLImageV = @"https://clarovideocdn5.clarovideo.net/PELICULAS/INCREDIBLEHULKTHE08/EXPORTACION_WEB/SS/INCREDIBLEHULKTHE08WVERTICAL.jpg",
                Year = 2008,
                Actors = "Hurt, William|Norton, Edward|Owens, Chris|Bryk, Greg",
                Directors = "Leterrier|Louis",
                Duration = "01:52:08",
                RatingCodeId = 1,
                CategoryId = 2,
                VotesAverage = 4
            },
            new VCard()
            {
                Id = 4,
                Title = "Terminator - La salvación ",
                TitleOriginal = "Terminator Salvation",
                Description = "John Connor lidera la resistencia contra los Terminators. Pero Wright cambiará la historia.",
                DescriptionLarge = "Dos hombres y un destino que parece ideado para encontrarse en un post apocalíptico 2018, donde Skynet sigue produciendo robots para terminar con la humanidad. Marcus Wright se despertará luego de una amnesia de 15 años, ¿ayudará a John Connor?",
                URLImageH = @"https://clarovideocdn7.clarovideo.net/PELICULAS/TERMINATORSALVATION/EXPORTACION_WEB/SS/TERMINATORSALVATIONWHORIZONTAL.jpg",
                URLImageV = @"https://clarovideocdn5.clarovideo.net/PELICULAS/TERMINATORSALVATION/EXPORTACION_WEB/SS/TERMINATORSALVATIONWVERTICAL.jpg",
                Year = 2009,
                Actors = "Yelchin, Anton|Worthington, Sam|Bale, Christian",
                Directors = "MCG, None",
                Duration = "01:54:37",
                RatingCodeId = 1,
                CategoryId = 3,
                VotesAverage = 4
            }, 
            new VCard()
            {
                Id = 5,
                Title = "El ataque de las zombies",
                TitleOriginal = "Zombie Strippers",
                Description = "Un virus liberado cerca de un club de striptease va convirtiendo a las bailarinas en zombies.",
                DescriptionLarge = "Un virus que resulta de un experimento ultrasecreto del gobierno es liberado en un pueblo de Nebraska, muy cerca de un club de striptease. A medida que el virus se expande, va convirtiendo a las bailarinas del club en 'Super Zombie Strippers'.",
                URLImageH = @"https://clarovideocdn9.clarovideo.net/PELICULAS/ZOMBIESTRIPPERS/EXPORTACION_WEB/SS/ZOMBIESTRIPPERSWHORIZONTAL.jpg",
                URLImageV = @"https://clarovideocdn7.clarovideo.net/PELICULAS/ZOMBIESTRIPPERS/EXPORTACION_WEB/SS/ZOMBIESTRIPPERSWVERTICAL.jpg",
                Year = 2008,
                Actors = "Jameson, Jenna|Drake, Penny|Moore, Shamron|Saint, Roxy",
                Directors = "Lee, Jay",
                Duration = "01:34:16",
                RatingCodeId = 2,
                CategoryId = 2,
                VotesAverage = 3
            }
            );
            
        }
    }
}
