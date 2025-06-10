using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class ParameterEntity
  {
    [PrimaryKey]
    public int ID { get; set; }

    public bool rememberMe { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public bool useFingerPrint { get; set; }
  }
}
