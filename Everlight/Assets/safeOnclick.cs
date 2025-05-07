using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeOnclick : MonoBehaviour
{   [SerializeField]
    private GameObject codePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnMouseDown()
  {
    if (!movement_script.isSafeOpened){
        codePanel.SetActive(true);
        Debug.Log("click");
    }
            
  }
}
