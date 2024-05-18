using Godot;
using System;

public partial class Killzone : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		var gameManager = GetNodeOrNull<GameManager>("/root/Game/GameManager");
		if (gameManager == null)
		{
			gameManager = GetNode<GameManager>("/root/Game_2/GameManager");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node body)
	{
		Player player = body.GetNodeOrNull<Player>($"../Player");
		Slime enemy = GetNodeOrNull<Slime>($"..");
		slime_2 enemy2 = GetNodeOrNull<slime_2>($"..");
		Node bounds = GetNodeOrNull<Node>($"..");
		var gameManager = GetNodeOrNull<GameManager>("/root/Game/GameManager");
		if (gameManager == null)
		{
			gameManager = GetNode<GameManager>("/root/Game_2/GameManager");
		}

		int pl_damage = 0;
		if (enemy == null && enemy2 != null)
		{
			pl_damage = enemy2.damage;
		}
		else if (enemy2 == null && enemy != null)
		{
			pl_damage = enemy.damage;
		}
		else if (bounds != null)
		{

			
			gameManager.lose_life(1);

			var resetTimer = GetNode<Timer>("Timer");
			resetTimer.Start();
			resetTimer.Connect("timeout", new Callable(this, nameof(OnResetTimerTimeout)));
			Engine.TimeScale = 0.5f;
	
			body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
		}
		if (player != null)
		{
			
			gameManager.lose_health(pl_damage);
		
			

			if (gameManager.health <= 0)
			{

				
				gameManager.lose_life(1);
				
				var resetTimer = GetNode<Timer>("Timer");
				resetTimer.Start();
				resetTimer.Connect("timeout", new Callable(this, nameof(OnResetTimerTimeout)));
				Engine.TimeScale = 0.5f;
		
				body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
				 // Remove the player node from the scene
			}


		}
		else
		{
			GD.Print("Error");

		}
	}

	private void OnResetTimerTimeout()
	{
		

		Engine.TimeScale = 1.0f;
		
		GetTree().ReloadCurrentScene();
	}
}
