using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.RealWorld
{

    // The 'Component' abstract class
   
    abstract class FlowersShop
    {
        private int _numFlowers;

        // Property
        public int NumFlowers
        {
            get { return _numFlowers; }
            set { _numFlowers = value; }
        }

        public abstract void Display();
    }

    
    // The 'ConcreteComponent' class
 
    class Flower : FlowersShop
    {
        private string _name;
        private string _color;

        // Constructor
        public Flower(string name, string color, int numFlowers)
        {
            this._name = name;
            this._color = color;
            this.NumFlowers = numFlowers;
        }

        public override void Display()
        {
            Console.WriteLine("\nЦвете ------ ");
            Console.WriteLine(" Име: {0}", _name);
            Console.WriteLine(" Цвят: {0}", _color);
            Console.WriteLine(" Брой цветя: {0}", NumFlowers);
        }
    }

    
    // The 'ConcreteComponent' class
   
    class Boquet : FlowersShop
    {
        private string _name;
        private string _colors;
        private string _diameter;

        // Constructor
        public Boquet(string name, string colors,
          int numFlowers, string diameter)
        {
            this._name = name;
            this._colors = colors;
            this.NumFlowers = numFlowers;
            this._diameter = diameter;
        }

        public override void Display()
        {
            Console.WriteLine("\nБукет ----- ");
            Console.WriteLine(" Име: {0}", _name);
            Console.WriteLine(" Цветове: {0}", _colors);
            Console.WriteLine(" Брой цветя: {0}", NumFlowers);
            Console.WriteLine(" Диаметър: {0}\n", _diameter);
        }
    }

  
    // The 'Decorator' abstract class
  
    abstract class Decorator : FlowersShop
    {
        protected FlowersShop flowersShop;

        // Constructor
        public Decorator(FlowersShop flowersShop)
        {
            this.flowersShop = flowersShop;
        }

        public override void Display()
        {
            flowersShop.Display();
        }
    }

    // The 'ConcreteDecorator' class
    
    class Ordered : Decorator
    {
        protected List<string> ordered = new List<string>();

        // Constructor
        public Ordered(FlowersShop flowersShop)
          : base(flowersShop)
        {
        }

        public void OrderedFlowers(string name)
        {
            ordered.Add(name);
            flowersShop.NumFlowers--;
        }

        public void ReturnFlowers(string name)
        {
            ordered.Remove(name);
            flowersShop.NumFlowers++;
        }
        public override void Display()

        {

            base.Display();



            foreach (string orderer in ordered)

            {

                Console.WriteLine(" Купувач: " + orderer);

            }

        }

    }


    // Entrance into the console application.
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;


            // Create flower
            Flower flower = new Flower("Нарцис", "жълто", 5);
            flower.Display();

            // Create boquet
            Boquet boquet = new Boquet("Еуфория", "шарен", 23, "80 см.");
            boquet.Display();

            // Make boquet ordered and display
            Console.WriteLine("\nБукета е поръчан:");

            Ordered orderedboquet = new Ordered(boquet);
            orderedboquet.OrderedFlowers("Поръчано от купувач №1");

            orderedboquet.Display();

            // Wait for user
            Console.ReadKey();
        }
    }
}
