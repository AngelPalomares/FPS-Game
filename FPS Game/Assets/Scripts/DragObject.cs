using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    /*
    private Vector3 mOffset;

    private float mZCoord;


    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePount = Input.mousePosition;

        mousePount.y = 0f;

        mousePount.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePount);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
    */

    //Rigidbody rb;
    /*
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        
        Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z + 0.01f);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mouseposition);

        transform.position = objPosition;

        rb.isKinematic = true;

    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
    */

    public Transform TheDest;
    public GameObject GunDisabled;

    private void OnMouseDown()
    {
        GunDisabled.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = TheDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    private void OnMouseUp()
    {
        GunDisabled.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true ;
    }


}
