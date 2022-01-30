using OneBox.DTOs;
using System.Collections.Generic;

namespace OneBox.Repositories
{
    public interface ILockerRepository
    {
        List<LockerDTO> GetLockersOnStreets(List<LockerDTO> inputStreet);
        List<int> GetAllFilledPostBoxes(int lockerId);
        List<PostBoxDTO> GetAllPostBoxes(int lockerId);
    }
}