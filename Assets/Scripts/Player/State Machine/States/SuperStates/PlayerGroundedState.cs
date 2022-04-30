using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
	public PlayerGroundedState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
	{

	}

	public override void Enter()
	{
		base.Enter();

		player.DashState.ResetDashes(); //refresh Dashes upon touching the ground
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (player.LastPressedDashTime > 0 && player.DashState.CanDash())
		{
			player.StateMachine.ChangeState(player.DashState, 1);
		}
		else if (player.LastPressedJumpTime > 0)
		{
			player.StateMachine.ChangeState(player.JumpState, 2);
		}
		else if (player.LastOnGroundTime <= 0)
		{
			player.StateMachine.ChangeState(player.InAirState, 3);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		player.Drag(data.frictionAmount);
	}
}
