using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonController : MonoBehaviour
{
   [Header("Input fields")] 
   [SerializeField] private InputPlayerActions _inputPlayerActions;
   [SerializeField] private InputAction _move;

   [Header("movement fields")] 
   [SerializeField] private Rigidbody _rb;
   [SerializeField] private float _movementForce = 1f;
   [SerializeField] private float _jumpForce = 5f;
   [SerializeField] private float _maxSpeed = 5f;
   
   private Vector3 forceDirection = Vector3.zero;

   [Header("Camera")] 
   [SerializeField] private Camera _camera;

   [Header("Sensor")] 
   [SerializeField] private float _sensorRadius = .2f;
   [SerializeField] private float _distance = 1f;
   [SerializeField] private Color _castColor;

   private void Awake()
   {
      _rb = GetComponent<Rigidbody>();
      _inputPlayerActions ??= new();
   }

   private void OnEnable()
   {
      _inputPlayerActions.Player.Jump.started += Jump;
      _move = _inputPlayerActions.Player.Move;
      _inputPlayerActions.Player.Enable();
   }
   
   private void OnDisable()
   {
      _inputPlayerActions.Player.Jump.started -= Jump;
      _inputPlayerActions.Player.Disable();
   }

   private void FixedUpdate()
   {
      forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_camera);
      forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_camera);
      
      _rb.AddForce(forceDirection, ForceMode.Impulse);
      forceDirection = Vector3.zero;

      if (_rb.velocity.y < 0)
          _rb.velocity -= Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);

      Vector3 horizontalVelocity = _rb.velocity;
      horizontalVelocity.y = 0;
      if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
         _rb.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rb.velocity.y;
   }

   private Vector3 GetCameraForward(Camera camera1)
   {
      Vector3 forward = camera1.transform.forward;
      forward.y = 0;
      return forward;
   }

   private Vector3 GetCameraRight(Camera camera1)
   {
      Vector3 right = camera1.transform.right;
      right.y = 0;
      return right;
   }

   private void Jump(InputAction.CallbackContext obj)
   {
      if (IsGroinded())
      {
         forceDirection += Vector3.up * _jumpForce;
      }
   }

   private bool IsGroinded()
   {
      Physics.SphereCast(transform.position, _sensorRadius, transform.up * -1, out RaycastHit _hit, _distance);
      _castColor = _hit.transform != null ? Color.green : Color.red;
      return _hit.transform != null;
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = _castColor;
      Gizmos.DrawWireSphere((transform.up *-1)*_distance, _sensorRadius);
   }
}
