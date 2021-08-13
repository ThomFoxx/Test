using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProbeSwitcher : MonoBehaviour
{
    [SerializeField]
    private LightingSettings[] _lightSettings;
    private int _LPGOn = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_lightSettings.Length == 0)
            Debug.LogError("Bloody Murder");
        //else 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchLPG();
            Debug.Log("LPG " + _LPGOn + " is on");
        }

    }

    private void SwitchLPG()
    {
        _LPGOn++;
        if (_LPGOn < _lightSettings.Length)
        {
            GetComponent<Renderer>().lightmapIndex = _LPGOn;
        }
        else
        {
            _LPGOn = 0;
            GetComponent<Renderer>().lightmapIndex = _LPGOn;
        }
    }
}
