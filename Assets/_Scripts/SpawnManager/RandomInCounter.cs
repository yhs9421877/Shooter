using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInCounter : MonoBehaviour
{
    public GameObject[] mobs;
    public GameObject boss;
    public float intervalTime = 3f;
    private float remainTime;
    [HideInInspector]public bool isRaid = false;
    // Start is called before the first frame update
    void Start()
    {
        remainTime = intervalTime;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isRaid)
        {
            if (remainTime <= 0)
            {
                int rand = UnityEngine.Random.Range(0, mobs.Length);
                SummonMob(mobs[rand]);
                remainTime = intervalTime;
            }
            else
            {
                remainTime -= Time.deltaTime;
            }
        }
    }

    protected virtual void SummonMob(GameObject mob)
    {
        Instantiate(mob, mob.transform.position, Quaternion.identity);
    }

    public virtual void SummonBoss()
    {
        Instantiate(boss, boss.transform.position, Quaternion.identity);
    }
}
