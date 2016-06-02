using ObjectToObjectMapper_Example.Database;
using System.Collections.Generic;

namespace ObjectToObjectMapper_Example
{
  public class ArtistDTO
  {
    public string FirstName { get; set; }
    public string AlternateFirstName { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public IEnumerable<AlbumDTO> Albums { get; set; }
    public ProducerDTO Producer { get; set; }
  }
}
