using mis_221_pa_5_mppatel6;

// start //

int userChoice = GetUserChoice(); // priming read
while (userChoice != 5){ // condition check // pretest loop(testing before)
    RouteChoice(userChoice);
    userChoice = GetUserChoice(); // update read
}
// end main 

//***METHODS***//
static int GetUserChoice(){
    DisplayMenu();
    string userChoice = Console.ReadLine();
    if (IsValidChoice(userChoice)){
        return int.Parse(userChoice);
    }
    else return 0; // returning a number so int.Parse
}

static void DisplayMenu(){ // display the menu choice
    Console.Clear();
    System.Console.WriteLine("1:  Manage Trainer Data\n2:  Manage Listing Data\n3:  Book Session\n4:  Run Reports\n5:  Exit");
}

static bool IsValidChoice(string userInput){ // checks to see if the user choice was valid to run
    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5"){
        return true;
    }
    return false;
}

static void RouteChoice(int userChoice){ // routes the users choice to what they wanna do
    if(userChoice == 1){
        ManageTrainer();
    }
    else if(userChoice == 2){
        ManageListing();
    }
    else if(userChoice == 3){
        ManageCustomer();
    }
    else if(userChoice == 4){
        RunReports();
    }
    else if(userChoice != 5){
        SayInvalid();
    }
}

static void SayInvalid(){ // states invalid if choice enetered is able to run
    System.Console.WriteLine("Invalid");
    PauseAction();
}

static void PauseAction(){ // pauses the console for the user to be able to see what the computer outputs
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static void ManageTrainer(){
    Console.Clear();
    Trainer[] trainers = new Trainer[50];


    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();

    TrainerReport report = new TrainerReport(trainers);
    report.PrintAllTrainers();

    System.Console.WriteLine("");
    System.Console.WriteLine("1:  Add Trainer\n2:  Edit Trainer\n3:  Delete Trainer\n4:  Exit");
    string userInput = Console.ReadLine();
    while(userInput != "4"){

        if(userInput == "1"){
            utility.AddTrainer();
        }
        else if(userInput == "2"){
            utility.UpdateTrainer();
        }
        else if(userInput == "3"){
            utility.DeleteTrainer();
        }
        else if(userInput != "4"){
            SayInvalid();
        }

        Console.Clear();
        report.PrintAllTrainers();
        System.Console.WriteLine("");
        System.Console.WriteLine("1:  Add Trainer\n2:  Edit Trainer\n3:  Delete Trainer\n4:  Exit");
        userInput = Console.ReadLine();
    }
}

static void ManageListing(){
    Console.Clear();
    Listing[] listings = new Listing[50];

    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();

    ListingReport report = new ListingReport(listings);
    report.PrintAllListings();

    System.Console.WriteLine("");
    System.Console.WriteLine("1:  Add Listing\n2:  Edit Listing\n3:  Delete Listing\n4:  Exit");
    string userInput = Console.ReadLine();

    while(userInput != "4"){

        if(userInput == "1"){
            utility.AddListing();
        }
        else if(userInput == "2"){
            utility.UpdateListing();
        }
        else if(userInput == "3"){
            utility.DeleteListing();
        }
        else if(userInput != "4"){
            SayInvalid();
        }

        Console.Clear();
        report.PrintAllListings();
        System.Console.WriteLine("");
        System.Console.WriteLine("1:  Add Listing\n2:  Edit Listing\n3:  Delete Listing\n4:  Exit");
        userInput = Console.ReadLine();
    }
    
}

static void ManageCustomer(){
    Console.Clear();
    Booking[] bookings = new Booking[50];

    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllTransactionsFromFile();

    utility.Book();

    // BookingReport report = new BookingReport(bookings);
    // report.PrintAllBookings();

    // System.Console.WriteLine("");
    // System.Console.WriteLine("1:  Add Transaction\n2:  Edit Transaction\n3:  Delete Transaction\n4:  Exit");
    // string userInput = Console.ReadLine();

    // while(userInput != "4"){

    //     if(userInput == "1"){
    //         utility.AddTransaction();
    //     }
    //     else if(userInput == "2"){
    //         utility.UpdateTransaction();
    //     }
    //     else if(userInput == "3"){
    //         utility.DeleteTransaction();
    //     }
    //     else if(userInput != "4"){
    //         SayInvalid();
    //     }

    //     Console.Clear();
    //     report.PrintAllBookings();
    //     System.Console.WriteLine("");
    //     System.Console.WriteLine("1:  Add Transaction\n2:  Edit Transaction\n3:  Delete Transaction\n4:  Exit");
    //     userInput = Console.ReadLine();
    // }
}

static void RunReports(){
    Console.Clear();
    System.Console.WriteLine("What kind of record would you like to see?\n1:  Individual Customer Sessions\n2:  Historical Customer Sessions\n3:  Historical Revenue Report");
    string answer = Console.ReadLine();

}

static void BuildWorkout(){
    System.Console.WriteLine("What kind of workout would you like to do?\n1:  Intensisty Based Workout\n2:  Weightlifting Based Workout");
    string answer = Console.ReadLine();

    if(answer == "1"){

    }
    else if(answer == "2"){

    }
    else{
        SayInvalid();
    }
}