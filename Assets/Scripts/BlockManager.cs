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
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - spacing, 0);
        }
        int nbSpawn = 0;
        for(int i =0;i<column;i++)
        {
            int rdm = Random.Range(0, 10);
            if(rdm<5)
            {
                nbSpawn++;
                var b = Instantiate(blockPrefab, new Vector3((spacing * i) - (width / 2) + offsetWidth,(height / 2) - offsetHeight, 0), Quaternion.identity);
                b.GetComponent<Block>().InitBlock(tour);
                blocks.Add(b);
            }
        }
        if(nbSpawn==0)
        {
            var b = Instantiate(blockPrefab, new Vector3((spacing * Random.Range(0, column)) - (width / 2) + offsetWidth, (height / 2) - offsetHeight, 0), Quaternion.identity);
            b.GetComponent<Block>().InitBlock(tour);
            blocks.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
