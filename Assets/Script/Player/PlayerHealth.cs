using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerHealth : MonoBehaviour
{
    public float hp = 100;

    public void GetDamage(float damage)
    {
        if (hp < 0)
            return;

        hp -= damage;

        if (hp <= 0)
            GetComponent<PlayerInputController>().IsBlocked = true;
        
        Debug.Log(hp);
    }
}
