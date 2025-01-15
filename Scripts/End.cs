using Godot;
using System;

public partial class End : Control
{
    public void _on_restart_pressed()
    {
        GetTree().ReloadCurrentScene();
    }
    public void _on_back_pressed()
    {
        GetTree().ChangeSceneToFile("../Scenes/Home.tscn");
    }
}
