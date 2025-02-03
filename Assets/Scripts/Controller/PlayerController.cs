using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TerraWuler;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private RpgPlayer PrefabRpgPlayer;
  private InputManager inputManager;


  //controles 
  private IControl control;
  private Moviment moviment;
  void Start()
  {
    inputManager = GameController.Instance.GetComponentManager<InputManager>();
    var rpgplayer = Instantiate(PrefabRpgPlayer);
    var datamanager = GameController.Instance.GetComponentManager<DataManager>();
    rpgplayer.InstantiateCharacter(datamanager.GetDataCharacterByName("Warrior")?.PrefabCharacter);
    SetControl(rpgplayer);
  }
  void Update()
  {
    /*float moveHorizontal = inputManager.GetMove().x;
    float moveVertical = inputManager.GetMove().y;
    if (moviment != null)
    {
      moviment.MovementInput(moveHorizontal, moveVertical);
      if (inputManager.GetJump())
      {
        moviment.Jump();
      }
    }*/
  }
  public void SetControl(IControl control)
  {
    this.control = control;
    this.moviment = control.GetGameObject().GetComponent<Moviment>();
  }
  public Character GetCharacter()
  {
    return control.GetGameObject().GetComponent<Character>();
  }

}
