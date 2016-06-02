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
  public class AlbumMappings
  {
    public static Func<Album, AlbumDTO> AlbumToAlbumDTO_DirectMapIgnoreNonExistent => AlbumToAlbumDTOMapping_DirectMapIgnoreNonExistent;

    private static AlbumDTO AlbumToAlbumDTOMapping_DirectMapIgnoreNonExistent(Album album)
    {
      return ObjectMapper.DirectMapIgnoreNonExistentProps<Album, AlbumDTO>(album);
    }

    public static Func<Album, AlbumDTO> AlbumToAlbumDTOWithError_DirectMap => AlbumToAlbumDTOMappingWithError_DirectMap;

    private static AlbumDTO AlbumToAlbumDTOMappingWithError_DirectMap(Album album)
    {
      return ObjectMapper.DirectMap<Album, AlbumDTO>(album);
    }

    public static Func<Album, AlbumDTO> AlbumToAlbumDTOWithOmit_DirectMapWithOmit => AlbumToAlbumDTOMappingWithOmit_DirectMapWithOmit;

    private static AlbumDTO AlbumToAlbumDTOMappingWithOmit_DirectMapWithOmit(Album album)
    {
      return ObjectMapper.DirectMapWithOmits<Album, AlbumDTO>(album, new string[] { "WontMatch", "WontMatchTwo" });
    }

    public static Func<Album, AlbumDTO> AlbumToAlbumDTOWithOmitWithError_DirectMapWithOmit => AlbumToAlbumDTOMappingWithOmitWithError_DirectMapWithOmit;

    private static AlbumDTO AlbumToAlbumDTOMappingWithOmitWithError_DirectMapWithOmit(Album album)
    {
      return ObjectMapper.DirectMapWithOmits<Album, AlbumDTO>(album, new string[] { "WontMatch" });
    }

    public static Func<Album, AlbumDTO> AlbumToAlbumDTOWithOmitIgnoreNonExistent_DirectMapWithOmitIgnoreNonExistent => AlbumToAlbumDTOMappingWithOmitAndIgnoreNonExistentProps_DirectMapWithOmitIgnoreNonExistent;

    private static AlbumDTO AlbumToAlbumDTOMappingWithOmitAndIgnoreNonExistentProps_DirectMapWithOmitIgnoreNonExistent(Album album)
    {
      return ObjectMapper.DirectMapWithOmitsIgnoreNonExistentProps<Album, AlbumDTO>(album, new string[] { "WontMatch" });
    }
  }
}
