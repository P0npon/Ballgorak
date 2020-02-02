using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    public GameObject blockPrefab;
    [SerializeField]
    private int line = 9;
    [SerializeField]
    private int column = 7;
    [SerializeField]
    private float voidSpacing = 0.1f;
    private float ratioScale;
    private float offsetHeight;
    private float offsetWidth;
    private float spacing;
    float width;
    float height;
    private List<GameObject> blocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddTourListeners(SpawnAndGoDown);
        var cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        spacing = (width) / column;

        var heightView = spacing * line;
        var deleteHeight = height - heightView;
        offsetHeight = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.y / 2 + deleteHeight / 2 + voidSpacing / 2;
        offsetWidth = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.x / 2 + voidSpacing / 2;

        ratioScale = width / ((blockPrefab.GetComponent<SpriteRenderer>().bounds.size.y+ voidSpacing) * column);
    }

    void SpawnAndGoDown(int tour)
    {
        blocks.RemoveAll(it => it == null);
        foreach(var block in blocks)
        {
            if (!block.GetComponent<Block>().Player1)
            {
                block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - spacing, 0);
            }
            else
            {
                block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y + spacing, 0);
            }
        }
        int nbSpawn = 0;
        for(int i =0;i<column;i++)
        {
            int rdm = Random.Range(0, 10);
            if(rdm<4)
            {
                nbSpawn++;
                var b = Instantiate(blockPrefab, new Vector3((spacing * i) - (width / 2) + offsetWidth,(height / 2) - offsetHeight, 0), Quaternion.identity);
                b.GetComponent<Block>().InitBlock(tour,false);
                blocks.Add(b);
                var b2 = Instantiate(blockPrefab, new Vector3((spacing * i) - (width / 2) + offsetWidth, offsetHeight - height/2, 0), Quaternion.identity);
                b2.GetComponent<Block>().InitBlock(tour, true);
                blocks.Add(b2);
            }
        }
        if(nbSpawn==0)
        {
            int rng = Random.Range(0, column);
            var b = Instantiate(blockPrefab, new Vector3((spacing * rng) - (width / 2) + offsetWidth, (height / 2) - offsetHeight, 0), Quaternion.identity);
            b.GetComponent<Block>().InitBlock(tour,false);
            blocks.Add(b);
            var b2 = Instantiate(blockPrefab, new Vector3((spacing * rng) - (width / 2) + offsetWidth, offsetHeight, 0), Quaternion.identity);
            b2.GetComponent<Block>().InitBlock(tour, true);
            blocks.Add(b);
        }
    }
}
