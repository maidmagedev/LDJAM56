using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RigidbodyDebug : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = rb.velocity.ToString();
    }
}
