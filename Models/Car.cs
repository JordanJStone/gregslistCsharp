using System;
using System.ComponentModel.DataAnnotations;

namespace gregslistCsharp.Models
{
  public class Car
  {

    public Car(string make, string model, int year, string type, string id)
    {
      this.Make = make;
      this.Model = model;
      this.Year = year;
      this.Type = type;
      this.Id = id;

    }
    [Required]
    [MinLength(2)]
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();



  }
}