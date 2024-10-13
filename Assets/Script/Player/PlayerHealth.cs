using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Player
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        public float hp = 100;
        public UnityEvent onDead;

        public void GetDamage(float damage)
        {
            if (hp < 0)
                return;

            hp -= damage;
            UpdateUI();

            if (hp <= 0)
                Die();
        
            Debug.Log(hp);
        }

        public void Die() => onDead?.Invoke();

        public void UpdateUI() => healthBar.value = hp / 100;
    }
}
