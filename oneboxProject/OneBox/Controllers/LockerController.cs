using Microsoft.AspNetCore.Mvc;
using OneBox.DTOs;
using OneBox.Enums;
using OneBox.Helpers;
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
        private readonly IPostBoxHelper _postBoxHelper;

        public LockerController(ILockerRepository lockerRepository, 
            ICourierRepository courierRepository, 
            IPostBoxHelper postBoxHelper)
        {
            _lockerRepository = lockerRepository;
            _courierRepository = courierRepository;
            _postBoxHelper = postBoxHelper;
        }

        [HttpPost("streets")]
        public ActionResult<List<LockerDTO>> GetLockers([FromBody] StreetsLockerDTO streetsLockerDTO)
        {
            return Ok(_lockerRepository.GetLockersOnStreets(streetsLockerDTO));
        }

        [HttpGet("pack/{packId}")]
        public ActionResult<PostBoxDTO> GetPostBox([FromRoute] int packId)
        {
            return Ok(_postBoxHelper.GetPostBox(packId));
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
