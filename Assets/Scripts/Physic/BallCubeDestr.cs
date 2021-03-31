using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCubeDestr : MonoBehaviour
{
    [SerializeField] GameObject smallIncject;
    [SerializeField] int hitPoint = 5;

    private void Start()
    {
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision any)
    {

        --hitPoint;

        if (hitPoint <= 0)
        {
            Vector3 today = gameObject.transform.position;

            Vector3 size = gameObject.transform.localScale;

            int quant = VolumetricFilling();

            Debug.Log($"{gameObject.name} has size {quant}");

            Destroy(gameObject);

            for(int i = 0; i < quant; i++)
            {
                Instantiate(smallIncject, RandomizeSpawn(size, today), transform.rotation);
            }

        }

    }

    private Vector3 RandomizeSpawn(Vector3 destroyObj, Vector3 where)
    {
        float randomSize;
        // Точка спавна не может находиться на границе объема или вылезать за него. 
        randomSize = destroyObj.x * 0.5f - smallIncject.transform.localScale.x * 0.5f;

        float x = where.x + Random.Range(-randomSize, randomSize);
        float y = where.y + Random.Range(-randomSize, randomSize);
        float z = where.z + Random.Range(-randomSize, randomSize);

        return new Vector3(x, y, z);
    }

    private int VolumetricFilling()
    // Любой шар в объеме будет считаться (и занимать место) как куб.
    //=> (int) (gameObject.Volume() / smallIncject.Volume(1));
    {
        if(gameObject.GetComponent<SphereCollider>())
            return (int)(gameObject.Volume() / smallIncject.Volume(1));
        else
            return (int)(gameObject.Volume(1) / smallIncject.Volume(1));
    }
    


}

public static class MainFunc
{
    public static float Volume(this GameObject those, int mode = 0)
    {
        if (mode == 0) //those.GetComponent<SphereCollider>()
        {
            return Mathf.Pow((those.transform.localScale.x / 2f), 3) * 3.14f * (4 / 3);
        }
        else //those.GetComponent<BoxCollider>()
        {
            return those.transform.localScale.x * those.transform.localScale.y * those.transform.localScale.z;
        }

    }
}
 