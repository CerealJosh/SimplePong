using Godot;
using System;

public partial class Settings : Control
{
    public void _on_back_pressed()
    {
        GetTree().ChangeSceneToFile("../Scenes/Home.tscn");
    }
}
