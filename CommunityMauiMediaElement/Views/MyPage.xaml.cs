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
    }

    ~MyPage()
    {
        Debug.WriteLine("~MyPage() called");
    }
}