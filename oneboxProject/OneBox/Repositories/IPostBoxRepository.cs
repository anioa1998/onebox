using OneBox.DTOs;
using OneBox.Enums;

namespace OneBox.Repositories
{
    public interface IPostBoxRepository
    {
        PostBoxDTO GetPostBox(int postBoxId);
        PostBoxDTO GetPostBox(int lockerId, Size size);
    }
}