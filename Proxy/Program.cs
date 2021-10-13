using System;

namespace Proxy
{
    //Cache Proxy
    abstract class CalculatorBase
    {
        public abstract int Calculator();
    }

    class CalculatorManager : CalculatorBase
    {
        public override int Calculator()
        {
            return 1 + 1;
        }
    }

    class CalculatorProxyServer : CalculatorBase
    {
        private CalculatorManager _calculatorManager;
        private int _cacheValue = 0;
        public override int Calculator()
        {
            if (_calculatorManager==null)
            {
                _calculatorManager = new CalculatorManager();
                _cacheValue = _calculatorManager.Calculator();
            }
            return _cacheValue;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            CalculatorBase calculatorBase = new CalculatorProxyServer();
            Console.WriteLine(calculatorBase.Calculator());
            Console.WriteLine(calculatorBase.Calculator());

        }
    }
}
