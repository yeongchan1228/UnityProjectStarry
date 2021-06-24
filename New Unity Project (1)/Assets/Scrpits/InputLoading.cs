using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLoading : MonoBehaviour
{
    public InputField inputT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InputText(Text text)
    {
        text.text = inputT.text;
    }
}
