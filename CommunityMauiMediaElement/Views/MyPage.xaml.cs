using System.Diagnostics;
using CommunityMauiMediaElement.ViewModels;

namespace CommunityMauiMediaElement.Views;

public partial class MyPage : ContentPage
{
    public MyPage()
    {
        InitializeComponent();

        Trace.WriteLine($"{this.GetType().FullName} Initialized");
        
        Unloaded += OnUnloaded;
    }
    
    ~MyPage()
    {
        Trace.WriteLine($"{this.GetType().FullName} Disposed");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    private void OnUnloaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("OnUnloaded() called");
        MyMediaElement.Pause();
        MyMediaElement.Handler?.DisconnectHandler();
        Debug.WriteLine("OnHandlerChanging.DisconnectHandler() called");
        
        
        Unloaded -= OnUnloaded;
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(AppShell.GetRoute<MyThirdPage>());
    }
}