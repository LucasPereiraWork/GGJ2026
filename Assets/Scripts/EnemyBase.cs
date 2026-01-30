using UnityEngine;

public class EnemyBase
{
    protected ChaserEnemy chaserEnemy;
    public virtual void BeginState(ChaserEnemy enemy)
    {
        chaserEnemy = enemy;
    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {
        chaserEnemy = null;
    }
}
