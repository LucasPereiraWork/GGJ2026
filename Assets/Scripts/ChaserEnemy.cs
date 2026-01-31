using System.Collections;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Detector detector;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animatorChaser;
    [SerializeField] private GameObject basePos;

    [SerializeField] private float speed;

    private bool isDefeated;
    private Vector2 _dir;

    private bool _isDetectedPlayer = false;
    private GameObject _player = null;

    private bool _isKnockback = false;

    private EnemyBase chasingEnemyBaseState;
    private EnemyStates enemyState = EnemyStates.IDLE;
    private Coroutine _timerCoroutine;

    public Vector2 Dir => _dir;
    public bool IsDefeated => isDefeated;
    public float Speed => speed;
    public Rigidbody2D Rb => rb;
    public bool IsDetectedPlayer => _isDetectedPlayer;
    public bool IsKnockback => _isKnockback;

    public enum EnemyStates
    {
        IDLE,
        CHASING,
        KNOCKBACK,
        RETURN,
        INVISIBLE
    }

    private void Start()
    {
        //_player = GameManager.Instance.HealthPlayer.gameObject;
        ChangeState(EnemyStates.IDLE);
    }

    public void ChangeState(EnemyStates state)
    {
        switch (state)
        {
            case EnemyStates.IDLE:
                chasingEnemyBaseState = new ChaserEnemyIdle();
                break;
            case EnemyStates.CHASING:
                chasingEnemyBaseState = new ChaserEnemyChasing();
                break;
            case EnemyStates.KNOCKBACK:
                chasingEnemyBaseState = new ChaserEnemyKnockback();
                break;
            case EnemyStates.RETURN:
                chasingEnemyBaseState = new ChaserEnemyReturn();
                break;
            default:
                break;
        }
        enemyState = state;
        chasingEnemyBaseState.BeginState(this);
    }

    public void DetectedPlayer()
    {
        _isDetectedPlayer = true;
        _player = detector.Collider.gameObject;
        chasingEnemyBaseState.ExitState();
    }

    public void NotDetectedPlayer()
    {
        _isDetectedPlayer = false;
        _player = null;
        chasingEnemyBaseState.ExitState();
    }

    public void KnockBack()
    {
        _isKnockback = true;
        ChangeState(EnemyStates.KNOCKBACK);
    }

    private void FixedUpdate()
    {
        if (isDefeated) return;
        if (chasingEnemyBaseState == null) return;
        chasingEnemyBaseState.UpdateState();
    }

    private void Rotate()
    {
        //if (transform.localEulerAngles.y != 180 && _dir.x < 0)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        //else if (transform.localEulerAngles.y != 0 && _dir.x > 0)
        {
            transform.Rotate(0.0f, -180.0f, 0.0f);
        }
    }

    public void Damage()
    {
        chasingEnemyBaseState.ExitState();
        Debug.Log(enemyState);
        //if (detector.Collider.TryGetComponent(out HealthPlayerBase healthPlayer))
        //{
            //healthPlayer.TakeDamage(gameObject, true, chasingEnemySata.Damage, chasingEnemySata.KnockBack);
        //}
    }

    public void Move()
    {
        if (enemyState != EnemyStates.IDLE) return;
        _dir = (gameObject.transform.position - _player.transform.position).normalized;
    }

    private IEnumerator IdleTime(float time)
    {
        yield return new WaitForSeconds(time);
        _timerCoroutine = null;
        if (chasingEnemyBaseState != null)
        {
            chasingEnemyBaseState.ExitState();
        }
    }
    public void BeginIdleTime(float time)
    {
        EndIdleTime();
        _timerCoroutine = StartCoroutine(IdleTime(time));
    }
    public void EndIdleTime()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }
}
