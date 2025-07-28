using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float rotationSpeed;
    public int health; //قدرت شهاب سنگ ها 
    public GameObject explosionPrefab;
    #endregion

    #region Privet Variables
    private const string ANIMATION_NAME = "health"; //پارامتری که تو انیمیشن انتخاب کردیم
    private Animator anim;
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        rotationSpeed = Random.Range(-30f, 30f); // چرخش ملایم‌تر و کنترل‌شده‌تر
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.down * speed * Time.deltaTime);
        //  transform.Rotate(new Vector3 (0, 0, 0) * rotationSpeed * Time.deltaTime);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        anim.SetInteger(ANIMATION_NAME, health);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        health = health - coll.gameObject.GetComponent<BulletController>().power;
        checkHealth();
    }
    private void checkHealth()
    {
        if (health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);           
            Destroy(gameObject);
        }
    }
    #endregion
}
