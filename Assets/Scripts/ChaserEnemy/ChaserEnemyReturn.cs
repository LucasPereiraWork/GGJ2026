using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChaserEnemyReturn : EnemyBase
{
    public override void BeginState(ChaserEnemy enemy)
    {
        base.BeginState(enemy);
        chaserEnemy.BeginIdleTime(3.0f);
    }

    public override void UpdateState()
    {
        chaserEnemy.Dir = (chaserEnemy.Player.transform.position - chaserEnemy.BasePos.transform.position).normalized;
        chaserEnemy.Rb.linearVelocity = new Vector2(chaserEnemy.Dir.normalized.x * chaserEnemy.Speed, chaserEnemy.Dir.normalized.y * chaserEnemy.Speed);
    }

    public override void ExitState()
    {
        chaserEnemy.EndIdleTime();
        if (!chaserEnemy.IsDetectedPlayer) chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.IDLE);
        if (chaserEnemy.IsDetectedPlayer) chaserEnemy.ChangeState(ChaserEnemy.EnemyStates.CHASING);
    }
}
