using System;

public class GoalManager
{
    // --- Attributes ---
    private List<Goal> _goalsList = new List<Goal>();
    private string _filename;
    private User _user;

    // --- Constructors ---
    public GoalManager()
    {
        _user = new User();
    }
    public GoalManager(string filename)
    {
        _filename = filename;
        LoadGoals();
    }

    // --- Methods ---
    public bool Start()
    {
        bool again = true;
        List<string> options = new List<string>{"Display Goals", "Create New Goal", "Update Goal", "Save Goals", "Load Goals", "Quit"};
        Menu menu = new Menu(options);
        int choice = menu.ChooseMenuOption();
        if (choice == 1)
        {

            DisplayGoalsList();
        }
        else if (choice == 2)
        {
            CreateGoal();
        }
        else if (choice == 3)
        {
            UpdateGoal(SelectGoal());
        }
        else if (choice == 4)
        {
            SaveGoalsList();
        }
        else if (choice == 5)
        {
            LoadGoals();
        }
        else if (choice == 6)
        {
            again = false;
            // program end
        }
        return again;
    }
    private void DisplayUserInfo()
    {

    }
    private void DisplayGoalsList()
    {
        int i = 1;
        foreach (Goal goal in _goalsList)
        {
            Console.WriteLine("~*~ Goals ~*~");
            Console.WriteLine($"{i}. {goal.DisplayGoal()}");
            Console.WriteLine();
            i++;
        }
    }
    private void CreateGoal()
    {
        Console.WriteLine("What type of goal do you want to create?");
        Console.WriteLine();

        List<string> goalTypes = new List<string>{"Simple Goal", "Eternal Goal", "Checklist Goal", "Quit to Main Menu"};
        Menu goalMenu = new Menu(goalTypes);
        int choice = goalMenu.ChooseMenuOption("Goal Types");

        if (choice == 4)
        {
            // do nothing and return to main menu
        }
        else
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            string pointsString = "0";
            do
            {
                if (!int.TryParse(pointsString, out int j))
                {
                    Console.Write("Points (integers only): ");
                }
                else
                {
                    Console.Write("Points: ");
                }
                pointsString = Console.ReadLine();
                Console.WriteLine();
            }while (!int.TryParse(pointsString, out int n));
            int points = int.Parse(pointsString);

            Goal goal = new Goal("a","a",1);

            if (choice == 1)
            {
                goal = new SimpleGoal(title, description, points);
            }
            else if (choice == 2)
            {
                goal = new EternalGoal(title, description, points);
            }
            else if (choice == 3)
            {
                string targetString = "0";
                do
                {
                    if (!int.TryParse(targetString, out int j))
                    {
                        Console.Write("Amount of times to complete the goal (integers only): ");
                    }
                    else
                    {
                        Console.Write("Amount of times to complete the goal: ");
                    }
                    targetString = Console.ReadLine();
                    Console.WriteLine();
                }while (!int.TryParse(targetString, out int n));
                int target = int.Parse(targetString);

                string bonusString = "0";
                do
                {
                    if (!int.TryParse(bonusString, out int j))
                    {
                        Console.Write("Bonus points for full completion (integers only): ");
                    }
                    else
                    {
                        Console.Write("Bonus points for full completion: ");
                    }
                    bonusString = Console.ReadLine();
                    Console.WriteLine();
                }while (!int.TryParse(bonusString, out int n));
                int bonus = int.Parse(bonusString);

                goal = new ChecklistGoal(title, description, points, target, bonus);
            }
            _goalsList.Add(goal);
            Console.WriteLine(goal.DisplayGoal());
            Console.WriteLine();
        }
    }
    private Goal SelectGoal()
    {
        List<string> goalStrings = new List<string>();
        foreach (Goal goal in _goalsList)
        {
            goalStrings.Add(goal.DisplayGoal());
        }
        Menu goals = new Menu(goalStrings);

        Console.WriteLine("Which goal would you like to update?");
        Console.WriteLine();
        int chosenIndex = goals.ChooseMenuOption("Goals") - 1;
        
        Goal selection = _goalsList[chosenIndex];
        return selection;
    }
    private void UpdateGoal(Goal goal)
    {
        if (goal.IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
            Console.WriteLine();
        }
        else
        {
            _user.IncreaseScore(goal.UpdateGoal());
        }
    }
    private void SaveGoalsList()
    {

    }
    private void LoadGoals()
    {

    }

}