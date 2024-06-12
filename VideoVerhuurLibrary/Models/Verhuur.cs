using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurLibrary.Models;
public class Verhuur
{
    public int VerhuurId { get; set; }
    public int KlantId { get; set; }
    public int FilmId { get; set; }
    public DateOnly VerhuurDatum { get; set; }
    public Film Film { get; set; }
    public Klant Klant { get; set; }
}
