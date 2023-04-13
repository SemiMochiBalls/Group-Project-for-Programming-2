using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
using System;
using System.Collections.Generic;

public static class Logger
{
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        public static void LoginHandler(object sender, EventArgs args)
        {
            LoginEventArgs loginEventArgs = args as LoginEventArgs;
            if (loginEventArgs != null)
            {
                string loginEvent = $"{loginEventArgs.Name}, {loginEventArgs.Success}, {Utils.Now}";
                loginEvents.Add(loginEvent);
            }
        }

        public static void TransactionHandler(object sender, EventArgs args)
        {
            TransactionEventArgs transactionArgs = args as TransactionEventArgs;
            if (transactionArgs == null)
            {
                return;
            }

            string transactionMessage = $"{transactionArgs.Name}: {transactionArgs.Amount} ({transactionArgs.Amount}), {(transactionArgs.Success ? "successful" : "unsuccessful")}, {Utils.Now}";
            transactionEvents.Add(transactionMessage);
        }

        public static void ShowLoginEvents()
        {
            Console.WriteLine($"Current time: {Utils.Now}");
            for (int i = 0; i < loginEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {loginEvents[i]}");
            }
        }

        public static void ShowTransactionEvents()
        {
            Console.WriteLine($"Current time: {Utils.Now}");
            for (int i = 0; i < transactionEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
            }
        }
    }

}
