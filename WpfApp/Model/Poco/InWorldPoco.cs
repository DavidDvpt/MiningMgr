using WpfApp.Model.Dto.Interfaces;

namespace WpfApp.Model.Poco
{
    public class InWorldPoco<TDto> : CommunPoco<TDto>
        where TDto : ICommunDto
    {

    }
}
