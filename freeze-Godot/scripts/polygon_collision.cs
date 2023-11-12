using Godot;
using System;

public partial class polygon_collision : Polygon2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var collision_shape = new CollisionPolygon2D();
		collision_shape.Polygon = Polygon;
		this.GetChild(0).AddChild(collision_shape);
		//GetNode("StaticBody2D").AddChild(collision_shape);
	}
}
