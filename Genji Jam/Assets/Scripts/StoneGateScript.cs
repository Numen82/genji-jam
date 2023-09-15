using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGateScript : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate;
    private PressurePlateScript plateComponent;
    private Vector3 grounddepth;
    private Vector3 ceilingdepth;

    // Start is called before the first frame update
    void Start()
    {
        plateComponent = pressurePlate.GetComponent<PressurePlateScript>();
        grounddepth = new Vector3(0.0f, 0.4585f, 0.0f);
        ceilingdepth = new Vector3(0.0f, 4.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
     if (plateComponent.raiseGate == 1 && transform.position.y < ceilingdepth.y)
        {
            Moveup();
        }
     if (plateComponent.raiseGate == 2 && transform.position.y > grounddepth.y)
        {
            Movedown();
        }
    }
    
    void Moveup()
    {
        transform.Translate(0, 0.1F, 0);
    }
    void Movedown()
    {
        transform.Translate(0, -0.15f, 0);
    }
}
