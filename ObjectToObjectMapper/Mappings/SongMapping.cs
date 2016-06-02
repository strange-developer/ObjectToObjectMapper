using O2OMapper;
using ObjectToObjectMapper.Database;
using ObjectToObjectMapper.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToObjectMapper.Mappings
{
  public class SongMapping
  {
    //create function reference to be inserted into the Select method of a 
    //type implementing IEnumerable
    public static Func<Song, SongDTO> SongToSongDTO => SongToSongDTOMapping;

    //configure the mapping
    private static SongDTO SongToSongDTOMapping(Song song)
    {
      return ObjectMapper.DirectMap<Song, SongDTO>(song);
    }
  }
}
