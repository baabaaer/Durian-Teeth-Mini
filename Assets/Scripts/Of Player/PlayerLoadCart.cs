using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLoadCart : MonoBehaviour
{
    public DurianCartBehaviour durianCart;

    public Camera cam;
    public ScoreBoard scoreBoard;
    public float loadDistance;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreBoard == null)
        {
            scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreBoard>();
        }
        /*if (durianCart == null)
        {
            durianCart = GameObject.FindGameObjectWithTag("Durian Cart").GetComponent<DurianCartBehaviour>();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            ToCart();
        }
    }

    void ToCart()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, loadDistance))
        {
            durianCart = hit.collider.GetComponent<DurianCartBehaviour>();
            if (durianCart != null)
            {
                durianCart.LoadToCart();
            }
        }
    }

}
