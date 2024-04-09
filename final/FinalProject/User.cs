using System;

public class User : Player
{
    // --- Attributes ---
    Aesthetic _aesthetic = new Aesthetic();
    // --- Constructors ---
    public User() : base()
    {
        // Empty
    }

    // --- Getters and Setters ---

    // --- Methods ---
    public override string Play(string prompt)
    {
        _aesthetic.WriteCenterText(prompt, false);
        string response = Console.ReadLine();
        return response;
    }
}