using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe17_Generics.Exes
{
    class Vehicle
    {
        int id;
        public Vehicle(int id)
        {
            Id = id;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public void refill() 
        {
            Console.WriteLine("Refilling " + this.GetType().Name + " " + this.Id);
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Vehicle)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }

    class TerrestrialVehicle : Vehicle
    {
        public TerrestrialVehicle(int id) : base(id) { }

        public void checkSeatBelts()
        {
            Console.WriteLine("Checking seatbelts for " + this.GetType().Name);
        }
        public void checkAirBags()
        {
            Console.WriteLine("Checking airbags for " + this.GetType().Name);
        }
        public void checkTirePressure()
        {
            Console.WriteLine("Checking tire pressure for " + this.GetType().Name);
        }
 
    }

    class Limousine : TerrestrialVehicle
    {
        public Limousine(int id) : base(id) { }
    }

    class Bus : TerrestrialVehicle
    {
        public Bus(int id) : base(id)
        { }
    }
    
    class Boeing : Vehicle
    {
        public Boeing(int id) : base(id) { }

        public void checkFuel()
        {
            Console.WriteLine("Checking fuel for " + this.GetType().Name);
        }
        public void checkControls()
        {
            Console.WriteLine("Checking controls for " + this.GetType().Name);
        }
    }
 

    class Garage<T> where T : Vehicle
    {
        public delegate void CheckUp(T v);
        CheckUp checkUp;
        IList<T> vehicles = new List<T>();
        public Garage(CheckUp myCheckUp)
        {
            checkUp = myCheckUp;
        }
        public void refill()
        {
            foreach (T t in vehicles)
            {
                t.refill();
            }
        }

        public void check()
        {
            foreach (T t in vehicles)
                checkUp(t);
        }
        public void enter(T t)
        {
            vehicles.Add(t);
        }

        public void leave(T t)
        {
            vehicles.Remove(t);
        }
        public static void checkTerrestrialVehicle(TerrestrialVehicle v)
        {
            v.checkAirBags();
            v.checkSeatBelts();
            v.checkTirePressure();

        }
        public static void checkBoeing(Boeing b)
        {
            b.checkFuel();
            b.checkControls();
        }

    }

    class Test
    {

      /*  static void Main()
        {
            Garage<Limousine> limoGarage = new Garage<Limousine>(Garage<Limousine>.checkTerrestrialVehicle);
            Garage<Bus> busGarage = new Garage<Bus>(Garage<Bus>.checkTerrestrialVehicle);
            Garage<Boeing>  boeingGarage= new Garage<Boeing>(Garage<Boeing>.checkBoeing);

            limoGarage.enter(new Limousine(1));
            limoGarage.enter(new Limousine(2));

            busGarage.enter(new Bus(1));
            busGarage.enter(new Bus(2));
            busGarage.enter(new Bus(3));

            boeingGarage.enter(new Boeing(1));

            limoGarage.refill();
            limoGarage.check();

            busGarage.refill();
            busGarage.check();

            boeingGarage.refill();
            boeingGarage.check();


            limoGarage.leave(new Limousine(1));

            limoGarage.refill();

            boeingGarage.leave(new Boeing(12));
            boeingGarage.refill();
        }
        */
    }

}
