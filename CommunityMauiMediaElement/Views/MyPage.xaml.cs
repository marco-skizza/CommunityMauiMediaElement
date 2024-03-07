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

#if ANDROID || WINDOWS10_0_17763_0_OR_GREATER
        DisposeMediaElement();
        Debug.WriteLine("MyMediaElement disposed (ANDROID + WinUI)");
#endif
    }

    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        base.OnHandlerChanging(args);

        if (args.NewHandler != null)
        {
            return;
        }

#if IOS || MACCATALYST
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