using OneBox.DTOs;
using System.Collections.Generic;

namespace OneBox.Repositories
{
    public interface ILockerRepository
    {
        List<LockerDTO> GetLockersOnStreets(List<string> streets, string city);
        bool GetPostBox(int idPack, out int idPostBox);
        List<int> GetAllFilledPostBoxes(int lockerId);
        List<PostBoxDTO> GetAllPostBoxes(int lockerId);
    }
}