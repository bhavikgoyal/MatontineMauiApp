using MatontineDigitalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels.MemberView
{
    public class MemberViewModel : BaseViewModel
    {
        private ObservableCollection<MemberDto> _Member;
        public ObservableCollection<MemberDto> Member
        {
            get { return _Member; }

            set
            {
                _Member = value;
                NotifyPropertyChanged(nameof(Member));
            }
        }
        public MemberViewModel(INavigation navigation)
        {
            // Constructor logic here
            GetMemeberlist();
        }

        public async Task GetMemeberlist()
        {
            var req = new GetListMembersRequest();
            BaseViewModel.InjectCredentials(req);
            var data = await Instance.GetMembers(req);
            if (data != null && data.Count > 0)
            {
                Member = new ObservableCollection<MemberDto>();
                //AllMember = new ObservableCollection<MemberDto>(Member);
                //IsLoading = false;
            }


        }
    }
}
