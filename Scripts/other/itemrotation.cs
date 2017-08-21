using UnityEngine;
using System.Collections;

public class itemrotation : MonoBehaviour
{
    public int x;
    public int y;
    public int z;


	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(x, y, z);

    }
}
