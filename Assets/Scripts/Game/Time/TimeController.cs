using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    float _currentTimeScale = 1.0f;

    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTimeScale != Time.timeScale)
        {
            Time.timeScale = _currentTimeScale;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }
}
