using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInputController : MonoBehaviour
{
    public bool IsBlocked { get; set; }

    [Header("General")]
    private CharacterController _characterController;
    private Vector3 _direction;

    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    
    [Header("Rotation")]
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;
    private Rigidbody _rb;
    private int platLayer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        IsBlocked = false;
        _characterController = GetComponent<CharacterController>();
        _direction = new Vector3();

        platLayer = LayerMask.NameToLayer("Molot");
    }

    private void Update()
    {
        if (IsBlocked)
            return;


        RaycastHit hit;

        //Bottom of controller. Slightly above ground so it doesn't bump into slanted platforms. (Adjust to your needs)
        Vector3 p1 = transform.position + Vector3.up * 0.25f;
        //Top of controller
        Vector3 p2 = p1 + Vector3.up * _characterController.height;
        //Check around the character in a 360, 10 times (increase if more accuracy is needed)
        for (int i = 0; i < 360; i += 36)
        {
            //Check if anything with the platform layer touches this object
            if (Physics.CapsuleCast(p1, p2, 0, new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)), out hit, _characterController.radius + 0.2f, 1 << platLayer))
            {
                Debug.Log("in");
                //If the object is touched by a platform, move the object away from it
                _characterController.Move(hit.normal * (_characterController.radius + 0.1f - hit.distance));
            }
        }



        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal == 0 & moveVertical == 0)
            return;

        _direction.x = moveHorizontal;
        _direction.z = moveVertical;

        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        //transform.Translate(_direction.normalized * speed * Time.deltaTime, Space.World);
        _characterController.Move(_direction.normalized * speed * Time.deltaTime);
        
    }
}
