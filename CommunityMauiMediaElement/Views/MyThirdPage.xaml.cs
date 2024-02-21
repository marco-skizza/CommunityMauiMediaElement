using System.Diagnostics;
namespace CommunityMauiMediaElement.Views;

public partial class MyThirdPage : ContentPage
{
	public MyThirdPage()
	{
		InitializeComponent();
		Trace.WriteLine($"{this.GetType().FullName} Initialized");
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}

	~MyThirdPage()
	{
		Trace.WriteLine($"{this.GetType().FullName} Disposed");
	}
	
	private async void Button_OnClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(AppShell.GetRoute<MyPage>());
	}
}