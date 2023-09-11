using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private bool keyCollected = false;
    public bool KeyCollected {  
        get { return keyCollected; } 
        set {  keyCollected = value; } 
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
