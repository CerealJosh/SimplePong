using Godot;
using System;

public partial class Paddle : StaticBody2D
{
    [Export] public float Speed = 400.0f; // Paddle movement speed
    public Vector2 PaddleBounds = new Vector2(-76, 80); // Min and max Y bounds

    public override void _Process(double delta)
    {
        // Get the input direction
        float directionY = Input.GetAxis("ui_up", "ui_down");

        // Update position manually
        if (directionY != 0)
        {
            Position += new Vector2(0, directionY * Speed * (float)delta);

            // Clamp the paddle within bounds
            Position = new Vector2(Position.X, Mathf.Clamp(Position.Y, PaddleBounds.X, PaddleBounds.Y));
        }
    }
}
