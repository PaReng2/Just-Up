using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject pushButtonText;

    private void Awake()
    {
        if (pushButtonText == null)
        {
            pushButtonText = GameObject.FindGameObjectWithTag("pushButton");
        }
    }

    private void Start()
    {
        pushButtonText.SetActive(false);

    }

    void Update()
    {
        CanPushButton();
    }

    void CanPushButton()
    {
        int playerLayer = LayerMask.GetMask("Player");

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, playerLayer);

        bool hasPlayer = colliders.Length > 0;

        if(hasPlayer) 
            pushButtonText.SetActive(true);
        else pushButtonText.SetActive(false);
        
    }

    void PushButton()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
