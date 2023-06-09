﻿using mis_221_pa_5_mppatel6;

// start //
WelcomeDisp();
Trainer[] trainers = new Trainer[1000];
Listing[] listings = new Listing[1000];
Booking[] bookings = new Booking[1000];

int userChoice = GetUserChoice(); // priming read
while (userChoice != 6)
{ // condition check // pretest loop(testing before)
    RouteChoice(userChoice, trainers, listings, bookings);
    userChoice = GetUserChoice(); // update read
}
// end main 

//***METHODS***//
static int GetUserChoice()
{
    DisplayMenu();
    string userChoice = Console.ReadLine();
    if (IsValidChoice(userChoice))
    {
        return int.Parse(userChoice);
    }
    else return 0; // returning a number so int.Parse
}

static void DisplayMenu()
{ // display the menu choice
    Console.Clear();
    System.Console.WriteLine("1:  Manage Trainer Data\n2:  Manage Listing Data\n3:  Book Session\n4:  Run Reports\n5:  Build Workout\n6:  Exit");
}

static bool IsValidChoice(string userInput)
{ // checks to see if the user choice was valid to run
    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6")
    {
        return true;
    }
    return false;
}

static void RouteChoice(int userChoice, Trainer[] trainers, Listing[] listings, Booking[] bookings)
{ // routes the users choice to what they wanna do
    if (userChoice == 1)
    {
        ManageTrainer(trainers);
    }
    else if (userChoice == 2)
    {
        ManageListing(listings);
    }
    else if (userChoice == 3)
    {
        ManageCustomer(trainers, listings, bookings);
    }
    else if (userChoice == 4)
    {
        RunReports(trainers, listings, bookings);
    }
    else if (userChoice == 5)
    {
        BuildWorkout();
    }
    else if (userChoice != 6)
    {
        SayInvalid();
    }
}

static void SayInvalid()
{ // states invalid if choice enetered is able to run
    System.Console.WriteLine("Invalid");
    PauseAction();
}

