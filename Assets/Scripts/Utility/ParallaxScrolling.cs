using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    #region Public Variables
    public Vector2 speed;
    #endregion

    #region Privet Variables
    private Renderer myRender;
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    private void Awake()
    {
        myRender = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        myRender.material.mainTextureOffset = Time.time * speed;
    }
    #endregion
}
