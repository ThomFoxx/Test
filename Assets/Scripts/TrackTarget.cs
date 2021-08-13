using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private Vector3 _direction;
    

    // Start is called before the first frame update
    void Start()
    {
        if (_target == null)
            _target = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _target.transform.position-transform.position;
        //float newY = Mathf.Clamp(tracking.y, 0, 10);
        //_direction = new Vector3(tracking.x, newY, tracking.z);
        

            TrackPlayer();
    }

    void TrackPlayer()
    {
        transform.forward =_direction;
        if (transform.rotation.y > 10 || transform.rotation.y < 0)
            transform.forward = transform.parent.transform.forward;

    }
}
