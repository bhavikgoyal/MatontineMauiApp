using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using MatontineDigitalApp.Commons.components.parameter;

namespace MatontineDigitalApp.Commons.templates
{
	public partial class MyDefaultTemplateInfosSelectorView : ContentView
	{
		private SimpleListItemData itemSelected;

		private readonly Func<string> getTitleText;
		private readonly Func<string> getItemTitle;
		private readonly Func<string> getSubTitleText;
		private readonly Func<string> getSelectText;
		private readonly Func<List<SimpleListItemData>> getItemsSource;
		private readonly Action<SimpleListItemData> itemSelectedAction;
		private readonly bool autoSelectFirstElement;

		public string TitleText { get; private set; }
		public string SubTitleText { get; private set; }

		public MyDefaultTemplateInfosSelectorView(
						Func<string> getTitleText,
						Func<string> getItemTitle,
						Func<string> getSubTitleText,
						Func<string> getSelectText,
						Func<List<SimpleListItemData>> getItemsSource,
						Action<SimpleListItemData> itemSelectedAction,
						Func<SimpleListItemData>? getInitSelected = null,
						bool autoSelectFirstElement = false)
		{
			InitializeComponent();

			this.getTitleText = getTitleText ?? throw new ArgumentNullException(nameof(getTitleText));
			this.getItemTitle = getItemTitle ?? throw new ArgumentNullException(nameof(getItemTitle));
			this.getSubTitleText = getSubTitleText ?? throw new ArgumentNullException(nameof(getSubTitleText));
			this.getSelectText = getSelectText ?? throw new ArgumentNullException(nameof(getSelectText));
			this.getItemsSource = getItemsSource ?? throw new ArgumentNullException(nameof(getItemsSource));
			this.itemSelectedAction = itemSelectedAction ?? throw new ArgumentNullException(nameof(itemSelectedAction));
			this.autoSelectFirstElement = autoSelectFirstElement;

			if (getInitSelected != null)
			{
				itemSelected = getInitSelected();
			}

			// Hook up item selection event
			listSelectorView.SelectionChanged += ListSelectorView_SelectionChanged;

			RefreshData();
		}

		public virtual void RefreshData()
		{
			TitleText = getTitleText();
			SubTitleText = getSubTitleText();
			listSelectorView.ItemTemplate = new DataTemplate(() =>
			{
				var label = new Label { Text = getItemTitle() };
				return new ViewCell { View = label };
			});

			InitListView();
			AutoSelect();
		}

		public void AutoSelect()
		{
			if (itemSelected == null && autoSelectFirstElement)
			{
				listSelectorView.SelectedItem = listSelectorView.ItemsSource is List<SimpleListItemData> items && items.Count > 0
						? items[0]
						: null;
			}
			else
			{
				listSelectorView.SelectedItem = itemSelected;
			}
		}

		public virtual void InitListView()
		{
			SetItemsSource(getItemsSource());
		}

		public void SetItemsSource(List<SimpleListItemData> items)
		{
			listSelectorView.ItemsSource = items;
		}

		public virtual bool HasValidData()
		{
			if (itemSelected == null)
			{
				// You may want to throw an exception or return false here
				return false;
			}
			return true;
		}

		private void ListSelectorView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			itemSelected = e.CurrentSelection.FirstOrDefault() as SimpleListItemData;
			itemSelectedAction?.Invoke(itemSelected);
		}

		public void ResetItemSelected()
		{
			itemSelected = null;
			listSelectorView.SelectedItem = null;
			listSelectorView.ItemsSource = null; // Or reset items to the original list if needed
		}
	}
}
