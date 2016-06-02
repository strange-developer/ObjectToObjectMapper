using System.Collections;
using System.Collections.Generic;

namespace ObjectToObjectMapper_Example.Database
{
  public class Artist
  {
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public ICollection<Album> Albums { get; set; }
    public Producer Producer { get; set; }
  }
}
