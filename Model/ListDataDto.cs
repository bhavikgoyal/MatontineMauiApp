using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class ListDataDto
  {
    public List<SimpleListItemData> lstyesno { get; set; }
    public List<SimpleListItemData> lstyes { get; set; }

    public List<SimpleListItemData> lsttypepieceidentification { get; set; }
    public List<SimpleListItemData> lstcategorie { get; set; }
    public List<SimpleListItemData> lstpays_old { get; set; }
    public List<SimpleListItemData> lstgenre { get; set; }
    public List<SimpleListItemData> lstniveauetude { get; set; }
    public List<SimpleListItemData> lstsituationmatrimoniale { get; set; }
    public List<SimpleListItemData> lsthabitat { get; set; }
    public List<SimpleListItemData> lstsourcerevenue { get; set; }
    public List<SimpleListItemData> lstprofession { get; set; }
    public List<SimpleListItemData> lstusagepret { get; set; }


    public List<SimpleListItemData> lstlienparente { get; set; }
    public List<SimpleListItemData> lsttypeperiodicite { get; set; }


    public List<SimpleListItemData> lstmonnaie { get; set; }
    public List<SimpleListItemData> lstlangue { get; set; }
    public List<SimpleListItemData> lstdateformat { get; set; }
    public List<SimpleListItemData> lstsepmillier { get; set; }
    public List<SimpleListItemData> lstsepdecimal { get; set; }


    ///

    public List<CountryDto> lstpays { get; set; } = new List<CountryDto>();
    public List<SimpleListItemData> lstpartenaire { get; set; } = new List<SimpleListItemData>();
    public List<SimpleListItemData> lstmodepaiement { get; set; } = new List<SimpleListItemData>();

    public List<SimpleListItemData> lstperiodicite { get; set; } = new List<SimpleListItemData>();
    public List<SimpleListItemData> lstnombregagnantpartirage { get; set; } = new List<SimpleListItemData>();
    public List<SimpleListItemData> lstjourstirage { get; set; } = new List<SimpleListItemData>();
  }
}
