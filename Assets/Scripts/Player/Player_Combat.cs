    using UnityEngine;

    public class Player_Combat : MonoBehaviour
    {
        //public Animator anim;
        public float cooldown = 0.5f;
        public float timer;

        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        
        private void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
        public void Attack()
        {
            if (timer <= 0)
            {
            
                //anim.SetBool("isAttacking", true);
                CheckHit();
                timer = cooldown;
            }
        }
        public void FinishAttacking()
        {
            //anim.SetBool("isAttacking", false);
        }
        private void CheckHit()
        {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

            foreach( Collider2D col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    
                    Enemy enemyScript = col.GetComponent<Enemy>();
                    if (enemyScript != null)
                    {
                        enemyScript.GotHit();
                    }
                }
            }
        }
    }
