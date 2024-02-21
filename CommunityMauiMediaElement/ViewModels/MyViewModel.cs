namespace CommunityMauiMediaElement.ViewModels;

public class MyViewModel(IFileSystem fileSystem)
{
    public string FilePath => Path.Combine(fileSystem.AppDataDirectory, "Sister.m4a");
}