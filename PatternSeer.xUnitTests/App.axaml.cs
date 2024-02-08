using Avalonia;
using Avalonia.Headless;
using Avalonia.Markup.Xaml;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}