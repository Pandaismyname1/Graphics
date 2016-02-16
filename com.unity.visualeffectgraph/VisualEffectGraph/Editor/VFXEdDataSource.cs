using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor.Experimental;
using UnityEditor.Experimental.Graph;
using Object = UnityEngine.Object;

namespace UnityEditor.Experimental
{
    internal class VFXEdDataSource : ScriptableObject, ICanvasDataSource
    {
        private List<CanvasElement> m_Elements = new List<CanvasElement>();

        public void OnEnable()
        {
            VFXEditor.BlockLibrary.Load(); // Force a reload
        }

        public void AddNode(VFXEdNode n)
        {
            m_Elements.Add(n);
        }

        public void AddEventNode(VFXEdEventNode n)
        {
            m_Elements.Add(n);
        }

        public void UndoSnapshot(string Message)
        {
            // TODO : Make RecordObject work (not working, no errors, have to investigate)
            Undo.RecordObject(this, Message);
        }

        public CanvasElement[] FetchElements()
        {
            return m_Elements.ToArray();
        }

        public void DeleteElement(CanvasElement e)
        {
            Canvas2D canvas = e.ParentCanvas();

            // Handle model update when deleting edge here
            var edge = e as FlowEdge<VFXEdFlowAnchor>;
            if (edge != null)
            {
                VFXEdFlowAnchor anchor = edge.Right;
                var node = anchor.FindParent<VFXEdContextNode>();

                VFXSystemModel owner = node.Model.GetOwner();
                int index = owner.GetIndex(node.Model);

                VFXSystemModel newSystem = new VFXSystemModel();
                while (owner.GetNbChildren() > index)
                    owner.GetChild(index).Attach(newSystem);
                newSystem.Attach(VFXEditor.AssetModel);
            }


            m_Elements.Remove(e);
            canvas.ReloadData();
            canvas.Repaint();
        }

        public void Connect(VFXEdDataAnchor a, VFXEdDataAnchor b)
        {
            m_Elements.Add(new Edge<VFXEdDataAnchor>(this, a, b));
        }

        public bool ConnectFlow(VFXEdFlowAnchor a, VFXEdFlowAnchor b)
        {
            if (a.GetDirection() == Direction.Input)
            {
                VFXEdFlowAnchor tmp = a;
                a = b;
                b = tmp;
            }

            VFXEdContextNode context0 = a.FindParent<VFXEdContextNode>();
            VFXEdContextNode context1 = b.FindParent<VFXEdContextNode>();


            if (context0 != null && context1 != null)
            {

                VFXContextModel model0 = context0.Model;
                VFXContextModel model1 = context1.Model;

                if (!VFXSystemModel.ConnectContext(model0, model1))
                    return false;

            }

            var edgesToErase = new List<FlowEdge<VFXEdFlowAnchor>>();
            foreach (CanvasElement element in m_Elements)
            {
                FlowEdge<VFXEdFlowAnchor> edge = element as FlowEdge<VFXEdFlowAnchor>;
                if (edge != null && (edge.Left == a || edge.Right == a || edge.Left == b || edge.Right == b))
                    edgesToErase.Add(edge);
            }

            foreach (var edge in edgesToErase)
                m_Elements.Remove(edge);

            m_Elements.Add(new FlowEdge<VFXEdFlowAnchor>(this, a, b));
            return true;
        }

        public void AddEventNode(object o)
        {
            VFXEdSpawnData data = o as VFXEdSpawnData;
            VFXEdEventNode node = null;
            switch (data.spawnType)
            {
                case SpawnType.Event:
                    node = new VFXEdEventNode(data.mousePosition, this, "Event");
                    break;
                default:
                    break;
            }
            if (node != null)
                AddEventNode(node);
            data.targetCanvas.ReloadData();
        }

        public void AddEmptyNode(object o)
        {
            VFXEdSpawnData data = o as VFXEdSpawnData;
            VFXEdNode node = null;
            switch (data.spawnType)
            {
                case SpawnType.TriggerNode:
                    node = new VFXEdTriggerNode(data.mousePosition, this);
                    break;
                case SpawnType.DataNode:
                    node = new VFXEdDataNode(data.mousePosition, this);
                    break;
                case SpawnType.Node:
                    node = new VFXEdContextNode(data.mousePosition, data.context, this);
                    break;
                default:
                    break;
            }

            if (node != null)
                AddNode(node);
            data.targetCanvas.ReloadData();
        }

    }
}

