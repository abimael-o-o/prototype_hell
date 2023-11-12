using Godot;
using System;
using System.Diagnostics;

public partial class Camera : Camera2D
{
	bool can_FollowPlayer = false;
	CharacterBody2D player;
	Control menu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<CharacterBody2D>("../Player");
		menu = GetNode<Control>("../Menu");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if(can_FollowPlayer){
			Position.MoveToward(player.Position, .2f);
			Position = player.Position;
		}
	}

	public void _on_play_btn_pressed(){
		can_FollowPlayer = true;
		menu.QueueFree();
	}

	public void _on_change_zoom_body_entered(Node2D body){
		if(body == player){
			if(player.Velocity.X > 0.1f){
				Zoom = new Vector2(1.5f,1.5f);
			}
			else Zoom = new Vector2(1,1);
		}
	}
}
