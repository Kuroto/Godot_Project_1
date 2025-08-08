using Godot;
using System;

public partial class LogoMovement : Sprite2D
{
    private readonly int _speed = 200;
    private bool _isMoving = false;

    public override void _Ready()
    {
        SetProcess(false); // Start with animation stopped
        var moveButton = GetNode<Button>("../MoveButton");
        moveButton.Pressed += OnButtonPressed;
    }

    public override void _Process(double delta)
    {
        if (_isMoving)
        {
            var velocity = Vector2.Up * _speed;
            Position += velocity * (float)delta;
        }
    }

    public void OnButtonPressed()
    {
        _isMoving = !_isMoving;
        SetProcess(_isMoving); // Enable/disable process based on movement state
        GD.Print("Movement toggled: " + _isMoving);

        // Test
    }
}