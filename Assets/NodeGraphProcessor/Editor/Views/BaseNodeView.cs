﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Rendering;
using UnityEditor;

using NodeView = UnityEditor.Experimental.UIElements.GraphView.Node;

namespace GraphProcessor
{
	[NodeCustomEditor(typeof(BaseNode))]
	public class BaseNodeView : NodeView
	{
		protected BaseNode		nodeTarget;

		protected BaseGraphView	owner;

        protected VisualElement controlsContainer;

		public void Initialize(BaseGraphView owner, BaseNode node)
		{
			nodeTarget = node;
			this.owner = owner;
			
			AddStyleSheetPath("Styles/BaseNodeView");
			
            controlsContainer = new VisualElement{ name = "controls" };
        	mainContainer.Add(controlsContainer);

			InitializePorts();

			Enable();
		}

		void InitializePorts()
		{
			var inputPort = new PortView(Orientation.Horizontal, Direction.Input, typeof(int), owner.connectorListener);
			var outputPort = new PortView(Orientation.Horizontal, Direction.Output, typeof(int), owner.connectorListener);

			inputContainer.Add(inputPort);
			outputContainer.Add(outputPort);

			SetPosition(new Rect(0, 0, 100, 100));

			owner.AddElement(this);
		}

		public virtual void Enable()
		{
			var field = new TextField();
			mainContainer.Add(field);
			//TODO: draw custom inspector with reflection
		}
	}
}