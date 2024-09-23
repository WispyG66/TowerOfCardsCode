using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    private Dialogue dialogue;

    public void Interact()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryGetComponent(out UIManager uiManager);
          
            Debug.Log("Interact!");
  
            uiManager.OpenDialogueBox();
        } else
        {
            Debug.Log("seen");
        }
            
    }

}
