using Services.Context;

namespace Services.Interfaces
{
    public interface IServiceBase
    {
        void Commit();

        MiningContext GetContext();
    }
}
