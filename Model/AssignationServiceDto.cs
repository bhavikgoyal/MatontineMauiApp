using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class AssignationServiceDto : Credentials
  {
    [JsonProperty("pcodeservice")]
    public string CodeService { get; set; }

    [JsonProperty("passigner")]
    public string Assigner { get { return getBool(_Assigner); } set { _Assigner = value; } }
    private string _Assigner;

    [JsonProperty("plstmember")]
    public string ListCodeMemberJSON { get; set; }

    [JsonIgnore]
    private List<string> _ListCodeMember;
    [JsonIgnore]
    public List<string> ListCodeMember
    {
      get => _ListCodeMember;

      set
      {
        _ListCodeMember = value;
        ListCodeMemberJSON = JsonConvert.SerializeObject(_ListCodeMember);
      }
    }

  }
}
