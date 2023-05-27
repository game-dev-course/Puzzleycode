using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulb_manager_3d : MonoBehaviour
{

    public Transform place;
    public int length;
    public GameObject prefab_bulb;
    public GameObject blockade;
    //used to play with position
    public int steps;
    public int shift;

    public bool code_true = false;
    public int code = 0;
    bool[] number;

    public open_door doorA;
    public open_door doorB;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        number = new bool[length];

        for (int j = 0; j < length; j++)
        {
            GameObject level_p = (GameObject)Instantiate(prefab_bulb);
            Vector3 temp = new Vector3(1f, 0f, 0f) * steps * j;
            level_p.GetComponent<bulb3d>().b_m = this;
            level_p.GetComponent<bulb3d>().local_id = j;
            level_p.GetComponent<Transform>().position = place.position + temp;
            number[j] = false;
        }
    }
    public void update_bulbs_number(int index)
    {
        number[index] = !number[index];
        update_number();
    }

    void update_number()
    {
        int num = 0;
        int runner = 0;
        for (int i = length - 1; i >= 0; i--)
        {
            if (number[i])
            {
                num += (int)Math.Pow(2, runner);
            }
            runner++;
        }
        print(num);
        if (num == code)
        {
            code_true = true;
        }
        else
        {
            code_true = false;
        }

    }

    public void open_doors()
    {
        Destroy(blockade);
        doorB.change_move();
        doorA.change_move();
    }
    public void click_animate()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        //Rotate 90 deg
        animator.SetBool("pressed", true);

        //Wait for 4 seconds
        yield return new WaitForSeconds(0.3f);

        animator.SetBool("pressed", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
