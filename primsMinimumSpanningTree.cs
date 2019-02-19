using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

public class Edge 
{
    public Node To { get; set; }

    public int Weight { get; set; }

    public Edge(Node to, int weight) 
    {
        To = to;
        Weight = weight;
    }
}

public class Node 
{
    public int Id { get; set; }

    public List<Edge> Edges { get; set; }

    public Node(int id) 
    {
        Id = id;
        Edges = new List<Edge>();
    }
}

class Result
{
    public static Dictionary<int, Node> BuildTree(List<int> gFrom, List<int> gTo, List<int> gWeight) 
    {
        var d = new Dictionary<int, Node>();

        for (int i = 0; i < gFrom.Count; i++) 
        {
            Node fromNode;
            Node toNode;    

            if (!d.ContainsKey(gFrom[i])) 
            {
                fromNode = new Node(gFrom[i]);
                d.Add(gFrom[i], fromNode);
            }
            
            if (!d.ContainsKey(gTo[i])) 
            {
                toNode = new Node(gTo[i]);
                d.Add(gTo[i], toNode);
            }

            fromNode = d[gFrom[i]];
            toNode = d[gTo[i]];

            fromNode.Edges.Add(new Edge(toNode, gWeight[i]));
            toNode.Edges.Add(new Edge(fromNode, gWeight[i]));
        }

        return d;
    }

    public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
    {
        var tree = BuildTree(gFrom, gTo, gWeight);
      
        return primsTree(tree[gFrom[0]], gNodes);
    }

    static int primsTree(Node node, int totalNodes) {
        var usedNodes = new HashSet<int>();
        var edges = new List<Edge>(node.Edges);
        var sum = 0;

        usedNodes.Add(node.Id);

        while (usedNodes.Count != totalNodes) 
        {
            Edge minEdge = null;

            foreach(var edge in edges) 
            {
                if (!usedNodes.Contains(edge.To.Id) && (minEdge == null || edge.Weight < minEdge.Weight)) 
                {
                    minEdge = edge;
                }
            }

            sum += minEdge.Weight;
            usedNodes.Add(minEdge.To.Id);

            edges.Remove(minEdge);
            edges.AddRange(minEdge.To.Edges);
        }

        return sum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] gNodesEdges = Console.ReadLine().TrimEnd().Split(' ');

        int gNodes = Convert.ToInt32(gNodesEdges[0]);
        int gEdges = Convert.ToInt32(gNodesEdges[1]);

        List<int> gFrom = new List<int>();
        List<int> gTo = new List<int>();
        List<int> gWeight = new List<int>();

        for (int i = 0; i < gEdges; i++)
        {
            string[] gFromToWeight = Console.ReadLine().TrimEnd().Split(' ');

            gFrom.Add(Convert.ToInt32(gFromToWeight[0]));
            gTo.Add(Convert.ToInt32(gFromToWeight[1]));
            gWeight.Add(Convert.ToInt32(gFromToWeight[2]));
        }

        int res = Result.kruskals(gNodes, gFrom, gTo, gWeight);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
