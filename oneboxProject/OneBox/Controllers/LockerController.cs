using Microsoft.AspNetCore.Mvc;
using OneBox.DTOs;
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

        public LockerController(ILockerRepository lockerRepository, ICourierRepository courierRepository)
        {
            _lockerRepository = lockerRepository;
            _courierRepository = courierRepository;
        }

        [HttpPost("streets")]
        public ActionResult<List<LockerDTO>> GetLockers([FromBody] List<string> streets, [FromBody] string city)
        {
            return Ok(_lockerRepository.GetLockersOnStreets(streets, city));
        }

        [HttpGet("pack/{packId}")]
        public ActionResult<int> GetPostBox([FromRoute] int packId)
        {
            int postBoxId;
            if(!_lockerRepository.GetPostBox(packId, out postBoxId))
            {
                return NotFound();
            }

            return Ok(postBoxId);
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
