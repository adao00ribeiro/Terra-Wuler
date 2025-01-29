using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour , IControl
{

    [SerializeField]private Animator animator;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameController.Instance.GetComponentManager<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
       animator.SetBool("IsRun", inputManager.GetMove().x != 0 || inputManager.GetMove().y != 0);
    }
}
