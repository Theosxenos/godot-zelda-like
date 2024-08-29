using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public int Speed { get; set; } = 30;
	[Export] public AnimationPlayer AnimationPlayer { get; set; }
	[Export] public Sprite2D Sprite { get; set; }

	private Vector2 direction = Vector2.Zero;

	public override void _Process(double delta)
	{
		direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (direction == Vector2.Zero)
		{
			AnimationPlayer.Play("idle");
			return;
		}

		if (direction.X != 0)
		{
			Sprite.FlipH = direction.X < 0;
		}
		AnimationPlayer.Play("move_right");

		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
