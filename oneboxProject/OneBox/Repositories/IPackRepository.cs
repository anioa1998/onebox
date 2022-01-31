using OneBox.DTOs;
using OneBox.Models;

namespace OneBox.Repositories
{
    public interface IPackRepository
    {
        PackDTO GetPack(int packId, string phoneNumber);
        Pack GetPackModel(int packId);
        int AddPack(PackDTO packDTO, ParcelLocker locker);
        int GetPostBoxId(int packId);

    }
}