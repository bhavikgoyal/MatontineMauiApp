using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.templates
{
    class MyCustomViewStepNavigator
    {
		private List<MyCustomViewStep> views = new List<MyCustomViewStep>();

		private MyCustomViewStep _CurrentStep;
		public MyCustomViewStep CurrentStep { get => _CurrentStep; }

		private int _CurrentStepIndex;

		public MyDefaultTemplate Template { get; internal set; }

		public void Add(MyCustomViewStep v)
		{
			views.Add(v);
		}

		public void ForEach(Action<MyCustomViewStep> action)
		{
			views.ForEach(action);
		}

		public bool CurrentStepIsValid()
		{
			return _CurrentStep.View.HasValidData();
		}

		public bool IsFirstStep()
		{
			return _CurrentStepIndex == 0;
		}


		public bool IsLastStep()
		{
			return ((_CurrentStepIndex + 1) == views.Count);
		}

		public bool IsBeforeLastStep()
		{
			return ((_CurrentStepIndex + 1) == (views.Count - 1));
		}

		public void Start()
		{
			UpdateChildView(0, true);
		}

		public void Next(int stepIncrement = 1)
		{
			if ((_CurrentStepIndex + stepIncrement) < views.Count)
			{
				UpdateChildView(_CurrentStepIndex + stepIncrement, true);
			}
		}

		public void Prev()
		{
			if ((_CurrentStepIndex - 1) >= 0)
			{
				UpdateChildView(_CurrentStepIndex - 1, false);
			}
		}

		private void UpdateChildView(int index, bool refreshData)
		{
			_CurrentStepIndex = index;
			UpdateChildView(views.ElementAt(index), refreshData);
		}

		private void UpdateChildView(MyCustomViewStep v, bool refreshData)
		{
			_CurrentStep = v;
			Template.UpdateChildView(_CurrentStep.View);
			if (refreshData)
			{
				_CurrentStep.View.RefreshData();
			}
			Template.UpdateChildView(_CurrentStep.View);
		}

		public void RefresLanguageData()
		{
			foreach (var v in views) v.View.RefreshData();
		}
	}
}
