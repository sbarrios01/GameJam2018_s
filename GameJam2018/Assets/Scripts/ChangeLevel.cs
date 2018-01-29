using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour 
{
    public string level;
    public SpriteRenderer sprite;

     void OnMouseDown()
    {
        SceneManager.LoadScene(level);
    }

     void OnMouseEnter()
    {
        sprite.color = Color.red;
    }

     void OnMouseExit()
    {
        sprite.color = Color.white;
    }


}
