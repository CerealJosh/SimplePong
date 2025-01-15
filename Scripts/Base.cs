using Godot;
using System;
using System.Collections.Generic;

public partial class Base : Node2D
{
    private string endMessage = "You Lose!";
    private bool gameEnded = false;
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (!gameEnded)
        {
            checkScore();
        }
    }
    private void checkScore()
    {
        try
        {
            var rightScore = int.Parse(GetNode<Label>("Score/Right").Text);
            var leftScore = int.Parse(GetNode<Label>("Score/Left").Text);

            if (leftScore >= 11)
                displayEnd("You Win!");

            else if (rightScore >= 11)
                displayEnd("You Lose!");
        }
        catch (Exception ex)
        {
            GD.PrintErr(ex);
        }
    }
    private void displayEnd(string message)
    {
        GetNode<RigidBody2D>("Ball").QueueFree();
        GetNode<Control>("End").Show();
        endMessage = message;
        GetNode<Label>("End/Box/List/Label").Text = endMessage;
        gameEnded = true;
    }
}
