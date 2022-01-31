using Microsoft.EntityFrameworkCore;
using OneBox.DTOs;
using OneBox.Enums;
using OneBox.Models;
using System;
using System.Linq;

namespace OneBox.Repositories
{
    public class PackRepository : IPackRepository
    {
        private readonly AppDbContext _appDbContext;

        public PackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int AddPack(PackDTO packDTO, ParcelLocker locker)
        {
            Pack packModel = new Pack()
            {
                ModifedAt = DateTime.Now,
                RecipientParcel = locker,
                SenderPhone = packDTO.SenderPhone,
                RecipientPhone = packDTO.RecipientPhone,
                Size = packDTO.Size,
                State = PackState.P_NEW
            };

            _appDbContext.Packs.Add(packModel);
            _appDbContext.SaveChanges();
            return packModel.Id;
        }

        public PackDTO GetPack(int packId, string phoneNumber)
        {
            var model = GetPackModel(packId);
            if(model.RecipientPhone != phoneNumber)
            {
                return new PackDTO();
            }
            var packDTO = new PackDTO()
            {
                Id = model.Id,
                ModifedAt = model.ModifedAt,
                RecipientPhone = model.RecipientPhone,
                SenderPhone = model.SenderPhone,
                Size = model.Size,
                State = model.State
            };
            if (model.PostBox != null)
            {
                packDTO.PostBoxDTO = new PostBoxDTO()
                {
                    Id = model.PostBox.Id,
                    Size = model.PostBox.Size,
                    State = model.PostBox.State
                };
            }
            return packDTO;
        }

        public Pack GetPackModel(int packId)
        {
            return _appDbContext.Packs.Include("PostBoxes")
                                      .Include("Couriers")
                                      .Include("ParcelLockers")
                                      .Single(p => p.Id == packId);
        }

        public int GetPostBoxId(int packId)
        {
            return _appDbContext.Packs.Where(p => p.Id == packId)
                                      .Select(p => p.PostBox.Id)
                                      .FirstOrDefault();
        }
    }
}
