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
    public GameObject [] guns;
    public int Health {  get { return _health; } }
    public float fireRate = 0 ; 
    public Animator flameAnimaitor;
    #endregion

    #region Privete Variables
    [SerializeField] 
    private int _health;
    private float lastShot = 0 ;
    private const string FLAME_ANIMATION = "speed";
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
        Vector3 move = new Vector3(speed * h * Time.deltaTime, speed * v * Time.deltaTime, 0);
        myTransform.position += move;
        flameAnimaitor.SetFloat(FLAME_ANIMATION, move.sqrMagnitude);
        myTransform.position = new Vector3  //برای اینکه سفینه از صفحه بیرون نزنه
            (
                math.clamp (myTransform.position.x , -7.95f , 7.95f),
                math.clamp(myTransform.position.y, -3.95f , 3.44f ),
                myTransform.position.z
            );
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire(); //خودمون این متد و ساختیم
        }
    }

    private void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            for (int i = 0; i < guns.Length; i++)
            {
                Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
            }
            lastShot = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "bullet_enemy")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
       else if (col.gameObject.tag == "Asteroid")
        {
            _health -= col.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
       else if (col.gameObject.tag == "ship_enemy")
        {
            _health -= col.gameObject.GetComponent<EnemyShipController>().power;
            CheckHealth();
        }
    }
    private void CheckHealth()
    {
        if (_health <= 0)
        {
            // to do improve
            Destroy (gameObject);
        }
    }
    #endregion
}
