using OneBox.DTOs;

namespace OneBox.Repositories
{
    public interface IPostBoxRepository
    {
        PostBoxDTO GetPostBox(int postBoxId);
        PostBoxDTO GetPostBox(int lockerId, int size);
    }
}