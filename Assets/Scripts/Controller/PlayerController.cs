using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField]  private Character character;

    private InputManager inputManager;
    private IControl  control;
    void Start(){
      inputManager = GameController.Instance.GetComponentManager<InputManager>();
      var rpgplayer =   Instantiate(character);

      SetControl(character);
    }
    void Update(){

    }
    public void SetControl(IControl control){
        this.control = control;
    }
}
