using System;
namespace FactoryMethodExample
{
    public abstract class Creator
    {
        public abstract Candy CreateCandy (int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Candy CreateCandy(int type)
        {
            switch (type)
            {
                case 1: return new ChocolateCandy("'ChocoPaws'", 46.90, "dark", "caramel");
                case 2: return new Marmelad("'Oranges'", 44.40, "citrus");
                case 3: return new Marshmallow("'Marshmellow'", 52.20, "medium");
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Candy
    {
        public string type;
        public string name;
        public double price;  
        public Candy (string n, double p) { name = n; price = p; }
        public abstract void Info();
    } 

    //конкретні продукти з різною реалізацією
    public class ChocolateCandy : Candy 
    {
        public string chocolateType;
        public string filling;
        public ChocolateCandy(string n, double p, string c, string f): base(n, p)
        {
            this.type = "Chocolate candy";
            this.name = n;
            this.price = p;
            this.chocolateType = c;
            this.filling = f;
        }

        public override void Info() 
        {
            Console.WriteLine($"A {type} {name} with {chocolateType} chocolate and {filling}. Price: {price}");
        }

    }

    public class Marmelad : Candy 
    {
        public string taste;
        public Marmelad(string n, double p, string t) : base(n, p)
        {
            this.type = "Marmelad";
            this.name = n;
            this.price = p;
            this.taste = t;
        }

        public override void Info()
        {
            Console.WriteLine($"A {type} {name} with {taste} taste. Price: {price}");
        }

    }
    public class Marshmallow : Candy 
    {
        public string sizes;
        public Marshmallow(string n, double p, string s) : base(n, p)
        {
            this.type = "Marshmallow";
            this.name = n;
            this.price = p;
            this.sizes = s;
        }

        public override void Info()
        {
            Console.WriteLine($"A {type} {name}. Price: {price}");
        }

    }


    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var candy = creator.CreateCandy(i);
                candy.Info(); 
            }
            Console.ReadKey();
        }
    }
}
