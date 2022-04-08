internal sealed class Platform : IPlatform
{
    public IWindow Window { get; }

    public IInput Input { get; }

    public Platform(IWindow window, IInput input)
    {
        Input = input;
        Window = window;
    }
}