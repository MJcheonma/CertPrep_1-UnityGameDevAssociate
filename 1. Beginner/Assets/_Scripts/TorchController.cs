using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TorchController : MonoBehaviour
{

    private Light torch;

    // Start is called before the first frame update
    void Start()
    {
        torch = GetComponent<Light>();
        torch.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(torch != null)
            {
                torch.enabled = !torch.enabled;
            }
        }
    }
}
