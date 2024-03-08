using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    private float _maxSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _rb.velocity.magnitude / _maxSpeed);
    }
    
    public void OnPunch()
    {
        _animator.SetTrigger("Punch");
    }
}
