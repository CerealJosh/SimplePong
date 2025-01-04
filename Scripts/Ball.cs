using Godot;
using System;
using static Godot.TextServer;

public partial class Ball : RigidBody2D
{
    [Export] public int InitialSpeed = -400;
    public int ImpulseStrength = 10;
    [Export] public int Variation = 10;
    //public float prevRotation = 0.0f;
    private Timer timer;
    private Timer startTimer;

    private float MinAngle = Mathf.DegToRad(15f); // 15 degrees
    private float MaxAngle = Mathf.Pi - Mathf.DegToRad(165f); // 165 degrees
    private bool started = false;

    Vector2 InitialPosition = new();
    private bool reset = false;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        startTimer = GetNode<Timer>("Start");
        InitialPosition = Position;
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
        var xDirection = MathF.Sign(LinearVelocity.X);
        //LinearVelocity = new Vector2(LinearVelocity.X + (xDirection *Variation), LinearVelocity.Y);
    }
    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        if (started)
        {
            LinearVelocity = LinearVelocity.Normalized() * Mathf.Abs(InitialSpeed);
            AdjustAngle();
        }
        if (reset)
        {
            LinearVelocity = Vector2.Zero;
            this.Position = InitialPosition;
            reset = false;
            Start();
        }
    }

    private void AdjustAngle()
    {
        if (Mathf.Abs(LinearVelocity.X) < 60f)
        {
            // Adjust the trajectory to ensure sufficient horizontal movement
            float signY = Mathf.Sign(LinearVelocity.Y);
            float randomAngle = (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4) * signY;
            float angle = Mathf.Asin(50f / InitialSpeed) * signY; // Calculate a valid angle

            LinearVelocity = new Vector2(LinearVelocity.X + 30 * signY, LinearVelocity.Y);
        }
    }

    public void ResetBall()
    {
        started = false;
        reset = true;
    }
}
