using UnityEngine;

internal sealed class PlatformFactory
{
    private readonly InputFactory _inputFactory;
    private readonly WindowFactory _windowFactory;

    public PlatformFactory()
    {
        _inputFactory = new InputFactory();
        _windowFactory = new WindowFactory();
    }
    
    public Platform CreatePlatform(RuntimePlatform platform)
    {
        return new Platform(_windowFactory.CreateWindow(platform), _inputFactory.CreateInput(platform));
    }
}