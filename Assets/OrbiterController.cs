using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterController : MonoBehaviour
{

    [SerializeField]
    private Transform _axis, _cart;
    [SerializeField]
    private float _orbitSpeed, _approachSpeed;
    [SerializeField]
    private float _nearApproach, _farApproach;

    private void Update()
    {
        Orbit();
        Approach();
    }

    private void Orbit()
    {
        float horizontalInput = 0;
        if (Input.GetAxisRaw("Horizontal") > 0)
            horizontalInput = 1;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            horizontalInput = -1;
        _axis.Rotate(Vector3.up * horizontalInput * _orbitSpeed);
    }

    private void Approach()
    {
        float verticalInput = 0;
        if (Input.GetAxisRaw("Vertical") > 0)
            verticalInput = 1;
        else if (Input.GetAxisRaw("Vertical") < 0)
            verticalInput = -1;
        _cart.Translate(Vector3.forward * verticalInput * _approachSpeed * Time.deltaTime);

        if (_cart.localPosition.z > -_nearApproach)
            _cart.localPosition = new Vector3(0, 0, -_nearApproach);
        if (_cart.localPosition.z < -_farApproach)
            _cart.localPosition = new Vector3(0, 0, -_farApproach);
    }
}
