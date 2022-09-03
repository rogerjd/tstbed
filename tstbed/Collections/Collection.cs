using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{
    /*
     * Can raise events, and do other stuff when changing underlying collection
     * 
     * RemoveItem - remvs from collection; of course the item may still be referenced 
     *              elsewhere
     * 
     */
    static class CollectionTst
    {
        static void Test()
        {

        }
    }

    class AnimalCollection: Collection<Animal>
    {

    }

    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }
    }

    class Zoo
    {
        public readonly AnimalCollection Animals = new AnimalCollection();
    }
}
