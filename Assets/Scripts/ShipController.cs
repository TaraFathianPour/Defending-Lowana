using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Transform myTransform;

    #region Public Variables
    public float speed;
    public GameObject bulletPrefab;
    public GameObject gun;
    #endregion

    #region Privete Variables
    #endregion

    #region Public Methods
    #endregion

    #region Privete Methods
    // Start is called before the first frame update
    private void Start()
    {
        myTransform = GetComponent<Transform>(); //برای دسترسی به Transform

    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        myTransform.position += new Vector3(speed * h * Time.deltaTime, speed * v * Time.deltaTime, 0);
        myTransform.position = new Vector3  //برای اینکه سفینه از صفحه بیرون نزنه
            (
                math.clamp (myTransform.position.x , -7.95f , 7.95f),
                math.clamp(myTransform.position.y, -3.95f , 3.44f ),
                myTransform.position.z
            );
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, gun.transform.position ,Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       
    }
    #endregion
}
