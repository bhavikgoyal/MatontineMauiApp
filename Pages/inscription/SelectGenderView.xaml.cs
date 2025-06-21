using Microsoft.Maui.Controls;
using System;
using MatontineDigitalApp.Commons; 
namespace MatontineDigitalApp.Pages.inscription
{
    public partial class SelectGenderView : ContentView
    {
        private readonly Action<string, string> _onGenderSelected;
        private string _selectedGender;

        public SelectGenderView(Action<string, string> onGenderSelected, string initGender = null)
        {
            InitializeComponent();
            _onGenderSelected = onGenderSelected;

            if (!string.IsNullOrEmpty(initGender))
            {
                _selectedGender = initGender;
                UpdateGenderSelection(_selectedGender);
            }
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            _selectedGender = "Woman";
            var description = GetLocalizedGenderDescription(_selectedGender);
            _onGenderSelected?.Invoke(_selectedGender, description);
            UpdateGenderSelection(_selectedGender);
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            _selectedGender = "Man";
            var description = GetLocalizedGenderDescription(_selectedGender);
            _onGenderSelected?.Invoke(_selectedGender, description);
            UpdateGenderSelection(_selectedGender);
        }

        private void UpdateGenderSelection(string selectedGender)
        {
            if (selectedGender == "Woman")
            {
                femaleImage.Opacity = 1.0;
                maleImage.Opacity = 0.5;

                femaleFrame.Stroke = Color.FromArgb("#27ae60"); // green
                maleFrame.Stroke = Color.FromArgb("#d2d2d7");   // gray
            }
            else if (selectedGender == "Man")
            {
                femaleImage.Opacity = 0.5;
                maleImage.Opacity = 1.0;

                femaleFrame.Stroke = Color.FromArgb("#d2d2d7"); // gray
                maleFrame.Stroke = Color.FromArgb("#27ae60");   // green
            }
        }

        private string GetLocalizedGenderDescription(string genderValue)
        {
            var lang = MyTranslator.CurrentLanguageCD; // e.g., "FR" or "EN"
            return genderValue switch
            {
                "Woman" => lang == "FR" ? "Femme" : "Woman",
                "Man" => lang == "FR" ? "Homme" : "Man",
                _ => genderValue
            };
        }
    }
}
