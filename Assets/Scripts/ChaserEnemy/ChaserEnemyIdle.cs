using UnityEngine;

public class ChaserEnemyIdle : EnemyBase
{
    public override void BeginState(ChaserEnemy enemy)
    {
        base.BeginState(enemy);
        chaserEnemy.Move();
    }

    public override void UpdateState()
    {
        chaserEnemy.Rb.linearVelocity = Vector2.zero;
    }

    public override void ExitState()
    {
        chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.CHASING);
    }

}
