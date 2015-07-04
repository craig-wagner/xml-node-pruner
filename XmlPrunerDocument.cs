//****************************************************************************
//*  $Archive::                                                             $
//* $Workfile::                                                             $
//*   $Author::                                                             $
//* $Revision::                                                             $
//*  $Modtime::                                                             $
//****************************************************************************
//* Software distributed under the license is distributed on an "AS IS" basis,
//* WITHOUT WARRANTY OF ANY KIND, either express or implied. See the license
//* for the specific language governing rights and limitations under the
//* license.
//*
//* Copyright (C) 2003 Newkirk Products Inc.
//* All Rights Reserved.
//****************************************************************************

namespace XmlNodePruner
{
	#region using
    using System;
	using System.Xml;
	using System.Text;
	#endregion

	/// <summary>
	/// XmlNodePruner is a class derived from XmlDocument that includes the added
	/// capability of pruning empty nodes out of the tree.
	/// </summary>
	public class XmlPrunerDocument : XmlDocument
	{
	    #region Constructors
		public XmlPrunerDocument() : base()
		{
		}

		public XmlPrunerDocument(XmlNameTable nt) : base(nt)
		{
		}
		#endregion

		#region Public Methods
		public void PruneEmptyNodes()
		{
			XmlNode root = DocumentElement;

			Prune(root);
		}
		#endregion

		#region Private/Protected Methods
		private void Prune(XmlNode parentNode)
		{
			XmlNode[] nodeList = new XmlNode[parentNode.ChildNodes.Count];
			int i = 0;

			//
			// "freeze" the list of child nodes.  When I start deleting
			// empty child nodes, the parentNode.ChildNodes collection
			// attribute appears to get rearranged.  That makes walking
			// through a list of child nodes that we're also in the
			// process of deleting a little tricky.
			//
			foreach ( XmlNode node in parentNode.ChildNodes )
			{
				nodeList[i++] = node;
			}

			//
			// Now walk through the "frozen" list of child nodes and
			// get rid of any that are empty.
			//
			for ( i = nodeList.Length - 1; i >= 0; i-- )
			{
				XmlNode childNode = nodeList[i];
				if ( childNode.HasChildNodes )
				{
					Prune(childNode);
				}

				if ( childNode.InnerText == "" )
				{
					parentNode.RemoveChild(childNode);
				}
			}
		}
		#endregion
	}
}

//****************************************************************************
//* $Log: $