static void PauseAction()
{ // pauses the console for the user to be able to see what the computer outputs
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static void ManageTrainer(Trainer[] trainers) // you can add trainers and manage and edit all the trainers from here
{
    Console.Clear();

    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();

    TrainerReport report = new TrainerReport(trainers);
    report.PrintAllTrainers();

    System.Console.WriteLine("");
    System.Console.WriteLine("1:  Add Trainer\n2:  Edit Trainer\n3:  Delete Trainer\n4:  Exit");
    string userInput = Console.ReadLine();
    while (userInput != "4")
    {

        if (userInput == "1")
        {
            utility.AddTrainer(); // add trainers
        }
        else if (userInput == "2")
        {
            utility.UpdateTrainer(); // update trainers
        }
        else if (userInput == "3")
        {
            utility.DeleteTrainer(); // delete trainers
        }
        else if (userInput != "4")
        {
            SayInvalid();
        }

        Console.Clear();
        report.PrintAllTrainers();
        System.Console.WriteLine("");
        System.Console.WriteLine("1:  Add Trainer\n2:  Edit Trainer\n3:  Delete Trainer\n4:  Exit");
        userInput = Console.ReadLine();
    }
}

static void ManageListing(Listing[] listings) // This allows you to manage all the listing the trainers make
{
    Console.Clear();

    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();

    ListingReport report = new ListingReport(listings);
    report.PrintAllListings();

    System.Console.WriteLine("");
    System.Console.WriteLine("1:  Add Listing\n2:  Edit Listing\n3:  Delete Listing\n4:  Exit");
    string userInput = Console.ReadLine();

    while (userInput != "4")
    {

        if (userInput == "1")
        {
            utility.AddListing(); // adds listing
        }
        else if (userInput == "2")
        {
            utility.UpdateListing(); // update listing
        }
        else if (userInput == "3")
        {
            utility.DeleteListing(); // delete listing
        }
        else if (userInput != "4")
        {
            SayInvalid();
        }

        Console.Clear();
        report.PrintAllListings();
        System.Console.WriteLine("");
        System.Console.WriteLine("1:  Add Listing\n2:  Edit Listing\n3:  Delete Listing\n4:  Exit");
        userInput = Console.ReadLine();
    }

}

static void ManageCustomer(Trainer[] trainers, Listing[] listings, Booking[] bookings) // you can manage all the bookings and book an open session 
{
    Console.Clear();

    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllTransactionsFromFile();

    System.Console.WriteLine("1:  Manage Customer Reports\n2:  Book Session\n3:  Exit");
    string userInput = Console.ReadLine();

    while (userInput != "3")
    {

        if (userInput == "1")
        {
            Console.Clear();
            BookingReport report = new BookingReport(bookings);
            report.PrintAllBookings();
            System.Console.WriteLine("");
            System.Console.WriteLine("1:  Edit Transaction\n2:  Delete Transaction\n3:  Exit");
            string answer = Console.ReadLine();
            while (answer != "3")
            {
                if (answer == "1")
                {
                    utility.UpdateTransaction(); // update bookings
                }
                else if (answer == "2")
                {
                    utility.DeleteTransaction(); // delete bookings
                }
                else if (answer != "3")
                {
                    SayInvalid();
                }
                Console.Clear();
                report.PrintAllBookings();
                System.Console.WriteLine("");
                System.Console.WriteLine("1:  Edit Transaction\n2:  Delete Transaction\n3:  Exit");
                answer = Console.ReadLine();
            }
        }
        else if (userInput == "2")
        {
            utility.Book(listings, trainers, bookings); // book listing
        }
        else if (userInput != "3")
        {
            SayInvalid();
        }

        Console.Clear();
        System.Console.WriteLine("1:  Manage Customer Reports\n2:  Book Session\n3:  Exit");
        userInput = Console.ReadLine();
    }
}

static void RunReports(Trainer[] trainers, Listing[] listings, Booking[] bookings) // from here you can run all your reports
{
    Console.Clear();
    System.Console.WriteLine("What kind of record would you like to see?\n1:  Individual Customer Sessions\n2:  Historical Customer Sessions\n3:  Historical Revenue Report\n4:  Exit");
    string answer = Console.ReadLine();

    BookingReport report = new BookingReport(bookings);

    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllTransactionsFromFile();

    while (answer != "4")
    {
        if (answer == "1")
        {
            Console.Clear();
            report.IndividualReport(); // Search for email and reports all their sessions

        }
        else if (answer == "2")
        {
            Console.Clear();
            report.PrintCustomerSessions(); // reports all the individuals sessions sorted by customer name then by date
            System.Console.WriteLine("");
            System.Console.WriteLine("Here is the report for all the customers sorted by name and then date.\nPlease press a key to continue.");
            Console.ReadKey();
        }
        else if (answer == "3")
        {
            Console.Clear();
            System.Console.WriteLine("1:  Combined Report\n2:  Monthly Report\n3:  Yearly Report\n4:  Exit");
            string annual = Console.ReadLine();

            while (annual != "4")
            {
                if (annual == "1")
                {
                    report.CombinedReport(listings); // monthly and yearly report
                }
                else if (annual == "2")
                {
                    report.MonthlyReport(listings); // search for month to report the total months revenue
                }
                else if (annual == "3")
                {
                    report.YearlyReport(listings); // search for year to report the total years revenue
                }
                else if (annual != "4")
                {
                    SayInvalid();
                }

                Console.Clear();
                System.Console.WriteLine("1:  Combined Report\n2:  Monthly Report\n3:  Yearly Report\n4:  Exit");
                annual = Console.ReadLine();
            }
        }
        else if (answer != "4")
        {
            SayInvalid();
        }
        Console.Clear();
        System.Console.WriteLine("1:  Individual Customer Sessions\n2:  Historical Customer Sessions\n3:  Historical Revenue Report\n4:  Exit");
        answer = Console.ReadLine();
    }
}

static void BuildWorkout() // builds workouts depending on your answer choices and muscle group you want to work out
{
    Workout[] workouts = new Workout[1000];
    Console.Clear();
    WorkoutUtility print = new WorkoutUtility(workouts);

    System.Console.WriteLine("What kind of workout would you like to do?\n1:  Intensity Based Workout\n2:  Weightlifting Based Workout\n3:  Exit");
    string answer = Console.ReadLine();

    while (answer != "3")
    {
        if (answer == "1")
        {
            Console.Clear();
            System.Console.WriteLine("Which muscle group would you like to hit?\n1:  Chest\n2:  Back\n3:  Legs\n4:  Shoulders\n5:  Arms");
            string userChoice = Console.ReadLine();
            Console.Clear();

            if (userChoice == "1")
            {
                print.ChestCompoundIntensityBuilding();
                print.ChestCompoundIntensityBuilding();
                print.ChestAccessoryIntensityBuilding();
                print.ChestAccessoryIntensityBuilding();
                print.ResetChest();

                print.ShoulderAccessoryIntensityBuilding();
                print.ResetShoulders();

                print.TricepIntensityBuilding();
                print.ResetArms();

            }
            else if (userChoice == "2")
            {
                print.BackCompoundIntensityBuilding();
                print.BackCompoundIntensityBuilding();
                print.BackAccessoryIntensityBuilding();
                print.BackAccessoryIntensityBuilding();
                print.BackAccessoryIntensityBuilding();
                print.ResetBack();

                print.BicepIntensityBuilding();
                print.ResetArms();

            }
            else if (userChoice == "3")
            {
                print.QuadCompoundIntensityBuilding();
                print.QuadAccessoryIntensityBuilding();
                print.QuadAccessoryIntensityBuilding();
                print.HamstringCompoundIntensityBuilding();
                print.HamstringAccessoryIntensityBuilding();
                print.HamstringAccessoryIntensityBuilding();

                print.ResetLegs();

            }
            else if (userChoice == "4")
            {
                print.ShoulderCompoundIntensityBuilding();
                print.ShoulderCompoundIntensityBuilding();
                print.ShoulderAccessoryIntensityBuilding();
                print.ShoulderAccessoryIntensityBuilding();
                print.ShoulderAccessoryIntensityBuilding();

                print.ResetShoulders();
            }
            else if (userChoice == "5")
            {
                print.BicepIntensityBuilding();
                print.BicepIntensityBuilding();
                print.BicepIntensityBuilding();
                print.TricepIntensityBuilding();
                print.TricepIntensityBuilding();
                print.TricepIntensityBuilding();

                print.ResetArms();
            }
            System.Console.WriteLine("Just do 3-4 sets of each workout, depending on how your muscles are feeling\nPress a key to continue");
            Console.ReadKey();
        }
        else if (answer == "2")
        {
            Console.Clear();
            System.Console.WriteLine("Which muscle group would you like to hit?\n1:  Chest\n2:  Back\n3:  Legs\n4:  Shoulders\n5:  Arms");
            string userChoice = Console.ReadLine();
            Console.Clear();

            if (userChoice == "1")
            {
                print.ChestCompoundBodyBuilding();
                print.ChestCompoundBodyBuilding();
                print.ChestAccessoryBodyBuilding();
                print.ChestAccessoryBodyBuilding();
                print.ResetChest();

                print.ShoulderAccessoryIntensityBuilding();
                print.ResetShoulders();

                print.TricepBodyBuilding();
                print.ResetArms();

            }
            else if (userChoice == "2")
            {
                print.BackCompoundBodyBuilding();
                print.BackCompoundBodyBuilding();
                print.BackAccessoryBodyBuilding();
                print.BackAccessoryBodyBuilding();
                print.ResetBack();

                print.BicepBodyBuilding();
                print.ResetArms();

            }
            else if (userChoice == "3")
            {
                print.QuadCompoundBodyBuilding();
                print.QuadAccessoryBodyBuilding();
                print.QuadAccessoryBodyBuilding();
                print.HamstringCompoundBodyBuilding();
                print.HamstringAccessoryBodyBuilding();
                print.HamstringAccessoryBodyBuilding();

                print.ResetLegs();
            }
            else if (userChoice == "4")
            {
                print.ShoulderCompoundBodyBuilding();
                print.ShoulderCompoundBodyBuilding();
                print.ShoulderAccessoryBodyBuilding();
                print.ShoulderAccessoryBodyBuilding();
                print.ShoulderAccessoryBodyBuilding();

                print.ResetShoulders();

            }
            else if (userChoice == "5")
            {
                print.BicepBodyBuilding();
                print.BicepBodyBuilding();
                print.BicepBodyBuilding();
                print.TricepBodyBuilding();
                print.TricepBodyBuilding();
                print.TricepBodyBuilding();

                print.ResetArms();

            }
            System.Console.WriteLine("Just do 3-4 sets of each workout, depending on how your muscles are feeling\nPress a key to continue");
            Console.ReadKey();
        }
        else
        {
            SayInvalid();

        }

        Console.Clear();
        System.Console.WriteLine("What kind of workout would you like to do?\n1:  Intensity Based Workout\n2:  Weightlifting Based Workout\n3:  Exit");
        answer = Console.ReadLine();
    }

}
    static void WelcomeDisp() // opening display
    {
        Console.Clear();
        bool show = true;
        do
        {
            while (!Console.KeyAvailable)
            {
                string alert = @"
                $$\      $$\                  $$$$$$\                     $$$$$\ $$\                     $$$$$$$$\ $$\   $$\                                             
                $$ | $\  $$ |                $$  __$$\                    \__$$ |\__|                    $$  _____|\__|  $$ |                                            
                $$ |$$$\ $$ | $$$$$$\        $$ /  \__| $$$$$$\              $$ |$$\ $$$$$$\$$$$\        $$ |      $$\ $$$$$$\   $$$$$$$\   $$$$$$\   $$$$$$$\  $$$$$$$\ 
                $$ $$ $$\$$ |$$  __$$\       $$ |$$$$\ $$  __$$\             $$ |$$ |$$  _$$  _$$\       $$$$$\    $$ |\_$$  _|  $$  __$$\ $$  __$$\ $$  _____|$$  _____|
                $$$$  _$$$$ |$$$$$$$$ |      $$ |\_$$ |$$ /  $$ |      $$\   $$ |$$ |$$ / $$ / $$ |      $$  __|   $$ |  $$ |    $$ |  $$ |$$$$$$$$ |\$$$$$$\  \$$$$$$\  
                $$$  / \$$$ |$$   ____|      $$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |$$ | $$ | $$ |      $$ |      $$ |  $$ |$$\ $$ |  $$ |$$   ____| \____$$\  \____$$\ 
                $$  /   \$$ |\$$$$$$$\       \$$$$$$  |\$$$$$$  |      \$$$$$$  |$$ |$$ | $$ | $$ |      $$ |      $$ |  \$$$$  |$$ |  $$ |\$$$$$$$\ $$$$$$$  |$$$$$$$  |
                \__/     \__| \_______|       \______/  \______/        \______/ \__|\__| \__| \__|      \__|      \__|   \____/ \__|  \__| \_______|\_______/ \_______/                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                Press esc to stop                                                                                                                                                                                                                                             
                ";
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = show ? ConsoleColor.Yellow: ConsoleColor.DarkMagenta; show = !show;
                Console.WriteLine(alert); Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(800);
                Console.Clear();
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape); 
            Console.Clear();
    }