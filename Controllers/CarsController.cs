using System.Collections.Generic;
using gregslistCsharp.db;
using gregslistCsharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslistCsharp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {


    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(FAKEDB.Cars);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Car> GetCarById(string id)
    {
      try
      {
        Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
        return Ok(carToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]

    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        FAKEDB.Cars.Add(newCar);
        return Ok(newCar);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{carId}")]

    public ActionResult<string> BuyCar(string carId)
    {
      try
      {
        Car carToRemove = FAKEDB.Cars.Find(c => c.Id == carId);
        if (FAKEDB.Cars.Remove(carToRemove))
        {
          return Ok("Car Purchased");
        }
        throw new System.Exception("This car just don't exist, sorry mate");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]

    public ActionResult<Car> EditCar([FromBody] Car carUpdate, string carId)
    {
      try
      {
        Car foundCar = FAKEDB.Cars.Find(c => c.Id == carId);

        carUpdate.Make = carUpdate.Make != null ? carUpdate.Make : foundCar.Make;
        carUpdate.Model = carUpdate.Model != null ? carUpdate.Model : foundCar.Model;
        carUpdate.Year = carUpdate.Year != foundCar.Year ? carUpdate.Year : foundCar.Year;
        carUpdate.Type = carUpdate.Type != null ? carUpdate.Type : foundCar.Type;
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


  }
}