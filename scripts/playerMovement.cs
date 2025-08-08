using Godot;
using System;

public partial class playerMovement : Sprite2D
{
    private readonly int _speed = 400;
    private readonly float _rotationSpeed = 3f;

    public override void _Process(double delta)
    {
        float rotationDirection = 0;  // -1 = left, 1 = right
        
        // Set the player character rotation to Left or Right.
        if (Input.IsActionPressed("rotate_left"))
		{
            rotationDirection = -1;
		}
        if (Input.IsActionPressed("rotate_right"))
        {
            rotationDirection = 1;
        }

        Rotation += _rotationSpeed * rotationDirection * (float)delta;  // Apply rotation to character.

        Vector2 velocity = Vector2.Zero;
        if (Input.IsActionPressed("move_forward"))
        {
            velocity = Vector2.Up.Rotated(Rotation);
        }
        if (Input.IsActionPressed("move_backward"))
        {
            velocity = Vector2.Down.Rotated(Rotation);
        }

        Position += velocity * _speed * (float)delta;
    }
}
