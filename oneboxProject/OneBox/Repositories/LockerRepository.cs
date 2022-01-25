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

        public List<LockerDTO> GetLockersOnStreets(List<string> streets, string city)
        {
            throw new NotImplementedException();
        }

        public bool GetPostBox(int idPack, out int idPostBox)
        {
            throw new NotImplementedException();
        }
    }
}
