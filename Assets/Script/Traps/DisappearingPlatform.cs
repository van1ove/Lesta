using Script.Player;
using UnityEngine;

namespace Script.Traps
{
    public class DisappearingPlatform : MonoBehaviour
    {
        [SerializeField] private float blinkDuration = 0.3f;
        [SerializeField] private float disappearDelay = 3.0f;
        [SerializeField] private Color blinkColor;
        private Color _defaultColor;

        private bool _isPlayerOnPlatform;
        private bool _isBlinking;
        private bool _isDisappearing;
    
        private float _blinkTimer;
        private float _disappearTimer;
    
        private Material _platformMaterial;
        private void Start()
        {
            _platformMaterial = GetComponent<Renderer>().material;
            _defaultColor = _platformMaterial.color;
        }

        private void Update()
        {
            if (!_isPlayerOnPlatform) 
                return;
        
            Blink();
            Disappear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInputController player))
                _isPlayerOnPlatform = true;
        }

        private void Blink()
        {
            if (!_isBlinking)
            {
                ChangeState();
            }
            else
            {
                _blinkTimer += Time.deltaTime;
                if (!(_blinkTimer >= blinkDuration)) 
                    return;
            
                _isBlinking = false;
                _isDisappearing = true;
            }
        }
    
        private void ChangeState()
        {
            _platformMaterial.color = _platformMaterial.color == _defaultColor ? blinkColor : _defaultColor;
            _isBlinking = true;
            _blinkTimer = 0.0f;
        }
    
        private void Disappear()
        {
            if (!_isDisappearing) 
                return;
        
            _disappearTimer += Time.deltaTime;
            if (_disappearTimer >= disappearDelay)
            {
                Destroy(gameObject);
            }
        }
    
    }
}