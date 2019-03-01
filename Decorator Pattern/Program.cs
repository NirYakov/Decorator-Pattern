using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class Program
    {
        public static void Main()
        {
            Active();
            Console.ReadKey();
        }

        public static void Active()
        {
            // here
            Console.WriteLine("Esspresso with caramel");

            Beverage first = new AddOnCaramel(new Esspresso());

            Console.WriteLine(first);

            Console.WriteLine("LatteMachiato with vanilla");

            Beverage second = new AddOnVanilla(new LatteMachiato());

            Console.WriteLine(second);

            Console.WriteLine("LatteMachiato with caramel , vanilla and chocolate");

            Beverage third = new AddOnVanilla(new AddOnCaramel( new AddOnChocolate( new LatteMachiato())));

            Console.WriteLine(third);
        }
    }

    public abstract class Beverage
    {
        protected string m_Name = "N\a";

        public string Name { get { return m_Name; } }
        public abstract float Cost();

        public override string ToString()
        {
            return string.Format("Cost: {1:c}",m_Name , this.Cost());
        }
    }

    public class Esspresso : Beverage
    {
        public Esspresso()
        {
            m_Name = "Esspresso";
        }

        public override float Cost()
        {
            return 7.0f;
        }
    }

    public class LatteMachiato : Beverage
    {
        public LatteMachiato()
        {
            m_Name = "LatteMachiato";
        }

        public override float Cost()
        {
            return 11f;
        }
    }

    public class AddOnCaramel : Beverage
    {
        private readonly Beverage r_Beverage;

        public AddOnCaramel(Beverage i_Beverage)
        {
            m_Name = "Caramel";
            r_Beverage = i_Beverage;
        }

        public override float Cost()
        {
            return r_Beverage.Cost() + 2.5f;
        }
    }

    public class AddOnChocolate : Beverage
    {
        private readonly Beverage r_Beverage;

        public AddOnChocolate(Beverage i_Beverage)
        {
            m_Name = "Chocolate";
            r_Beverage = i_Beverage;
        }

        public override float Cost()
        {
            return r_Beverage.Cost() + 3.2f;
        }
    }

    public class AddOnVanilla : Beverage
    {
        private readonly Beverage r_Beverage;

        public AddOnVanilla(Beverage i_Beverage)
        {
            m_Name = "Vanilla";
            r_Beverage = i_Beverage;
        }

        public override float Cost()
        {
            return r_Beverage.Cost() + 2.7f;
        }
    }
}