using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpManager : MonoBehaviour
{

    public GameObject Faster;
    public GameObject Slower;
    private int _timer = 700;

    private void FixedUpdate()
    {
        if (_timer == 0)
        {
            _timer = 700;
            if (Random.Range(0, 2) == 1)
            {
                if (!Faster.activeInHierarchy)
                {
                    Vector3 pos = Vector3.zero;
                    pos.x = Random.Range(-25f, 25f);
                    pos.z = Random.Range(8f, 42f);
                    Faster.transform.position = pos;
                    Faster.SetActive(true);
                }
                else
                {
                    Vector3 pos = Vector3.zero;
                    pos.x = Random.Range(-25f, 25f);
                    pos.z = Random.Range(8f, 42f);
                    Faster.transform.position = pos;
                }
            }
            else
            {
                if (!Slower.activeInHierarchy)
                {
                    Vector3 pos = Vector3.zero;
                    pos.x = Random.Range(-25f, 25f);
                    pos.z = Random.Range(8f, 42f);
                    Slower.transform.position = pos;
                    Slower.SetActive(true);
                }
                else
                {
                    Vector3 pos = Vector3.zero;
                    pos.x = Random.Range(-25f, 25f);
                    pos.z = Random.Range(8f, 42f);
                    Slower.transform.position = pos;
                }
            }

        }

        _timer--;
    }
}
