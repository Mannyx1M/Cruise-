namespace Curise_Ship;

class Program
{
    static void Main(string[] args)
    {
        CruiseManager cruiseManager = new CruiseManager();

        while (true)/// These are options to show the menu

        {
            Console.WriteLine("1. Add Cruise");
            Console.WriteLine("2. Display Cruises");
            Console.WriteLine("3. Remove Cruise");
            Console.WriteLine("4. Exit");
            Console.Write("Enter option: ");

            string option = Console.ReadLine();
            

            switch (option)
            {
                case "1":/// If you selected add cruise then  this part shows what happens  
                    Console.Write("Cruise Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Cruise port: ");
                    string port = Console.ReadLine();

                  

                    Cruise newCruise = new Cruise { Name = name, Port = port };
                    cruiseManager.AddCruise(newCruise);
                    break;

                case "2":// this is when option 2 is selected 
                    cruiseManager.DisplayCruises();
                    break;

                case "3"://This is when option 3 is clicked
                    
                    Console.Write("Cruise Name to Remove: ");
                    string cruiseToRemove = Console.ReadLine();
                    cruiseManager.RemoveCruise(cruiseToRemove);
                   
                    break;

                case "4": //tHis is when option 4 is selected
                    Environment.Exit(0);///This makes the application yo exit
                    break;



                default:
                    Console.WriteLine("ERROR, TRY AGAIN");
                    break;
            }
        }
    }
}


