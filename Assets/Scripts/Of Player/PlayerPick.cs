using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPick : MonoBehaviour
{
    public Camera cam;
    public DurianFruitBehaviour durianBehave;
    public ScoreBoard scoreBoard;
    public Touch touch;
    
    public float pickDistance;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreBoard == null)
        {
            scoreBoard = FindObjectOfType<ScoreBoard>().GetComponent<ScoreBoard>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetMouseButtonDown(0)) || (Input.touchCount > 0  && Input.touches[0].phase == TouchPhase.Began ) )
        {
            PickingDurian();
        }
    }

    void PickingDurian()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickDistance))
        {
            durianBehave = hit.collider.GetComponent<DurianFruitBehaviour>();
            if (durianBehave != null && durianBehave.pickable == true)
            {
                durianBehave.OnDisable();
                scoreBoard.AddDurian(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pickDistance);
    }
}
