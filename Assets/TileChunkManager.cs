using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class TileChunkManager : MonoBehaviour {

    public Renderer render;

    void Update()
    {
        LoadAndUnload();
    }

    public void callLAU()
    {
        LoadAndUnload();
    }

	public void LoadAndUnload()
    {
        //Debug.Log(this.gameObject);
		if (this.gameObject.tag != "Manager" && render.isVisible)
        {
			this.gameObject.SetActive(true);
        }
		else if (this.gameObject.tag != "Manager" && !render.isVisible)
        {
			this.gameObject.SetActive(false);
        }
    }
}
