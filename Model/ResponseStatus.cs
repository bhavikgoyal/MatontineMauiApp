using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class ResponseStatus
  {
    public bool status { get; set; }
    public bool error { get; set; }
    public string message { get; set; }
    public string smscode { get; set; }
  }
}
