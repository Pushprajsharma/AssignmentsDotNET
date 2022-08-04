using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        List<Driver> driverList = new List<Driver>()
        {
            new Driver() { driverId=1 , driverName = "Driver1" , driverGender="male" , driverLocation="Pune" , driverNumber=12344},
            new Driver() { driverId=2 , driverName = "Driver2" , driverGender="male" , driverLocation="Bangalore" , driverNumber=123564},
            new Driver() { driverId=3 , driverName = "Driver3" , driverGender="female" , driverLocation="Chennai" , driverNumber=123114},
        };

        [HttpGet]

        public IActionResult getAllDrivers()
        {
            return Ok(driverList);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult getDriverById(int id)
        {
            Driver obj = driverList.Find(item => item.driverId == id);
            if (obj != null)
            {
                return Ok(obj);

            }
            else
            {
                return NotFound("No driver exist");

            }
        }

        [HttpPost]

        public IActionResult addDriver( Driver obj)
        {
            driverList.Add(obj);
            return Ok(driverList);

        }

        [HttpPut]

        public IActionResult updatePassenger(Driver obj)
        {
            var objToDelete = driverList.Find(item => item.driverId == obj.driverId);
            driverList.Remove(objToDelete);
            driverList.Add(obj);
            return Ok(driverList);
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult deletePassenger(int id)
        {
            Driver obj = driverList.Find(item => item.driverId == id);
            if (obj != null)
            {
                driverList.Remove(obj);
                return Ok(driverList);
            }
            else
            {
                return NotFound("NO ]Driver EXIST");
            }
        }
    }
}
