﻿using OneBox.DTOs;
using OneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBox.Repositories
{
    public class LockerRepository : ILockerRepository
    {
        private readonly AppDbContext _appDbContext;

        public LockerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

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
            var lockers = new List<LockerDTO>();

            foreach(var street in streetsLockerDTO.Streets)
            {
                var listLockers = _appDbContext.ParcelLockers.Where(p => p.Street == street && p.City == streetsLockerDTO.City)
                                                             .Select(p => new LockerDTO()
                                                             {
                                                                 Id = p.Id,
                                                                 City = p.City,
                                                                 Street = p.Street,
                                                                 ParcelNumber = p.ParcelNumber,
                                                                 Postcode = p.Postcode
                                                             })
                                                             .ToList();
                lockers.AddRange(listLockers);
            }

            return lockers;
        }

    }
}
