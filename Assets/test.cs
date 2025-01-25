using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public InputManager input;
    // Start is called before the first frame update
    void Start()
    {
       input =  GameController.Instance.GetComponentManager<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
