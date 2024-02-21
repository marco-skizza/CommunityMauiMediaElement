using System.Diagnostics;
using CommunityMauiMediaElement.ViewModels;

namespace CommunityMauiMediaElement.Views;

public partial class MyPage : ContentPage
{
    public MyPage(MyViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        Unloaded += OnUnloaded;
    }

    private void OnUnloaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("OnUnloaded() called");
        MyMediaElement.Pause();
    }

    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        base.OnHandlerChanging(args);

        if (args.NewHandler != null)
        {
            return;
        }

        MyMediaElement.Handler?.DisconnectHandler();
        Debug.WriteLine("OnHandlerChanging.DisconnectHandler() called");
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MyThirdPage));
    }

    ~MyPage()
    {
        Debug.WriteLine("~MyPage() called");
    }
}