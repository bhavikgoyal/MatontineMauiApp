using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static readonly string BASE_URL = "https://matontine.online:85/WebService.asmx";

        public event PropertyChangedEventHandler PropertyChanged;


        public static NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        public static bool offlineModel = false;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static IMaTontineAPI getInstance()
        {
            var httpClient = new HttpClient(new HttpLoggingHandler())
            {
                BaseAddress = new Uri(BASE_URL)
            };
            return RestService.For<IMaTontineAPI>(httpClient);
        }

        private static readonly Lazy<IMaTontineAPI> lazy =
            new Lazy<IMaTontineAPI>(() => getInstance());
        public static IMaTontineAPI Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public static void InjectCredentials(Credentials req)
        {
            req.plogin = CommonsResources.credentials.plogin;
            req.ppassword = CommonsResources.credentials.ppassword;
        }
        public BaseViewModel()
        {
            accessType = Connectivity.Current.NetworkAccess;
        }
    }
}
