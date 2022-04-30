using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
	public PlayerOnWallState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
	{

	}

	public override void Enter()
	{
		base.Enter();
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
			player.StateMachine.ChangeState(player.DashState, 2);
		}
		else if (player.LastOnGroundTime > 0)
		{
			player.StateMachine.ChangeState(player.IdleState, 0);
		}
		else if(player.LastOnWallTime <= 0)
		{
			player.StateMachine.ChangeState(player.InAirState, 3);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
