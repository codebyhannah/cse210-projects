using System;

public class User : Player
{
    // --- Attributes ---

    // --- Constructors ---
    public User() : base()
    {
        // Empty
    }

    // --- Getters and Setters ---

    // --- Methods ---
    public string Play(string prompt)
    {
        Console.Write(prompt);
        string response = Console.ReadLine();
        return response;
    }
}