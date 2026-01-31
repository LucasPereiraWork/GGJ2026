using UnityEngine;

public class ChaserEnemyChasing : EnemyBase
{
    public override void BeginState(ChaserEnemy enemy)
    {
        base.BeginState(enemy);
    }

    public override void UpdateState()
    {
        chaserEnemy.Rb.linearVelocity = new Vector2(chaserEnemy.Dir.normalized.x * chaserEnemy.Speed, chaserEnemy.Dir.normalized.y * chaserEnemy.Speed);
    }

    public override void ExitState()
    {
        if (!chaserEnemy.IsDetectedPlayer) chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.IDLE);
    }
}
