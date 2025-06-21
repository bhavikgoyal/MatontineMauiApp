using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MatontineDigitalApp.Commons.components
{
    public partial class SelectListviewImageCircleView : ContentView
    {
        private SelectListviewImageCircleModel itemSelected;

        public ObservableCollection<SelectListviewImageCircleModel> MyItems { get; } = new ObservableCollection<SelectListviewImageCircleModel>();

        public event EventHandler ItemSelected;

        public Command MyCommand { get; }

        public SelectListviewImageCircleView()
        {
            InitializeComponent();

            MyCommand = new Command((obj) =>
            {
                var item = obj as SelectListviewImageCircleModel;
                SelectItem(item);
                ItemSelected?.Invoke(item, EventArgs.Empty);
            });

            BindingContext = this;
        }

        public List<SelectListviewImageCircleModel> ItemsData
        {
            set
            {
                MyItems.Clear();
                foreach (var item in value)
                    MyItems.Add(item);
            }
        }

        public void SelectItem(string itemKey)
        {
            if (string.IsNullOrEmpty(itemKey))
            {
                return;
            }

            var item = MyItems.FirstOrDefault((e) => e.ItemKey == itemKey);
            SelectItem(item);
        }

        public void SelectItem(SelectListviewImageCircleModel item)
        {
            if (item == null)
            {
                return;
            }

            itemSelected = item;

            foreach (var e in MyItems)
                e.IsSelected = false;

            item.IsSelected = true;
        }

        public SelectListviewImageCircleModel GetItemSelected()
        {
            return itemSelected;
        }

        public object GetItemSelectedData()
        {
            return itemSelected?.Data;
        }
    }

    public class SelectListviewImageCircleModel : INotifyPropertyChanged
    {
        public object Data { get; set; }

        public string ItemKey { get; set; }

        public ImageSource MyImage { get; set; }

        private string _ImageBase64;

        public string ImageBase64
        {
            get => _ImageBase64;
            set
            {
                _ImageBase64 = value;
                MyImage = Utils.Base64ToImage(_ImageBase64);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _IsSelected;
        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    SelectedColor = _IsSelected ? CommonsResources.primaryColor : Color.FromHex("#F3F2F1");
                    OnPropertyChanged();
                }
            }
        }

        private Color _selectedColor = Color.FromHex("#F3F2F1");
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
