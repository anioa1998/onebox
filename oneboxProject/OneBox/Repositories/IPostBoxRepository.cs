using OneBox.DTOs;

namespace OneBox.Repositories
{
    public interface IPostBoxRepository
    {
        PostBoxDTO GetPostBox(int id);
        PostBoxDTO GetPostBox(int lockerId, int size);
    }
}