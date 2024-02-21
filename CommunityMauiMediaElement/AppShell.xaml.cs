using CommunityMauiMediaElement.Views;

namespace CommunityMauiMediaElement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MyPage), typeof(MyPage));
            Routing.RegisterRoute(nameof(MyThirdPage), typeof(MyThirdPage));
        }
    }
}
