using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Permisos
{
    public class NodeSearch
    {
        private TreeNode GetNode(object tag, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.ImageKey.Equals(tag)) return node;

                //recursion
                var next = this.GetNode(tag, node);
                if (next != null) return next;
            }
            return null;
        }

        public TreeNode GetNode(TreeNodeCollection nodes, object tag)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in nodes)
            {
                if (node.ImageKey.Equals(tag)) return node;

                itemNode = this.GetNode(tag, node);
                if (itemNode != null) break;
            }
            return itemNode;
        }
    }
}
