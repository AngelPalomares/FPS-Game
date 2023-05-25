using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Transform theDest;
    public GameObject gunDisabled;
    public float rangeToTargetPlayer;

    private Rigidbody rb;
    private bool isBeingDragged = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            gunDisabled.SetActive(false);
        }
        else
        {
            gunDisabled.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            gunDisabled.SetActive(false);
            isBeingDragged = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.position = theDest.position;
            transform.parent = GameObject.Find("Destination").transform;
        }
    }

    private void OnMouseUp()
    {
        if (isBeingDragged)
        {
            isBeingDragged = false;
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.parent = null;
        }
    }
}
