using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    // private Vector3 offset = new Vector3(0, 3.63f, -7.5f);
    private Vector3 _pos;

    private void Start()
    {
        // Задаем локальную позицию для камеры относительно игрока
        _pos = player.transform.InverseTransformPoint(transform.position);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // Каждый кадр устанавливаем из локальной позици глобальную позицию камеры
        transform.position = player.transform.TransformPoint(_pos);
        // Кадый кадр вращаем камеру за игроком 
        transform.LookAt(player.transform);

        //transform.position = player.transform.position + offset;
   
    }
}
