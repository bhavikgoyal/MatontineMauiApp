using MatontineDigitalApp.community.dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MatontineDigitalApp.community.view.Management
{
	public partial class ListCommunityView : ContentPage
	{
		public ObservableCollection<CommunityListItemData> MyItems { get; } = new ObservableCollection<CommunityListItemData>();

		public event EventHandler CommunitySelected;

		public Command<object> MyCommand { get; }

		public ListCommunityView()
		{
			InitializeComponent();

			MyCommand = new Command<object>((obj) =>
			{
				if (obj is CommunityListItemData item)
				{
					CommunitySelected?.Invoke(item.Community, EventArgs.Empty);
				}
			});

			BindingContext = this;
		}

		public List<CommunityListItemData> ItemsData
		{
			set
			{
				MyItems.Clear();
				foreach (var item in value)
				{
					MyItems.Add(item);
				}
			}
		}
	}
}
