using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._3
{
    public enum TypePizza
    {
        Peperonni,
        Cheesee,
        HunterPizza,
        Vegetariana
    }

    public class Pizza
    {
        public int Cost { get; private set; }

        public TypePizza Name { get; private set; }

        public Pizza(TypePizza typePizza)
        {
            if(typePizza == TypePizza.Cheesee)
            {
                Name = TypePizza.Cheesee;
                Cost = 300;
            }
            if(typePizza == TypePizza.HunterPizza)
            {
                Name = TypePizza.HunterPizza;
                Cost = 450;
            }
            if(typePizza == TypePizza.Peperonni)
            {
                Name = TypePizza.Peperonni;
                Cost = 400;
            }
            if(typePizza == TypePizza.Vegetariana)
            {
                Name = TypePizza.Vegetariana;
                Cost = 450;
            }
        }

        public override string ToString()
        {
            return $"Pizza: {Name}";
        }
    }
}
