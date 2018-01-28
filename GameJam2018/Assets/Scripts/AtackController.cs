using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackController : MonoBehaviour {

    public GameObject[] hitsAtack1;
    public GameObject[] hitsAtack2;
    public GameObject[] hitsAtack3;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAtack(int healht)
    {
        if (healht == 3)
        {
            StartCoroutine( Atack(hitsAtack1));
        }else if (healht == 2)
        {
            StartCoroutine(Atack(hitsAtack2));
        }
        else if (healht == 1)
        {
            StartCoroutine(Atack(hitsAtack3));
        }

    }

    IEnumerator Atack(GameObject[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.3f);
        for (int e = 0; e < hits.Length; e++)
        {
            hits[e].SetActive(false);
        }
    }
}
