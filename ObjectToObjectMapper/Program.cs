using ObjectToObjectMapper.DTOs;
using ObjectToObjectMapper.Mappings;
using ObjectToObjectMapper_Example;
using ObjectToObjectMapper_Example.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToObjectMapper
{
  class Program
  {

        
        

    static void Main(string[] args)
    {
      using (MusicContext db = new MusicContext())
      {
        DirectMap_Example(db);
        DirectMapWithError_Example(db);
        DirectMapIgnoreNonExistent_Example(db);
        DirectMapWithOmit_Example(db);
        DirectMapWithOmitIgnoreNonExistent_Example(db);
        DirectMapWithOmitWithError_Example(db);
        DirectMapWithOmitIgnoreNonExistent_ExampleNoDefault(db);
        Hybrid(db);
      }

      Console.ReadLine();
    }

    private static void DirectMap_Example(MusicContext db)
    {
      IEnumerable<SongDTO> songs = db.Songs.Select(SongMapping.SongToSongDTO);
      Console.WriteLine("Songs");
      foreach (SongDTO song in songs)
      {
        Console.WriteLine("Artist Name: {0} Genre: {1} Title: {2}", song.ArtistName, song.Genre, song.Title);
      }
      Console.WriteLine();
    }

    private static void Hybrid(MusicContext db)
    {
      IEnumerable<ArtistDTO> artists = db.Artists.Select(ArtistMappings.ArtistToArtistDTO);
      Console.WriteLine("Artists");
      foreach (ArtistDTO artist in artists)
      {
        Console.WriteLine("First Name: {0} Surname: {1} Age: {2} Producer: {3} Album Count: {4}", 
                          artist.FirstName, artist.Surname, artist.Age, artist.Producer.FirstName, artist.Albums.Count());
      }
      Console.WriteLine();
    }

    private static void DirectMapWithError_Example(MusicContext db)
    {
      try
      {
        IEnumerable<AlbumDTO> albums = db.Albums.Select(AlbumMappings.AlbumToAlbumDTOWithError_DirectMap);
        Console.WriteLine("Albums");
        foreach (AlbumDTO album in albums)
        {
          Console.WriteLine("AlbumID: {0} AlbumName: {1} AlbumDescription: {2}", album.AlbumID, album.Name, album.Description);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();
    }

    private static void DirectMapIgnoreNonExistent_Example(MusicContext db)
    {
      IEnumerable<AlbumDTO> albums = db.Albums.Select(AlbumMappings.AlbumToAlbumDTO_DirectMapIgnoreNonExistent);
      Console.WriteLine("Albums");
      foreach (AlbumDTO album in albums)
      {
        Console.WriteLine("AlbumID: {0} AlbumName: {1} AlbumDescription: {2}", album.AlbumID, album.Name, album.Description);
      }
      Console.WriteLine();
    }

    private static void DirectMapWithOmit_Example(MusicContext db)
    {
      IEnumerable<AlbumDTO> albums = db.Albums.Select(AlbumMappings.AlbumToAlbumDTOWithOmit_DirectMapWithOmit);
      Console.WriteLine("Albums");
      foreach (AlbumDTO album in albums)
      {
        Console.WriteLine("AlbumID: {0} AlbumName: {1} AlbumDescription: {2}", album.AlbumID, album.Name, album.Description);
      }
      Console.WriteLine();
    }

    private static void DirectMapWithOmitWithError_Example(MusicContext db)
    {
      try
      {
        IEnumerable<AlbumDTO> albums = db.Albums.Select(AlbumMappings.AlbumToAlbumDTOWithOmitWithError_DirectMapWithOmit);
        Console.WriteLine("Albums");
        foreach (AlbumDTO album in albums)
        {
          Console.WriteLine("AlbumID: {0} AlbumName: {1} AlbumDescription: {2}", album.AlbumID, album.Name, album.Description);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine();
    }

    private static void DirectMapWithOmitIgnoreNonExistent_Example(MusicContext db)
    {
      IEnumerable<ProducerDTO> producers = db.Producers.Select(ProducerMappings.ProducerToProducerDTO_WithDefault);
      Console.WriteLine("Producers");
      foreach (ProducerDTO producer in producers)
      {
        Console.WriteLine("First Name: {0} Surname: {1} Age: {2} Code: {3}", producer.FirstName, producer.Surname, producer.Age, producer.ProducerCode);
      }
      Console.WriteLine();
    }

    private static void DirectMapWithOmitIgnoreNonExistent_ExampleNoDefault(MusicContext db)
    {
      IEnumerable<ProducerDTO> producers = db.Producers.Select(ProducerMappings.ProducerToProducerDTO_NoDefault);
      Console.WriteLine("Producers");
      foreach (ProducerDTO producer in producers)
      {
        Console.WriteLine("First Name: {0} Surname: {1} Age: {2} Code: {3}", producer.FirstName, producer.Surname, producer.Age, producer.ProducerCode);
      }
      Console.WriteLine();
    }
  }
}
