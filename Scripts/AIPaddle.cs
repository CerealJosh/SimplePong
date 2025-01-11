using Godot;
using System;

public partial class AIPaddle : StaticBody2D
{
    [Export] public float Speed = 300.0f; // Paddle movement speed
    public Vector2 PaddleBounds = new Vector2(-76, 80); // Min and max Y bounds
    public float xPosition = 0;
    int counter = 0;
    int reactionDelay = 25;

    public override void _Ready()
    {
        xPosition = Position.X;
    }

    public override void _PhysicsProcess(double delta)
    {
        var ball = Owner.GetNode<RigidBody2D>("Ball");

        if (ball.Position.X > 1 && ball.LinearVelocity.X > 0)
        {
            float directionY = ball.Position.Y > Position.Y ? 1 : -1;
            if (Mathf.Abs(ball.Position.Y - Position.Y) > reactionDelay) // Add a threshold
            {
                Position += new Vector2(0, directionY * Speed * (float)delta);
                // Clamp the paddle within bounds
                Position = new Vector2(Mathf.Clamp(Position.X, xPosition, xPosition), Mathf.Clamp(Position.Y, PaddleBounds.X, PaddleBounds.Y));
            }
        }
    }
}