
namespace MatontineDigitalApp.Pages.Profile
{
    internal class SelectContryView
    {
        private EditProfilePage editProfilePage;
        private Action<object> value;
        private object profile_country;

        public SelectContryView(EditProfilePage editProfilePage, Action<object> value, object profile_country)
        {
            this.editProfilePage = editProfilePage;
            this.value = value;
            this.profile_country = profile_country;
        }
    }
}