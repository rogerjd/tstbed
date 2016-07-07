using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ConsoleApplication1
{
    //i don't know how to use MS DI. use NInject instead
    static class DependencyInjection
    {
        public static void Test()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IIValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            IIValueCalculator calcImpl = ninjectKernel.Get<IIValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calcImpl);
            Console.WriteLine("Total: {0:C2}", cart.CalculateStockValue());
        }

        static void SelfBinding()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            ninjectKernel.Bind<IIValueCalculator>().To<LinqValueCalculator>();
            ShoppingCart cart = ninjectKernel.Get<ShoppingCart>();
            Console.WriteLine("Total: {0:C2}", cart.CalculateStockValue());

        }
    }
}
