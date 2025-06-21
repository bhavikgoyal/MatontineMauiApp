using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class CommunityInfosResponseDto
  {
		public CommunityInfosDto gestionnairedata { get; set; }
		public string CommnunityId { get => gestionnairedata?.communityId; }
	}
}
