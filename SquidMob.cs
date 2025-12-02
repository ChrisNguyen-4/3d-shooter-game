using Godot;
using System;

public partial class SquidMob : Mob
{
	// You can override Min/MaxSpeed for squids
	[Export]
	public int ExtraSquidSpeed { get; set; } = 5;

	public override void _Ready()
	{
		// Maybe squids get faster than normal mobs
		MinSpeed += ExtraSquidSpeed;
		MaxSpeed += ExtraSquidSpeed;
	}
	
	private void OnVisibilityNotifierScreenExited()
		{
			QueueFree();
		}
}
