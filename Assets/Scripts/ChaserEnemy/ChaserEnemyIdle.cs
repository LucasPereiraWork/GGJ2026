using UnityEngine;

public class ChaserEnemyIdle : EnemyBase
{
    public override void BeginState(ChaserEnemy enemy)
    {
        base.BeginState(enemy);
    }

    public override void UpdateState()
    {
        chaserEnemy.Rb.linearVelocity = Vector2.zero;
    }

    public override void ExitState()
    {
        if (chaserEnemy.IsDetectedPlayer) chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.CHASING);
        if (!chaserEnemy.IsDetectedPlayer) chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.RETURN);
    }

}
