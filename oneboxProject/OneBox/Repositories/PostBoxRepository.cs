using OneBox.DTOs;
using OneBox.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Repositories
{
    public class PostBoxRepository : IPostBoxRepository
    {
        public PostBoxDTO GetPostBox(int postBoxId)
        {
            throw new NotImplementedException();
        }

        public PostBoxDTO GetPostBox(int lockerId, Size size)
        {
            throw new NotImplementedException();
        }
    }
}
