using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static Vector3[] positions;
    int xInc, yInc, baseX, baseY;
    int invCount;
    [SerializeField]
    GameObject Crown, Letter;

	void Start ()
    {
        positions = new Vector3[30];
        xInc = 23;
        yInc = -20;
        baseX = -48;
        baseY = 31;
        SetPositions();
        invCount = 9;
        GameObject tempItem  = Instantiate(Crown, transform);
        tempItem.transform.localPosition = positions[invCount++];
        tempItem = Instantiate(Letter, transform);
        tempItem.transform.localPosition = positions[invCount++];
    }
	
	void Update ()
    {

	}

    void SetPositions()
    {
        positions[0] = new Vector3(baseX + 0 * xInc, baseY, 0);
        positions[1] = new Vector3(baseX + 1 * xInc, baseY + 0 * yInc, 0);
        positions[2] = new Vector3(baseX + 2 * xInc, baseY + 0 * yInc, 0);
        positions[3] = new Vector3(baseX + 3 * xInc, baseY + 0 * yInc, 0);
        positions[4] = new Vector3(baseX + 4 * xInc, baseY + 0 * yInc, 0);
        positions[5] = new Vector3(baseX + 0 * xInc, baseY + 1 * yInc, 0);
        positions[6] = new Vector3(baseX + 1 * xInc, baseY + 1 * yInc, 0);
        positions[7] = new Vector3(baseX + 2 * xInc, baseY + 1 * yInc, 0);
        positions[8] = new Vector3(baseX + 3 * xInc, baseY + 1 * yInc, 0);
        positions[9] = new Vector3(baseX + 4 * xInc, baseY + 1 * yInc, 0);
        positions[10] = new Vector3(baseX + 0 * xInc, baseY + 2 * yInc, 0);
        positions[11] = new Vector3(baseX + 1 * xInc, baseY + 2 * yInc, 0);
        positions[12] = new Vector3(baseX + 2 * xInc, baseY + 2 * yInc, 0);
        positions[13] = new Vector3(baseX + 3 * xInc, baseY + 2 * yInc, 0);
        positions[14] = new Vector3(baseX + 4 * xInc, baseY + 2 * yInc, 0);
        positions[15] = new Vector3(baseX + 0 * xInc, baseY + 3 * yInc, 0);
        positions[16] = new Vector3(baseX + 1 * xInc, baseY + 3 * yInc, 0);
        positions[17] = new Vector3(baseX + 2 * xInc, baseY + 3 * yInc, 0);
        positions[18] = new Vector3(baseX + 3 * xInc, baseY + 3 * yInc, 0);
        positions[19] = new Vector3(baseX + 4 * xInc, baseY + 3 * yInc, 0);
        positions[20] = new Vector3(baseX + 0 * xInc, baseY + 4 * yInc, 0);
        positions[21] = new Vector3(baseX + 1 * xInc, baseY + 4 * yInc, 0);
        positions[22] = new Vector3(baseX + 2 * xInc, baseY + 4 * yInc, 0);
        positions[23] = new Vector3(baseX + 3 * xInc, baseY + 4 * yInc, 0);
        positions[24] = new Vector3(baseX + 4 * xInc, baseY + 4 * yInc, 0);
        positions[25] = new Vector3(baseX + 0 * xInc, baseY + 5 * yInc, 0);
        positions[26] = new Vector3(baseX + 1 * xInc, baseY + 5 * yInc, 0);
        positions[27] = new Vector3(baseX + 2 * xInc, baseY + 5 * yInc, 0);
        positions[28] = new Vector3(baseX + 3 * xInc, baseY + 5 * yInc, 0);
        positions[29] = new Vector3(baseX + 4 * xInc, baseY + 5 * yInc, 0);
    }


}
