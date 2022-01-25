using OneBox.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Repositories
{
    public class PostBoxRepository : IPostBoxRepository
    {
        public PostBoxDTO GetPostBox(int id)
        {
            throw new NotImplementedException();
        }

        public PostBoxDTO GetPostBox(int lockerId, int size)
        {
            throw new NotImplementedException();
        }
    }
}
