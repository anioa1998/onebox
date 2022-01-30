using Microsoft.EntityFrameworkCore;
using OneBox.DTOs;
using OneBox.Models;
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

        public PackDTO GetPack(int packId)
        {
            var model = GetPackModel(packId);

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

        public void UpdatePackModel(PackDTO packDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
