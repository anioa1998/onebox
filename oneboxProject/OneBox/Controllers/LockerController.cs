using Microsoft.AspNetCore.Mvc;
using OneBox.DTOs;
using OneBox.Enums;
using OneBox.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockerController : Controller
    {
        private readonly ILockerRepository _lockerRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IPackRepository _packRepository;
        private readonly IPostBoxRepository _postBoxRepository;

        public LockerController(ILockerRepository lockerRepository, 
            ICourierRepository courierRepository, 
            IPackRepository packRepository, 
            IPostBoxRepository postBoxRepository)
        {
            _lockerRepository = lockerRepository;
            _courierRepository = courierRepository;
            _packRepository = packRepository;
            _postBoxRepository = postBoxRepository;
        }

        [HttpPost("streets")]
        public ActionResult<List<LockerDTO>> GetLockers([FromBody] List<string> streets, [FromBody] string city)
        {
            return Ok(_lockerRepository.GetLockersOnStreets(streets, city));
        }

        [HttpGet("pack/{packId}")]
        public ActionResult<int> GetPostBox([FromRoute] int packId)
        {
            //var packDTO = _packRepository.GetPack(packId);
            //if(packDTO.PostBoxDTO == null || packDTO.State == PackState.P_SERVICE)
            //{
            //    _postBoxRepository.GetPostBox(packId.)
            //}

            return Ok();
        }

        [HttpGet("courier/{courierId}")]
        public ActionResult<List<int>> GetAllFilledPostBoxes([FromRoute] int courierId, [FromQuery] int lockerId)
        {
            if (!_courierRepository.IsCourierCheck(courierId))
            {
                return NotFound();
            }

            return _lockerRepository.GetAllFilledPostBoxes(lockerId);

        }
        [HttpGet("{lockerId}")]
        public ActionResult<List<PostBoxDTO>> GetAllPostBoxes([FromRoute] int lockerId)
        {
            return Ok(_lockerRepository.GetAllPostBoxes(lockerId));
        }
    }
}
