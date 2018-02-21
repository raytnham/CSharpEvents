using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    class Program
    {
        // Define a event handler.
        public delegate void BalanceEventHandler(decimal newValue);

        class PiggyBank
        {
            private decimal bankBalance;
            // Delare an event.
            public event BalanceEventHandler balanceChanged;

            public decimal bankBlance
            {
                set
                {
                    bankBalance = value;
                    // The event will be trigger whenver m_bankBalance is being changed.
                    balanceChanged(value);
                }
                get
                {
                    return bankBalance;
                }
            }
        }

        // Event implementation: to log the amount being set to the PiggyBank class.
        class BalanceLogger
        {
            public void balanceLog(decimal amount)
            {
                Console.WriteLine("The balance amount is {0}", amount);
            }
        }

        static void Main(string[] args)
        {
            // Initiate the PiggyBank and BalanceLogger classes.
            PiggyBank bank = new PiggyBank();
            BalanceLogger logger = new BalanceLogger();
            // Bind the implemation of blanceLog method to the event balanceChanged.
            bank.balanceChanged += logger.balanceLog;
            // Try to set the value of bankBalance to 1000.
            bank.bankBlance = 1000;
        }
    }
}
