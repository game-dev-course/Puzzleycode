using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_player_map : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    public TextMesh textmesh;
    static bool first_time = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " Trigger 3D with " + other.name + " tag=" + other.tag);
    }
    // Update is called once per frame

    private IEnumerator dissapear()
    {
        //i want it to dissapear after 3 seconds and there is no need to controll it
        for (int i = 0; i <= 300; i++)
        {
            Color c = textmesh.color;
            textmesh.color = new Color(c.r, c.g, c.b, 1f *(300-i)/300);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1
        if ((xMove != 0 || zMove != 0) && first_time)
        {
            this.StartCoroutine(dissapear());
            first_time = false;
        }
        rb.velocity = new Vector3(xMove, 0, zMove) * speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 



    }


}

