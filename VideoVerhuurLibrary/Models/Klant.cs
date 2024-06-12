using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurLibrary.Models;
public class Klant
{
    public int KlantId { get; set; }
    public string Naam { get; set; }
    public string Voornaam { get; set; }
    public string Straat_Nr { get; set; }
    public string PostCode { get; set; }
    public string Gemeente { get; set; }
    public string KlantStat { get; set; }
    public int HuurAantal { get; set; }
    public DateOnly DatumLid { get; set; }
    public decimal LidGeld { get; set; }
    public ICollection<Verhuur> Verhuringen { get; set; }
}
