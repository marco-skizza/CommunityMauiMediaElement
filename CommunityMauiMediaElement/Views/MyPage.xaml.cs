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

    /// <summary>
    /// Gets only called on iOS and Windows when navigation to a next page.
    /// </summary>
    private void OnUnloaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("OnUnloaded() called");

#if IOS || WINDOWS10_0_17763_0_OR_GREATER
        MyMediaElement.Pause();
        Debug.WriteLine("MyMediaElement paused");
#endif
    }

    /// <summary>
    /// Works for iOS, Android and Windows
    /// </summary>
    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        base.OnHandlerChanging(args);

        if (args.NewHandler != null)
        {
            return;
        }

        Debug.WriteLine("OnHandlerChanging() called with null Handler");

        MyMediaElement.Handler?.DisconnectHandler();
        Debug.WriteLine("MyMediaElement disposed");
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