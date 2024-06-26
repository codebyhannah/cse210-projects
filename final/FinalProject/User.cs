using System;

public class User : Player
{
    // --- Attributes ---
    private Aesthetic _aesthetic = new Aesthetic();
    // --- Constructors ---
    public User() : base()
    {
        // Empty
    }

    // --- Methods ---
    public override string Play(string prompt)
    {
        _aesthetic.WriteCenterText(prompt, false);
        string response = Console.ReadLine();
        return response;
    }
}