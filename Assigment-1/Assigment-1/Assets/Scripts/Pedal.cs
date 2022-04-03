using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
  
    // [SerializeField] float ekranGenisligiUnitCinsinden = 16f;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        // I take mouse position like that, other way does not work properly for me

        // float farePozUnitCinsinden = Input.mousePosition.x / Screen.width * ekranGenisligiUnitCinsinden;
        float farePozUnitCinsinden = mousePosition.x;
        Vector2 pedalPozisyonu = new Vector2(Mathf.Clamp(farePozUnitCinsinden, 3.42f, 19.03f), transform.position.y);
        transform.position = pedalPozisyonu;
    }
   
}
