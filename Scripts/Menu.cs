using Godot;
using System;

public partial class Menu : Control
{
    public void _on_play_pressed()
    {
        GetTree().ChangeSceneToFile("../Scenes/base.tscn");
    }
    public void _on_settings_pressed()
    {
        GetTree().ChangeSceneToFile("../Scenes/settings.tscn");
    }
    public void _on_exit_pressed()
    {
        GetTree().Quit();
    }
}
