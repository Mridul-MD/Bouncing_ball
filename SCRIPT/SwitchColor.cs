using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchColor : MonoBehaviour
{
    int index = 2; //Index of image. Set 2 to start looping from 1st image
   
    public Image[] images; //Array of Images. Assign images the colors you want to loop from
    
    public void ChangeColor()
    {
       
        images[index].color = Color.white; //previous image color to white

        index++; // increasing index for loop to next image

        if (index >= images.Length) // if no. is greater then length
        {
            index = 0; // setting to zero
        }

        images[index].color = Color.cyan; // changing color of index
    }
}
