using OneBox.DTOs;
using OneBox.Enums;

namespace OneBox.Helpers
{
    public interface IPostBoxHelper
    {
        PostBoxDTO GetPostBox(int packId);
    }
}