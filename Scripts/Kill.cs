using Godot;
using System;

public partial class Kill : Area2D
{
    private void _on_body_entered(Node2D body)
    {
        GetTree().ReloadCurrentScene();
    }
}
