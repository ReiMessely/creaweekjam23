using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Movement Vars
    [SerializeField] private float _speed;
    private Vector2 _move;
    [SerializeField] private GameObject _mainCamera;
    private Camera _mainCameraRef;
    [SerializeField] private GameObject _capsule;
    [SerializeField] private GameObject _boomerang;
    [SerializeField] private int _nrBoomerangs;
    private int _boomerangsInUse;


    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCameraRef = _mainCamera.GetComponent<Camera>();
    }

    private void OnEnable()
    {
        Health.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        Health.OnDeath -= OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        MovePlayer();
        HandleShooting();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0f, _move.y);
        transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }

    private void LookAtMouse()
    {
        Ray cameraRay = _mainCameraRef.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 vectorToLookAt =cameraRay.GetPoint(rayLength);
            
            _capsule.transform.LookAt(new Vector3(vectorToLookAt.x,_capsule.transform.position.y,vectorToLookAt.z));
        }
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_boomerangsInUse < _nrBoomerangs)
            {
                Instantiate(_boomerang, _capsule.transform.position, _capsule.transform.rotation);
                ++_boomerangsInUse;
            }
           
        }
    }

    public void ReturnBoomerang()
    {
        --_boomerangsInUse;
    }

    void OnDeath()
    {

    }
}
