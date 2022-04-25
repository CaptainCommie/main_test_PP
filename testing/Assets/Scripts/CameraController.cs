using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform player;
   public Vector3 camera_offset;
   public float camera_speed;

   void FixedUpdate()
   {
      Vector3 final_position = player.position + camera_offset;
      Vector3 lerp_position = Vector3.Lerp (transform.position, final_position, camera_speed);
      transform.position = lerp_position;
   }
}