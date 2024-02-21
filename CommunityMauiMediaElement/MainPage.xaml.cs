using System.Diagnostics;
using CommunityMauiMediaElement.Views;

namespace CommunityMauiMediaElement
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object? sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            var totalMemory = GC.GetTotalMemory(true);
            Debug.WriteLine($"Memory: {totalMemory}");
        }

        private async void Button_OnClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MyPage));
        }
    }
}
