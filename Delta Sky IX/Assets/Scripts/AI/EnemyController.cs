using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeltaSky.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        private Transform target;
        
        [Header("Enemy AI Stats")]
        [SerializeField] private float chaseRadius = 5f;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float distance;
        [SerializeField] private float moveSpeed;

        [Header("Enemy Damage Stats")] 
        public float damage;
        [SerializeField] private float attackRadius = 2f;
        
        // Start is called before the first frame update
        void Start()
        {
            transform.position = Vector3.zero;
            target = Temp.temp.player.transform;
        }

        // Update is called once per frame
        void Update()
        {
            ChasePlayer();
        }

        public void ChasePlayer()
        {
            distance = Vector3.Distance(transform.position, target.position);

            moveSpeed = speed * Time.deltaTime;
            
            if (distance <= chaseRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
            }

            if (distance <= attackRadius)
            {
                DamagePlayer(5f);
            }
        }

        public void DamagePlayer(float _damagePoints)
        {
            damage -= _damagePoints;
            
            if (distance <= attackRadius)
            {
                Temp.temp.health -= _damagePoints;
            }
        }

        /// <summary>
        /// Visible chase radius for testing
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}
