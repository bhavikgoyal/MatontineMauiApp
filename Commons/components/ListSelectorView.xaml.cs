using MatontineDigitalApp.Commons.components.parameter;
using System.Collections.ObjectModel;

namespace MatontineDigitalApp.Commons.components;

public partial class ListSelectorView : ContentView
{
	public ObservableCollection<SimpleListItemData> MyItems = new ObservableCollection<SimpleListItemData>();

	private SimpleListItemData _ItemSelected;
	public string ItemTitle { get; set; }

	public event EventHandler OnItemSelected;

	public ListSelectorView()
	{
		InitializeComponent();
		listView.ItemsSource = MyItems;
		listView.SizeChanged += ListView_SizeChanged;
	}

	private void ListView_SizeChanged(object sender, EventArgs e)
	{
		// Optional: add resizing logic here if needed
	}

	public List<SimpleListItemData> ItemsSource
	{
		set
		{
			MyItems.Clear();
			foreach (var v in value)
				MyItems.Add(v);

			double nHeight = 10;
			foreach (var item in MyItems)
				nHeight += 40;

			listView.HeightRequest = nHeight;
		}
	}

	public void AutoSelectFirstElement()
	{
		ItemSelected = MyItems.FirstOrDefault();
	}

	public SimpleListItemData ItemSelected
	{
		get => _ItemSelected;
		set
		{
			_ItemSelected = value;
			SelectItem();
		}
	}

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		_ItemSelected = e.CurrentSelection.FirstOrDefault() as SimpleListItemData;
		SelectItem();
	}

	private void SelectItem()
	{
		var descr = _ItemSelected?.Description ?? "";

		lblItemSelected.Text = string.IsNullOrEmpty(ItemTitle)
				? descr
				: $"{ItemTitle}: {descr}";

		if (!string.IsNullOrEmpty(_ItemSelected?.Code))
		{
			OnItemSelected?.Invoke(_ItemSelected, EventArgs.Empty);
		}
	}
}
