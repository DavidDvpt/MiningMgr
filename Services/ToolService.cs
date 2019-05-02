using Model;
using Services.Interfaces;

namespace Services
{
    public abstract class ToolService<T> : UnstackableService<T>, IToolService<T>
        where T : Tool, new()
    {
    }
}
