using Godot;
using System;

public partial class main : Node
{
    public override void _Ready()
    {
    }
    public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("ui_cancel")){
			GetTree().Quit();
		}
	}
}
