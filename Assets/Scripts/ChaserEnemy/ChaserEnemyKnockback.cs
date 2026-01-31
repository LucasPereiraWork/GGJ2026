using UnityEngine;

public class ChaserEnemyKnockback : EnemyBase
{
    public override void BeginState(ChaserEnemy enemy)
    {
        base.BeginState(enemy);
        chaserEnemy.Rb.linearVelocity = Vector2.zero;
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        chaserEnemy.ChangeState(chaserEnemy.IsDetectedPlayer ? ChaserEnemy.EnemyStates.CHASING : ChaserEnemy.EnemyStates.IDLE);
    }

}
