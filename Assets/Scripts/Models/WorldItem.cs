using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour, IInteract
{
    // Start is called before the first frame update
    void Start()
    {

    }
   private void OnMouseDown()
    {
        Character character =   GameController.Instance.PlayerController.GetCharacter();
        float distance = Vector3.Distance(character.gameObject.transform.position, this.transform.position);
        print(distance);

        if (character == null || distance > 1 ){
            return;
        }
       OnInteract(character);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void EndFocus()
    {
        throw new System.NotImplementedException();
    }

    public string GetTitle()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(Character character)
    {
        print("opa");
    }

    public void StartFocus()
    {
        throw new System.NotImplementedException();
    }
}
