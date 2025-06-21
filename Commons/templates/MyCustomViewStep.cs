using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.templates
{
    class MyCustomViewStep
    {
		public MyCustomViewStep(string s, MyDefaultTemplateInfosView v)
		{
			StepName = s;
			View = v;
		}

		public string StepName { get; set; }
		public MyDefaultTemplateInfosView View { get; set; }
	}
}
