using System.Diagnostics;
using CommunityMauiMediaElement.Views;

namespace CommunityMauiMediaElement
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
		
		protected override void OnAppearing()
		{
			base.OnAppearing();
			
			Trace.WriteLine("Pages in NavigationStack:");

			foreach (var page in Navigation.NavigationStack)
			{
				Trace.WriteLine($"\t{page?.GetType().FullName ?? "null"}");
			}
			
			GC.Collect();
			GC.WaitForPendingFinalizers();
			var totalMemory = GC.GetTotalMemory(true);
			Trace.WriteLine($"Memory: {totalMemory}");
		}

		private async void Button_OnClicked(object? sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(AppShell.GetRoute<MyThirdPage>());
		}
	}
}