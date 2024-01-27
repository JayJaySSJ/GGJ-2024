using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class NodeNavigationScript : MonoBehaviour
{
    public GameObject NodeNorth;
    public GameObject NodeSouth;
    public GameObject NodeWest;
    public GameObject NodeEast;
    public float LineWidth;
    public Color Color;
    public int MoveTime;

    public IDictionary<Dir, GameObject> Nodes = new Dictionary<Dir, GameObject>();

    public bool IsTransitionNode => Nodes.Count == 2;

    void Start()
    {
        InitializeConnection(NodeNorth, Dir.North);
        InitializeConnection(NodeSouth, Dir.South);
        InitializeConnection(NodeEast, Dir.East);
        InitializeConnection(NodeWest, Dir.West);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }   

    private void InitializeConnection(GameObject dst, Dir directory)
    {
        if (dst == null)
            return;
        Nodes.Add(directory, dst);

        var dstNav = dst.GetComponent<NodeNavigationScript>();
        var dstDir = directory switch
        {
            Dir.North => Dir.South,
            Dir.East => Dir.West,
            Dir.South => Dir.North,
            Dir.West => Dir.East,
        };

        if (!dstNav.Nodes.ContainsKey(dstDir))
        {
            dstNav.Nodes.Add(dstDir, gameObject);

            var line = new GameObject().AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default"));
            line.SetColors(this.Color, this.Color);
            line.startWidth = LineWidth;
            line.endWidth = LineWidth;
            line.positionCount = 2;
            line.useWorldSpace = true;

            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, dst.transform.position);
        }
    }

    public enum Dir
    {
        North = 0,
        South = 2,
        East = 1,
        West = 3,
    }
}
