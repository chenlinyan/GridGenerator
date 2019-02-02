using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

namespace KBEngine
{
    public class AStarPath : MonoBehaviour
    {
        public System.Action OnDrawGizmosCallback;
        public List<GraphBase> Graphs
        {
            get
            {
                return AStarData.graphs;
            }
            set
            {
                AStarData.graphs.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    value[i].graphIndex = AStarData.graphIndex++;
                }
                AStarData.graphs = value;

            }
        }

        public bool ShowGraphs
        {
            get
            {
                return showGraphs;
            }
            set
            {
                showGraphs = value;
            }
        }

        private bool showGraphs = false;
        private void Awake()
        {
           // AddGraph(AStarData.GraphType.GridGraph);
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddGraph(int type)
        {
            AStarData.GraphType graphType = (AStarData.GraphType)type;
            AddGraph(graphType);
        }

        public void AddGraph(AStarData.GraphType graphType)
        {
            switch (graphType)
            {
                case AStarData.GraphType.GridGraph:
                    {
                        GridNavGraph gridGraph = new GridNavGraph(AStarData.graphIndex++);
                        gridGraph.graphType = (int)graphType;
                        AStarData.AddGrapData(gridGraph);
                    }
                    break;
                default:
                    break;
            }
        }
         
        private void OnDrawGizmos()
        {
            if (OnDrawGizmosCallback != null)
            {
                if (ShowGraphs)
                {
                    OnDrawGizmosCallback();
                }
                   
            }
        }


    }

}
