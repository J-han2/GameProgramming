using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        print("Robot Start!");
    }

    // Update is called once per frame
    void Update()
    {
        print($"Speed : {speed}");
    }
}
