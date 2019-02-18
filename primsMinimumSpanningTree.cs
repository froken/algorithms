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

class Solution {

    // Complete the prims function below.
    static int prims(int n, int[][] edges, int start) {
        var d = new Dictionary<int, Dictionary<int, int>>();

        for (int i = 0; i < edges.Length; i++) 
        {
            var directedEdges = new List<int[]>();
            directedEdges.Add(new int[] {edges[i][0], edges[i][1], edges[i][2]});
            directedEdges.Add(new int[] {edges[i][1], edges[i][0], edges[i][2]});

            foreach(var direction in directedEdges) 
            {
                int x = direction[0];
                int y = direction[1];
                int r = direction[2];

                if (!d.ContainsKey(x))
                {
                    d.Add(x, new Dictionary<int, int>());
                }

                if (d[x].ContainsKey(y) && d[x][y] > r) 
                {
                    d[x][y] = r;
                }

                if (!d[x].ContainsKey(y)) 
                {
                    d[x].Add(y, r);
                }
            }
        }

        var node = start;
        var sum = 0;
        var options = new Dictionary<int, int>();
        var usedv = new HashSet<int>();
        usedv.Add(start);

        foreach(var k in d[node].Keys) 
        {
            options.Add(k, d[node][k]);
        }

        while (usedv.Count != d.Count) 
        {
            var minv = -1;

            foreach(var v in options.Keys) 
            {
                if (minv == -1 || options[v] < options[minv]) 
                {
                    minv = v;
                }
            }

            foreach(var v in d[minv].Keys) 
            {
                if (options.ContainsKey(v) && options[v] > d[minv][v]) 
                {
                    options[v] = d[minv][v];
                }

                if (!options.ContainsKey(v) && !usedv.Contains(v)) 
                {
                    options.Add(v, d[minv][v]);
                }
            }

            sum += options[minv];
            node = minv;

            options.Remove(minv);
            usedv.Add(minv);
        }

        return sum;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] edges = new int[m][];

        for (int i = 0; i < m; i++) {
            edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
        }

        int start = Convert.ToInt32(Console.ReadLine());

        int result = prims(n, edges, start);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
