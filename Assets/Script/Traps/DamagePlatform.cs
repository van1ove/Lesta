using System.Collections;
using Script.Player;
using Script.Utils;
using UnityEngine;

namespace Script.Traps
{
    public class DamagePlatform : MonoBehaviour
    {
        private const float OrangeToRedDelay = 1.5f;
        private const float RedToSourceDelay = 0.3f;

        [SerializeField] private float damage = 10f;
        [SerializeField] private float rechargeTime = 5f;
        private bool _activated;

        private Material _mat;
        private Vector3 _boxSize;
        private void Start()
        {
            _activated = false;
            _mat = GetComponent<Renderer>().material;
            _boxSize = new Vector3(transform.localScale.x, transform.localScale.y + 4f, transform.localScale.z);
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
            if (other.TryGetComponent(out PlayerHealth player) && !_activated)
            {
                StartCoroutine(ActivateTrap());
            }
        }

        IEnumerator ActivateTrap()
        {
            _activated = true;
            Color sourceColor = _mat.color;
            _mat.color = Color.yellow;

            yield return new WaitForSeconds(OrangeToRedDelay);

            Collider[] colliders = Physics.OverlapBox(transform.position + new Vector3(0, 3.2f, 0), _boxSize, 
                Quaternion.identity, 1 << LayerMaskIndexContainer.Player);
        
            _mat.color = Color.red;
            foreach (Collider col in colliders)
            {
                if(col.gameObject.TryGetComponent(out PlayerHealth pl))
                    pl.GetDamage(damage);
            }
        
            yield return new WaitForSeconds(RedToSourceDelay);

            _mat.color = sourceColor;
            yield return new WaitForSeconds(rechargeTime);

            _activated = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 3.2f, transform.position.z), 
                transform.localScale + new Vector3(0, 4, 0));
        }
    }
}
