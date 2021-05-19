using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Cuisine
  {
    public Cuisine()
    {
      this.Establishments = new HashSet<Establishment>();
    }
    public int CuisineId { get; set; }
    public string CuisineName { get; set; }
    public virtual ICollection<Establishment> Establishments { get; set; }
  }
}