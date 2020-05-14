using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace testUI
{
    public partial class Form2 : Form
    {
        public List<Node> path = new List<Node>();
        public List<Node> nodes = new List<Node>();
        public Dictionary<int, List<Node>> availablePaths = new Dictionary<int, List<Node>>();
        public int pathCounter = 0;
        public Node startNode;
        public int currentNodeIndex;

        public void findPaths()
        {
            // nodes[currentNodeIndex] == current node
            pathCounter = 0;
            currentNodeIndex = 0;
            path.Add(nodes[currentNodeIndex]);
            while (path.Count > 0)
            {
                if (nodes[currentNodeIndex].getNodeType() != "finish")
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    for (int b=0; b<path.Count; b++)
                    {
                        Console.Write( path[b].getNodeName().ToUpper() + " ");
                    }
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------");
                    
                    Console.WriteLine("Current nodename:  " + nodes[currentNodeIndex].getNodeName()+ " children number: " + nodes[currentNodeIndex].children.Count);
                    Console.WriteLine("CURRENT NODE INDEX:  " + currentNodeIndex);
                    for (int i=0; i< nodes[currentNodeIndex].children.Count; i++ )
                    {
                        //nodes[currentNodeIndex].visitedNodes.FindIndex(item => item.getNodeName == nodes[currentNodeIndex].children)
                        Console.WriteLine("+++++ "+nodes[currentNodeIndex].getNodeName() + " " + nodes[currentNodeIndex].children[i].getNodeName() + " " + nodes[currentNodeIndex].visitedNodes.Contains(nodes[currentNodeIndex].children[i]));
                        if (!nodes[currentNodeIndex].visitedNodes.Contains(nodes[currentNodeIndex].children[i]))
                        {
                            nodes[currentNodeIndex].visitedNodes.Add(nodes[currentNodeIndex].children[i]);
                            path.Add(nodes[currentNodeIndex].children[i]);
                            string str = nodes[currentNodeIndex].children[i].getNodeName();
                            Console.WriteLine();
                            currentNodeIndex = nodes.FindIndex(item => item.getNodeName() == str);
                            Console.WriteLine("INDEX: " + currentNodeIndex);
                            //nodes[currentNodeIndex].visitedNodes.FindIndex(item => item.getNodeName == nodes[currentNodeIndex].children)
                            break;
                        }else if (nodes[currentNodeIndex].visitedNodes.Count == nodes[currentNodeIndex].children.Count)
                        {
                            nodes[currentNodeIndex].visitedNodes.Clear();
                            path.Remove(nodes[currentNodeIndex]);
                            if ((path.Count-1) >= 0)
                            {
                                currentNodeIndex = nodes.FindIndex(item => item.getNodeName() == path[path.Count-1].getNodeName());
                                //currentNodeIndex = path.Count - 1;
                                
                            }
                            else
                            {
                                //Finish searching for paths
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CURRR " + nodes[currentNodeIndex].getNodeName());
                    //path.Add(nodes[currentNodeIndex]);
                    List<Node> list = new List<Node>(path);
                    availablePaths.Add(pathCounter, list);
                    pathCounter++;
                    int x = path.Count -1 ;
                    //Console.WriteLine("x: " + x);
                    //Console.WriteLine("PATHLENGTH: " + path.Count);
                    Console.WriteLine("Path: ");
                    for (int i = 0; i < path.Count; i++)
                    {
                        Console.Write(i + " " + path[i].getNodeName() + " ");
                    }
                    path.RemoveAt(x);
                    Console.WriteLine();
                    currentNodeIndex = nodes.FindIndex(item => item.getNodeName() == path[path.Count - 1].getNodeName());
                    //Console.WriteLine("indeddddd: " +  currentNodeIndex);
                    //Console.WriteLine("brrrrrrrr: " + nodes[currentNodeIndex].getNodeName());
                    //currentNodeIndex = path.Count - 1;
                }
            }
            //Console.WriteLine("Current node: " + currentNode.getNodeName() + ", capacity:" + currentNode.getNodeCapacity() + ", current flow:" + currentNode.getNodeCurrentFlow());
            //path.Add();
            
            //PRINT FOUND PATHS
            for (int i=0; i<availablePaths.Count;i++)
            {
                //Console.WriteLine("PATH "+ i +":");
                for (int j=0; j<availablePaths[i].Count; j++)
                {
                    Console.Write(availablePaths[i][j].getNodeName() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("YOLLAR BULUNDU!");
        }
    }
}
