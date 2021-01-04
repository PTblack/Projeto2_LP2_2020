using System;
using System.ComponentModel;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Class with methods to handle exceptions, giving the appropriate
    /// error message.
    /// </summary>
    public static class ExceptionManager
    {
        /// <summary>
        /// Method that sends an error message detailing the incident that 
        /// happened.
        /// </summary>
        /// <param name="errorCodes">Variable identifying the error.</param>
        public static void ExceptionControl(ErrorCodes errorCodes)
        {
            switch (errorCodes)
            {
                case ErrorCodes.InvalidColumn:
                    Console.WriteLine("\nERROR: Requested Column Is Not Valid");

                    Console.WriteLine(
                        "The requested column is either non-existant " +
                        "or is completely full.\n");
                    break;

                default:
                    break;
            }
        }
    }
}