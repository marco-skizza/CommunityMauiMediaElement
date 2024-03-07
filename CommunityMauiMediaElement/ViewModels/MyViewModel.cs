namespace CommunityMauiMediaElement.ViewModels;

public class MyViewModel
{
    public string FilePath => Path.Combine(BaseFolderPath, "Sister.m4a");

    private string BaseFolderPath
    {
        get
        {
#if IOS || MACCATALYST
            return Foundation.NSBundle.MainBundle.BundlePath;
#elif WINDOWS10_0_17763_0_OR_GREATER
            return AppDomain.CurrentDomain.BaseDirectory;
#elif ANDROID
            return "file:///android_asset/";
#else
            throw new NotImplementedException();
#endif
        }
    }
}