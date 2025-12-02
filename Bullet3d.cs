using Godot;
using System;

public partial class Bullet3d : Area3D
{
	const double SPEED = 55.0D;
	const double RANGE = 40.0D;
	
	double traveled_distance = 0.0D;
	
	public override void _PhysicsProcess(double delta)
	{
		Position += -Transform.Basis.Z * (float)(SPEED * delta);
		traveled_distance += SPEED * delta;
		if (traveled_distance > RANGE) {
			QueueFree();
		}
	}
}
