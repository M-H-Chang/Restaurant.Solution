using System.Collections.Generic;

namespace Restaurant.Models
{

  public class Establishment
  {
    public int EstablishmentId { get; set; }
    public string EstablishmentName { get; set; }

    public int CuisineId { get; set; }
    public string Hours { get; set; }
    public string Rating { get; set; }
    public string Location { get; set; }
    public virtual Cuisine Cuisine { get; set; }

  }
}
