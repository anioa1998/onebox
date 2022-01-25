using OneBox.DTOs;
using OneBox.Models;

namespace OneBox.Repositories
{
    public interface IPackRepository
    {
        PackDTO GetPack(int packId);
        Pack GetPackModel(int packId);
        void UpdatePackModel(PackDTO packDTO);
    }
}