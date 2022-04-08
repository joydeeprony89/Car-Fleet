using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
  class Program
  {
    // https://www.youtube.com/watch?v=Pr6T-3yB9RM
    static void Main(string[] args)
    {
      int target = 12;
      var position = new int[] { 10, 8, 0, 5, 3 };
      var speed = new int[] { 2, 4, 1, 1, 3 };
      Program p = new Program();
      var result = p.CarFleet(target, position, speed);
      Console.WriteLine(result);
    }

    public class Car
    {
      public int Position { get; set; }
      public double TimetoReachTheTarget { get; set; }
    }

    public int CarFleet(int target, int[] position, int[] speed)
    {
      int result = 0;
      List<Car> cars = new List<Car>();
      int size = position.Length;
      for (int i = 0; i < size; i++)
      {
        var obj = new Car()
        {
          Position = position[i],
          TimetoReachTheTarget = (target - position[i]) / (double)speed[i]
        };
        cars.Add(obj);
      }
      // need to sort the list in desc as we want the car which is nearest to target, should be at the start of the line in one way road.
      cars = cars.OrderByDescending(x => x.Position).ToList();

      double maxTime = 0d;
      foreach(var car in cars)
      {
        if (car.TimetoReachTheTarget > maxTime)
        {
          maxTime = car.TimetoReachTheTarget;
          result++;
        }
      }
      return result;
    }
  }
}
