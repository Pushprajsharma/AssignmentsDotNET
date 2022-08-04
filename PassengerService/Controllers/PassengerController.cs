using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        List<Passenger> passengerList = new List<Passenger>()
        {
            new Passenger() { passengerId=1 , passengerName = "John" , passengerGender="male" , passengerLocation="Pune" , passengerNumber=12344},
            new Passenger() { passengerId=2 , passengerName = "SMinth" , passengerGender="male" , passengerLocation="Bangalore" , passengerNumber=123564},
            new Passenger() { passengerId=3 , passengerName = "Mary" , passengerGender="female" , passengerLocation="Chennai" , passengerNumber=123114},
        };

        [HttpGet]

        public IActionResult getAllPassengers()
        {
            return Ok(passengerList);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult getPassengerById(int id)
        {
            Passenger obj = passengerList.Find(item => item.passengerId == id);
            if (obj != null)
            {
                return Ok(obj);

            }
            else {
                return NotFound("No Passenger exist");

            }
        }

        [HttpPost]

        public IActionResult addPassenger(Passenger obj)
        {
            passengerList.Add(obj);
            return Ok(passengerList);

        }

        [HttpPut]

        public IActionResult updatePassenger(Passenger obj)
        {
            var objToDelete = passengerList.Find(item => item.passengerId == obj.passengerId);
            passengerList.Remove(objToDelete);
            passengerList.Add(obj);
            return Ok(passengerList);
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult deletePassenger(int id) 
        {
            Passenger obj = passengerList.Find(item => item.passengerId == id);
            if (obj != null)
            {
                passengerList.Remove(obj);
                return Ok(passengerList);
            }
            else 
            {
                return NotFound("NO PASSENGER EXIST");
            }
        }
    }
}
