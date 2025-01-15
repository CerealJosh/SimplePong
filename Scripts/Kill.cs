using Godot;
using System;

public partial class Kill : Area2D
{
    int newLeft = 0;
    int newRight = 0;
    private void _on_body_entered(Node2D body)
    {
        increaseScore();
        if (body is Ball ball)
        {
            ball.ResetBall();
        }
    }

    private void increaseScore()
    {

        if (this.Name == "Left")
        {
            var right = Owner.GetNode<Label>("Score/Right");
            newRight++;
            right.Text = newRight.ToString();
            if (newRight >= 11)
                endGame(Name);
        }
        else if (this.Name == "Right")
        {
            var left = Owner.GetNode<Label>("Score/Left");
            newLeft++;
            left.Text = newLeft.ToString();
            if(newLeft >= 11)
                endGame(Name);
        }
    }
    private void endGame(string Name)
    {
        GetTree().ReloadCurrentScene();
    }

}
