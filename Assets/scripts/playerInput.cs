using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{

    private playerMovement _playerMovement;
    private PlayerShoot _PlayerShoot;

    float xInput;

    void Awake()
    {
        _playerMovement = GetComponent<playerMovement>();
        _PlayerShoot = GetComponent<PlayerShoot>();
    }



    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        //convert pixel coords of ouse to ray.
        // a ray is an invisible line betweet two points
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100);

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
            _playerMovement.LookAt(hit.point);

        }
        if (Input.GetMouseButton(0))
        {
            _PlayerShoot.Shoot();
        }
        // _playerMovement.LookAt(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(new Vector3(xInput, 0f, 0f));
    }
}
