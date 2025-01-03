using Godot;
using System;

public partial class Score : Node
{
    public int left = 0; public int right = 0;

    public void Increase(string side)
    {
        if (side.Equals("left"))
            left++;
        else if (side.Equals("right"))
            right++;
        GetNode<Label>("left").Text = left.ToString();
        GetNode<Label>("right").Text = right.ToString();
    }
}
