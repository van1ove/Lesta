using UnityEngine;
using UnityEngine.Events;

namespace Script.Player
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerHealth : MonoBehaviour
    {
        public float hp = 100;
        public UnityEvent onDead;

        public void GetDamage(float damage)
        {
            if (hp < 0)
                return;

            hp -= damage;

            if (hp <= 0)
                Die();
        
            Debug.Log(hp);
        }

        public void Die() => onDead?.Invoke();
    }
}
