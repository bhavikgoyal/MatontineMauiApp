using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.native
{
  public interface INativeCustom
  {
    void UssdCall(string ussdCode, Action<string> action);
    void download(string url);
  }
}
