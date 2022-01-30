using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{ 
    public GameObject Start;
    public GameObject Win;

    public bool GameOn = false;

    private void Awake()
    {
        Win.SetActive(false);
        Start.SetActive(true);
    }

    public void StartGame()
    {
        Start.SetActive(false);
        GameOn = true;
    }

    public IEnumerator Game_Over()
    {
        Win.SetActive(true);
        yield return new WaitForSeconds(3);
        Win.SetActive(false);
    }

}
