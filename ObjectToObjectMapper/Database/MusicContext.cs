using ObjectToObjectMapper.Database;
using System;
using System.Collections.Generic;

namespace ObjectToObjectMapper_Example.Database
{
  //simulate an EF DB context
  internal class MusicContext : IDisposable
  {
    //set up properties to work with
    public IEnumerable<Album> Albums { get; set; }
    public IEnumerable<Artist> Artists { get; set; }
    public IEnumerable<Producer> Producers { get; set; }
    public IEnumerable<Song> Songs { get; set; }

    //set up test data
    public MusicContext()
    {
      Albums = new Album[]
        {
          new Album() { AlbumID = 1, Description = "Album 1", Name = "First Album" },
          new Album() { AlbumID = 2, Description = "Album 2", Name = "Second Album" },
          new Album() { AlbumID = 3, Description = "Album 3", Name = "Third Album" }
        };

      
      Artists = new Artist[]
      {
        new Artist() { Age = 21,
                       FirstName = "Hansie",
                       Surname = "Cronje",
                       Albums = new Album[] 
                       {
                          new Album() { AlbumID = 1, Description = "Album 1", Name = "First Album" },
                          new Album() { AlbumID = 2, Description = "Album 2", Name = "Second Album" }
                       },
                       Producer = new Producer() { FirstName = "Producer 1", Surname = "Producer 1 Surname", Age = 66, ProducerCode = "Producer Code 1" }
        },
                new Artist() { Age = 33,
                       FirstName = "Ruby",
                       Surname = "Jewellery",
                       Albums = new Album[]
                       {
                          new Album() { AlbumID = 1, Description = "Jewel 1", Name = "First Jewel" },
                          new Album() { AlbumID = 2, Description = "Jewel 2", Name = "Second Jewel" }
                       },
                       Producer = new Producer() { FirstName = "Producer 1", Surname = "Producer 1 Surname", Age = 66, ProducerCode = "Producer Code 1" }
        }
      };

      Producers = new Producer[]
        {
          new Producer() { FirstName = "Producer 1", Surname = "Producer 1 Surname", Age = 66, ProducerCode = "Producer Code 1" },
          new Producer() { FirstName = "Producer 2", Surname = "Producer 2 Surname", Age = 33, ProducerCode = "Producer Code 2" }
        };

      Songs = new Song[]
        {
          new Song() { ArtistName = "Best Artist", Genre = "Best Genre", Title = "Best Song" },
          new Song() { ArtistName = "Second Best Artist", Genre = "Second Best Genre", Title = "Second Best Song" }
        };
    }

    //implement dispose to act as ef context
    public void Dispose()
    {

    }
  }
}