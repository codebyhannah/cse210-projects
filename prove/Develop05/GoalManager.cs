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
        Menu load = new Menu(new List<string>{"Load From File", "Start New"});
        int startChoice = load.ChooseMenuOption();
        if (startChoice == 1)
        {
            Console.WriteLine("~*~ Load Goals ~*~");
            Console.WriteLine();
            Console.Write("Enter Filename: ");
            _filename = Console.ReadLine();
            Console.WriteLine();
            LoadGoals();
        }
        else if (startChoice == 2)
        {
            Console.WriteLine("~*~ Start New ~*~");
            Console.WriteLine();
            _user = new User();
        }
    }
    public GoalManager(string filename)
    {
        _filename = filename;
        LoadGoals();
    }

    // --- Methods ---
    public bool Start()
    {
        // This console clearing thing is required to fix that one issue where C# doesn't always like to clear the entire console. 
        Console.Clear(); Console.WriteLine("\x1b[3J"); Console.Clear();
        Console.WriteLine("~*~ Goal Tracker ~*~");
        Console.WriteLine();
        _user.DisplayUserInfo();
        Console.WriteLine();
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
            Console.WriteLine("~*~ Update Goal ~*~");
            Console.WriteLine();
            UpdateGoal(SelectGoal());
        }
        else if (choice == 4)
        {
            SaveGoalsList();
        }
        else if (choice == 5)
        {
            Console.WriteLine("~*~ Load Goals ~*~");
            Console.WriteLine();
            Console.Write("Enter Filename: ");
            _filename = Console.ReadLine();
            Console.WriteLine();
            LoadGoals();
        }
        else if (choice == 6)
        {
            again = false;
            string response;
            do 
            {
                Console.Write("Save Goals Before Quitting (y/n)? ");
                response = Console.ReadLine().ToLower();
            } while (response != "y" && response != "n");
            if (response == "y")
            {
                Console.WriteLine();
                SaveGoalsList();
            }
            else
            {
                Console.WriteLine();
            }
            // program end
        }
        if (again)
        {
            Console.WriteLine("Press 'enter' key to return to menu.");
            Console.ReadLine();
        }
        return again;
    }
    private void DisplayGoalsList()
    {
        Console.WriteLine("~*~ Goals ~*~");
        if (_goalsList.Count == 0)
        {
            Console.WriteLine("No goals to display. Please create a new goal.");
            Console.WriteLine();
        }
        int i = 1;
        foreach (Goal goal in _goalsList)
        {
            Console.WriteLine($"{i}. {goal.DisplayGoal()}");
            Console.WriteLine();
            i++;
        }
    }
    private void CreateGoal()
    {
        Console.WriteLine("~*~ Create Goal ~*~");
        Console.WriteLine();
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
                }while (!int.TryParse(bonusString, out int n));
                int bonus = int.Parse(bonusString);
                goal = new ChecklistGoal(title, description, points, target, bonus);
            }
            Console.WriteLine();
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
        }
        else
        {
            _user.IncreaseScore(goal.UpdateGoal());
            Console.WriteLine("Updated!");
            Console.WriteLine();
            Console.WriteLine(goal.DisplayGoal());
        }
        Console.WriteLine();
    }
    private void SaveGoalsList()
    {
        Console.WriteLine("~*~ Save Goals ~*~");
        Console.WriteLine();
        Console.Write("Enter Filename: ");
        _filename = Console.ReadLine();
        Console.WriteLine();
        Document doc = new Document(_filename);
        List<List<string>> info = new List<List<string>>{_user.GetUserInfoList()};

        foreach (Goal goal in _goalsList)
        {
            info.Add(goal.GetGoalInfoList());
        }
        doc.SetTranscript(info);
        doc.SaveFile();
        Console.WriteLine("Goals Saved!");
        Console.WriteLine();
    }
    private void LoadGoals()
    {
        Document doc = new Document(_filename);
        doc.ReadFile();
        List<List<string>> info = doc.GetContents();

        foreach (List<string> item in info)
        {
            if (item[0] == "<~USER~>")
            {
                string username = item[1];
                int progress = int.Parse(item[2]);
                int score = int.Parse(item[3]);
                int level = int.Parse(item[4]);
                int rank = int.Parse(item[5]);
                _user = new User(username, progress, score, level, rank);
            }
            else if (item[0] == "<~SIMPLEGOAL~>")
            {
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                bool complete = bool.Parse(item[4]);
                _goalsList.Add(new SimpleGoal(title, description, points, complete));
            }
            else if (item[0] == "<~ETERNALGOAL~>")
            {
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                _goalsList.Add(new EternalGoal(title, description, points));
            }
            else if (item[0] == "<~CHECKLISTGOAL~>")
            {
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                bool complete = bool.Parse(item[4]);
                int current = int.Parse(item[5]);
                int target = int.Parse(item[6]);
                int bonus = int.Parse(item[7]);
                _goalsList.Add(new ChecklistGoal(title, description, points, complete, target, bonus, current));
            }
        }
    }

}