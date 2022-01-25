using OneBox.DTOs;

namespace OneBox.Repositories
{
    public interface IPackRepository
    {
        PackDTO GetPack(int packId);
    }
}