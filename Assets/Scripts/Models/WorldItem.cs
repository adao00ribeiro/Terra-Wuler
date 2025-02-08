using System.Collections;
using System.Collections.Generic;
using TerraWuler;
using UnityEngine;

public class WorldItem : MonoBehaviour, IInteract
{

    [SerializeField] private DataItem dataItem;

    [SerializeField] private int dropQuantity;

    [SerializeField] private Material Outiline;
    // Start is called before the first frame update
    void Start()
    {

        Outiline = Resources.Load<Material>("MatOutiline");
    }
    private void OnMouseEnter()
    {
        StartFocus();
    }
    private void OnMouseExit()
    {
        EndFocus();
    }
    private void OnMouseDown()
    {
        RpgPlayer rpgPlayer = GameController.Instance.PlayerController.GetCharacter();
        float distance = Vector3.Distance(rpgPlayer.gameObject.transform.position, this.transform.position);

        if (rpgPlayer == null || distance > 1)
        {
            return;
        }
        OnInteract(rpgPlayer.GetComponent<Inventory>());
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void EndFocus()
    {
         foreach (Transform item in transform)
            {
                MeshRenderer renderer = item.GetComponent<MeshRenderer>();
                Material[] materials = renderer.materials;

                // Adicionar o novo material à lista
                // Por exemplo, se 'newMaterial' é o material que você deseja adicionar:
                Material[] newMaterials = new Material[materials.Length - 1];
                for (int i = 0; i < materials.Length - 1; i++)
                {
                    newMaterials[i] = materials[i];
                }
                // Atribuir a nova lista de materiais de volta ao MeshRenderer
                renderer.materials = newMaterials;
            }
    }

    public string GetTitle()
    {
        return dataItem.Name;
    }

    public void OnInteract(Inventory inventory)
    {

        Slot slot = new Slot();
        slot.Name = dataItem.Name;
        slot.GuidId = dataItem.GuidId;
        slot.Quantity = dropQuantity;
        Vector3 point = transform.position;
        if (inventory.AddItem(slot))
        {
            //  DataAudio audioPickup = GameController.Instance.DataManager.GetDataAudio("Pickup");
            //   GameController.Instance.SoundManager.PlayOneShot(transform.position, audioPickup.Audio);
            // GameController.Instance.SpawObjectsManager.SpawTimeObject();
            Destroy(this.gameObject);
        }
    }

    public void StartFocus()
    {
            foreach (Transform item in transform)
            {
                MeshRenderer renderer = item.GetComponent<MeshRenderer>();
                Material[] materials = renderer.materials;

                // Adicionar o novo material à lista
                // Por exemplo, se 'newMaterial' é o material que você deseja adicionar:
                Material[] newMaterials = new Material[materials.Length + 1];
                materials.CopyTo(newMaterials, 0);
                newMaterials[materials.Length] = Outiline;

                // Atribuir a nova lista de materiais de volta ao MeshRenderer
                renderer.materials = newMaterials;
            }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("noCollider"))
        {
            StartFocus();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("noCollider"))
        {
            EndFocus();
        }
    }

}
