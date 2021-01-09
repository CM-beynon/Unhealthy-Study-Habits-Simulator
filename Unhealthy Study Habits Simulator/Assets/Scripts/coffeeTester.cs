using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeTester : AAction
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        base.incStat("hunger", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
