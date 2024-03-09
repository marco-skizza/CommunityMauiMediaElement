using System.Diagnostics;
using CommunityMauiMediaElement.ViewModels;

namespace CommunityMauiMediaElement.Views;

public partial class MyPage : ContentPage
{
    public MyPage(MyViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnUnloaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("OnUnloaded() called");
        MyMediaElement.Pause();

#if ANDROID
        DisposeMediaElement();
        Debug.WriteLine("MyMediaElement disposed (Android)");
#endif
    }

    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        base.OnHandlerChanging(args);

        if (args.NewHandler != null)
        {
            return;
        }

#if IOS
        DisposeMediaElement();
        Debug.WriteLine("MyMediaElement disposed (iOS)");
#endif
    }

    private void DisposeMediaElement()
    {
        MyMediaElement.Handler?.DisconnectHandler();
        MyMediaElement.Dispose();
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