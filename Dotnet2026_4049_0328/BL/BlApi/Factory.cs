
namespace BL.BlApi;

public static class Factory
{
    public static BlApi.IBl Get()
    {
        return new BlImplementation.Bl();
    }
}
