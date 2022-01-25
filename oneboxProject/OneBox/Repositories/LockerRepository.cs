using OneBox.DTOs;
using System;
using System.Collections.Generic;

namespace OneBox.Repositories
{
    public class LockerRepository : ILockerRepository
    {
        public List<int> GetAllFilledPostBoxes(int lockerId)
        {
            throw new NotImplementedException();
        }

        public List<PostBoxDTO> GetAllPostBoxes(int lockerId)
        {
            throw new NotImplementedException();
        }

        public List<LockerDTO> GetLockersOnStreets(StreetsLockerDTO streetsLockerDTO)
        {
            throw new NotImplementedException();
        }

    }
}
