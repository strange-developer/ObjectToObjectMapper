using O2OMapper;
using ObjectToObjectMapper_Example;
using ObjectToObjectMapper_Example.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToObjectMapper.Mappings
{
  public class ArtistMappings
  {
    public static Func<Artist, ArtistDTO> ArtistToArtistDTO => ArtistToArtistDTOMapping;

    private static ArtistDTO ArtistToArtistDTOMapping(Artist artist)
    {
      //set up return object
      ArtistDTO artistDto = new ArtistDTO();
      //default the alternate first name to the first name
      artistDto.AlternateFirstName = artist.FirstName;
      //map the remaining objects but ignore the Albums and Producer property
      artistDto = ObjectMapper.DirectMapWithOmitsIgnoreNonExistentProps<Artist, ArtistDTO>(artist, new string[] { "Albums", "Producer" });
      //map each property in the album type for all items in the list by borrowing the mapping already created in the album class
      artistDto.Albums = artist.Albums.Select(AlbumMappings.AlbumToAlbumDTOWithOmitIgnoreNonExistent_DirectMapWithOmitIgnoreNonExistent);
      //map each property of the producer class by borrowing the mapping already created in the ProducerMapping class
      artistDto.Producer = ProducerMappings.ProducerToProducerDTO_NoDefault(artist.Producer);
      return artistDto;
    }
  }
}
