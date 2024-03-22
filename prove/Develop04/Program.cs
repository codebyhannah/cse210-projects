using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        do
        {
            // This console clearing thing is required to fix that one issue where C# doesn't always like to clear the entire console. 
            Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
            Console.WriteLine("~*~ Mindfulness Activities ~*~");
            Console.WriteLine();
            List<string> menuOptions = new List<string>{"Breathing Activity", "Reflection Activity", "Listing Activity", "Quit"};
            Menu menu = new Menu(menuOptions);
            int choice = menu.ChooseMenuOption();

            if (choice == 1)
            {
                BreathingActivity breathe = new BreathingActivity();
                breathe.Start();
                breathe.Run();
                breathe.End();
            }
            else if (choice == 2)
            {
                ReflectionActivity reflect = new ReflectionActivity();
                reflect.Start();
                reflect.Run();
                reflect.End();
            }
            else if (choice == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Start();
                listing.Run();
                listing.End();
            }
            else if (choice == 4)
            {
                quit = true;
            }
        } while (quit == false);
    }
}