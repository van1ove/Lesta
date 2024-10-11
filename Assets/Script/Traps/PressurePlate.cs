using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private const float OrangeToRedDelay = 1f;
    private const float RedToSourceDelay = 0.3f;

    public float damage = 10f;
    public float rechargeTime = 5f;
    private bool activated = false;

    private Material _mat;
    private void Start()
    {
        _mat = GetComponentInParent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckPlayerOnTrigger(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckPlayerOnTrigger(other);
    }

    private void CheckPlayerOnTrigger(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player) && !activated)
        {
            StartCoroutine(ActivateTrap(player));
        }
    }

    IEnumerator ActivateTrap(PlayerHealth player)
    {
        activated = true;
        Color sourceColor = _mat.color;
        _mat.color = Color.Lerp(sourceColor, Color.yellow, 1);

        yield return new WaitForSeconds(OrangeToRedDelay);

        // добавить проверку, находиться ли на нем еще игрок
        player.GetDamage(damage);

        _mat.color = Color.red;
        yield return new WaitForSeconds(RedToSourceDelay);

        _mat.color = sourceColor;
        yield return new WaitForSeconds(rechargeTime);

        activated = false;
    }
}
