using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public StickOfHappiness cameraJoyStick;
    public Vector2 direction;
    [Range(0f,100f)] public float throwingPower;
    
    public GameObject wakid;
    public GameObject durianLaunchPoint;
    //public GameObject durianFruit;
    public GameObject durianShoot;

    //From instantiated durian fruit
    public DurianFruitBehaviour durianBehave;
    public Rigidbody durianRb;
    public DurianFruitPool durianPool;

    void Start()
    {
        durianPool = GameObject.FindGameObjectWithTag("Durian Pool").GetComponent<DurianFruitPool>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = cameraJoyStick.Horizontal();
        direction.y = cameraJoyStick.Vertical();

        //How do I make the wakid move up down with camera joystick?
        wakid.transform.rotation = Quaternion.Euler(wakid.transform.rotation.eulerAngles + new Vector3(-direction.y, 0, 0));
    }

    public void ShootTheDurian()
    {
        durianShoot = durianPool.GetDurians();
        if(durianShoot.activeSelf == false)
        {
            durianShoot.SetActive(true);
        }
        
        durianShoot.transform.position = durianLaunchPoint.transform.position;
       
        durianRb = durianShoot.GetComponent<Rigidbody>();
        durianBehave = durianShoot.GetComponent<DurianFruitBehaviour>();
        durianBehave.fallen = true;
        durianBehave.pickable = true;
        durianBehave.gameObject.transform.SetParent(null, false);

        durianRb.velocity = durianLaunchPoint.transform.forward * throwingPower;


        // Eksupulooooooosyon!
        // Destroy(Instantiate(Explosion, durianLaunchPoint.transform.position, durianLaunchPoint.transform.rotation),2);

        // The screen shaking menyaeking
        // Screenshake.ShakeAmount = 2;


    }
}
