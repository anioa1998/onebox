using OneBox.DTOs;
using OneBox.Enums;
using OneBox.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Helpers
{
    public class PostBoxHelper : IPostBoxHelper
    {
        private readonly IPackRepository _packRepository;
        private readonly IPostBoxRepository _postBoxRepository;

        public PostBoxHelper(IPackRepository packRepository, IPostBoxRepository postBoxRepository)
        {
            _packRepository = packRepository;
            _postBoxRepository = postBoxRepository;
        }

        public PostBoxDTO GetPostBox(int packId)
        {
            var postbox = new PostBoxDTO();
            var pack = _packRepository.GetPackModel(packId);

            if(pack.State == PackState.P_NEW)
            {
                postbox = _postBoxRepository.GetPostBox(pack.SenderParcel.Id, pack.Size);

            }
            if(pack.State == PackState.P_SENT && )
        }
    }
}
