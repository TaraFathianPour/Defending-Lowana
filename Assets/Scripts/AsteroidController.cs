using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float rotationSpeed;
    #endregion

    #region Privet Variables
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(-30f, 30f); // چرخش ملایم‌تر و کنترل‌شده‌تر
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.down * speed * Time.deltaTime);
        //  transform.Rotate(new Vector3 (0, 0, 0) * rotationSpeed * Time.deltaTime);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    #endregion
}
