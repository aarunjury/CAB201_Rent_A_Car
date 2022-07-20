using System;
using System.IO;
using MRRCManagement;
using static System.Console;

namespace MRRC
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //If there are less than 3 commandline arguments provided
                //for the filepaths, a warning will be displayed in red to let the user know the default files
                //from the Data folder have been loaded
                if (!(args.Length == 3))
                {
                    throw new FileHandlingException("Insufficient filepaths were provided via command line arguments. The default file paths will be loaded.\n\n");
                }
                CRM.CRMFile = args[0];
                Fleet.FleetFile = args[1];
                Fleet.RentalFile = args[2];
                MRRCSystem.DisplayMainMenu();
            }
            //Only catch a FileHandlingException here as, if another type of Exception occurs and we have used a generic Exception catch here,
            //the program will load the default files when catching any Exception. We only want this to occur when catching the above custom
            //FileHandlingException
            catch (FileHandlingException e)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(e.Message);
                ResetColor();
                CRM.CRMFile = @"../../../Data/customers.csv";
                Fleet.FleetFile = @"../../../Data/fleet.csv";
                Fleet.RentalFile = @"../../../Data/rentals.csv";
                MRRCSystem.DisplayMainMenu();
            }
            //Here we also want to catch IOExceptions such as FileNotFound or FileLoadException (typically
            //occurs when the file is in use by another program)
            catch (IOException ioException)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(ioException.Message);
                ResetColor();
                CRM.CRMFile = @"../../../Data/customers.csv";
                Fleet.FleetFile = @"../../../Data/fleet.csv";
                Fleet.RentalFile = @"../../../Data/rentals.csv";
                MRRCSystem.DisplayMainMenu();
            }
        }
    }
}
