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



    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCameraRef = _mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        MovePlayer();
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
}
