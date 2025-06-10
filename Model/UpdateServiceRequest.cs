using MatontineDigitalApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class UpdateServiceRequest : Credentials
  {
    public UpdateServiceRequest() { }
    public UpdateServiceRequest(ServiceDto dto)
    {
      id = toInt(dto.ServiceId);
      nom = dto.Nom;
      typeperiodicite = dto.TypePeriodicite;
      periodicite = toInt(dto.Periodicite);
      jourstirage = toInt(dto.JourDuTirage);
      nombregagnantpartirage = toInt(dto.NombreDeGagnant);
      montantparticipation = toInt(dto.Montant);
      datencours = dto._DateDemarage;
      datefin = dto._DateFin;
      maxperiodicite = toInt(dto.MaxPeriodicite);
    }

    public int id { get; set; }

    public string nom { get; set; }

    public string typeperiodicite { get; set; }
    public int periodicite { get; set; }
    public int jourstirage { get; set; }
    public int nombregagnantpartirage { get; set; }
    public int montantparticipation { get; set; }

    public string datencours { get; set; }
    public string datefin { get; set; }
    public int maxperiodicite { get; set; }
  }
}
