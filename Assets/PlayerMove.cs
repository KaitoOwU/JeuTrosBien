using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] AnimatorBinding _animation;
    [SerializeField] Transform _meshTransform;
    [SerializeField] Transform _coliderTransform;

    [SerializeField] float _speed;
    [SerializeField] float _rotationspeed;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action OnEndMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    private float _currentVelocity;

    Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;

        //// Code d'exemple
        //Action a; // void Function()
        //Action<int, string> a2; // void Function(int param1, string param2)

        //Func<int> f; // int Function()
        //Func<int, string, float> f2; // float Function(int param1, string param2)
    }

    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

    /// <summary>
    /// Exemple de déclenchement d'un évènement qui active un effet, puis le desactive après un délai
    /// </summary>
    [Button("GOOO")]
    void HealthUpdate()
    {
        _onEvent.Invoke();

        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(0.8f);
            _onEventPost.Invoke();
        }
    }


    IEnumerator MoveRoutine()
    {
        // Déclenchement de l'event OnStartMove, manière "basique"
        //if (OnStartMove != null) OnStartMove.Invoke();
        // Manière plus agréable d'utilisation, totalement équivalent à la ligne au dessus.
        OnStartMove?.Invoke();

        while (true)
        {
            yield return new WaitForFixedUpdate();
            transform.Translate(new Vector3(JoystickDirection.x, 0, JoystickDirection.y) * _speed * Time.fixedDeltaTime, Space.World);


            float targertAngle = Mathf.Atan2(JoystickDirection.x, JoystickDirection.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targertAngle, ref _currentVelocity, 0.01f);

            _meshTransform.rotation = Quaternion.Euler(0, angle, 0);
            _coliderTransform.rotation = Quaternion.Euler(0, angle, 0);

            //Quaternion rotation = Quaternion.LookRotation(JoystickDirection, new Vector3(0,1,0));
            ////Quaternion correctRotation = Quaternion.Euler(0, rotation.y, 0);
            //_meshTransform.rotation = Quaternion.RotateTowards(_meshTransform.rotation, rotation, _rotationspeed * Time.deltaTime);
            ////_meshTransform.eulerAngles = new Vector3(0, _meshTransform.eulerAngles.y - _meshTransform.eulerAngles.x, 0);
        }
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        MovementRoutine = StartCoroutine(MoveRoutine());


    }

    public void WalkParticule(ParticleSystem particule)
    {
        Instantiate(particule, transform);
        Destroy(particule, 0.5f);
    }

    private void UpdateMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        Debug.Log($"Update Move : {obj.ReadValue<Vector2>()}");
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        StopCoroutine(MovementRoutine);
        JoystickDirection = Vector2.zero;
        Debug.Log($"Stop Move : {obj.ReadValue<Vector2>()}");
        OnEndMove?.Invoke();
    }




}
