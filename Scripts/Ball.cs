using Godot;
using System;
using static Godot.TextServer;

public partial class Ball : RigidBody2D
{
    [Export] public int InitialSpeed = -500;
    public int ImpulseStrength = 10;
    //public float prevRotation = 0.0f;
    private Timer timer;
    private Timer startTimer;

    private float MinAngle = Mathf.DegToRad(15f); // 15 degrees
    private float MaxAngle = Mathf.Pi - Mathf.DegToRad(165f); // 165 degrees
    private bool started = false;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        startTimer = GetNode<Timer>("Start");
        startTimer.Timeout += Start;
        timer.Timeout += OnTimeOut;
        timer.Start();
        startTimer.Start();
    }
    public void Start()
    {
        float randomAngle = (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
        Vector2 direction = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).Normalized();
        LinearVelocity = direction * InitialSpeed;
        started = true;
    }

    private void OnTimeOut()
    {
        var angle = this.Rotation;
        var angleX = Mathf.Cos(angle);
        var angleY = Mathf.Sin(angle);
        Vector2 impulse = new Vector2(angleX, angleY) * ImpulseStrength;
        //this.ApplyCentralImpulse(impulse);
    }
    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        if (started)
        {
            LinearVelocity = LinearVelocity.Normalized() * Mathf.Abs(InitialSpeed);
            AdjustAngle();
        }
    }

    private void AdjustAngle()
    {
        if (Mathf.Abs(LinearVelocity.X) < 50f)
        {
            // Adjust the trajectory to ensure sufficient horizontal movement
            float signY = Mathf.Sign(LinearVelocity.Y);
            float randomAngle = (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4) * signY;
            float angle = Mathf.Asin(50f / InitialSpeed) * signY; // Calculate a valid angle
            //LinearVelocity = new Vector2(
            //    Mathf.Cos(randomAngle) * InitialSpeed,
            //    Mathf.Sin(randomAngle) * InitialSpeed
            //);

            GD.Print($"Adjusted to avoid near-vertical: {LinearVelocity}");
        }
    }
}
