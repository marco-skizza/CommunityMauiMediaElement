using CommunityMauiMediaElement.Views;

namespace CommunityMauiMediaElement
{
	public partial class AppShell : Shell
	{
		public AppShell(MainPage mainPage)
		{
			InitializeComponent();
			
			Items.Add(mainPage);

			Routing.RegisterRoute(GetRoute<MainPage>(), typeof(MainPage));
			Routing.RegisterRoute(GetRoute<MyPage>(), typeof(MyPage));
			Routing.RegisterRoute(GetRoute<MyThirdPage>(), typeof(MyThirdPage));
		}

		public static string GetRoute<T>() where T : ContentPage
		{
			if (typeof(T) == typeof(MainPage))
			{
				return $"//{nameof(MainPage)}";
			}

			if (typeof(T) == typeof(MyPage))
			{
				return $"//{nameof(MainPage)}/{nameof(MyThirdPage)}/{nameof(MyPage)}";
			}

			if (typeof(T) == typeof(MyThirdPage))
			{
				return $"//{nameof(MainPage)}/{nameof(MyThirdPage)}/";
			}

			throw new NotSupportedException();
		}
	}
}