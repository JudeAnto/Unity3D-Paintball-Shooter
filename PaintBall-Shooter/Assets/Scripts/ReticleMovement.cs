using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReticleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    private int hitCount = 0;
    public GameObject impactEffect;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;



        if (Input.GetButtonDown("Shoot"))
        {
            //Debug.Log("hi");
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().health -= 10;
                    Debug.Log("Target Health = " + hit.transform.GetComponent<Enemy>().health);
                    if (hit.transform.GetComponent<Enemy>().health <= 0)
                    {
                        Destroy(hit.transform.gameObject);
                        hitCount++;
                        GameObject.Find("HitCountText").GetComponent<UnityEngine.UI.Text>().text = hitCount.ToString();
                    }
                } else
                {
                    //display paint effect
                    impactEffect.SetActive(true);

                    GameObject paintEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(paintEffect, 2f);

                }
                

                // Do something with the object that was hit by the raycast.
            }
        }
    }

    void shootTarget()
    {

    }
}
