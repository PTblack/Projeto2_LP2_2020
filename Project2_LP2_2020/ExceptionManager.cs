using System;

namespace Project2_LP2_2020
{
    public static class ExceptionManager
    {
        public static void ExceptionControl(ErrorCodes errorCodes)
        {
            switch(errorCodes)
            {
                case ErrorCodes.InvalidColumn:
                    Console.WriteLine("\nERROR: Requested Column Is Not Valid");
                    
                    Console.WriteLine(
                        "The requested column is either out of range of the " + 
                        "board or is completely full\n");
                    break;
            }
        }
    }
}