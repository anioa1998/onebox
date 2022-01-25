using OneBox.DTOs;
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
            return new PostBoxDTO();
        }
    }
}
