using System.Windows.Forms;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class helps to work with TreeViews
    /// </summary>
    class TreeviewHelper
    {
        /// <summary>
        /// Count number of checked nodes in a treeview
        /// </summary>
        /// <param name="tv">Treeview</param>
        /// <returns>Number of checked nodes</returns>
        internal static int CountCheckNodes(TreeView tv)
        {
            int nodesCount = 0;

            TreeNodeCollection nodes = tv.Nodes;

            foreach (TreeNode n in nodes)
            {
                if (n.Checked && n.Nodes.Count == 0)
                    nodesCount++;

                nodesCount = GetNodeRecursive(n, nodesCount);
            }

            return nodesCount;
        }

        /// <summary>
        /// Count number of checked nodes in a treeNode
        /// </summary>
        /// <param name="treeNode">TreeNode</param>
        /// <param name="numberOfCheckedNodes">Exisiting number of checked nodes</param>
        /// <returns>Number of checked nodes</returns>
        private static int GetNodeRecursive(TreeNode treeNode, int numberOfCheckedNodes)
        {
            if (treeNode.Checked && treeNode.Nodes.Count == 0)
            {
                numberOfCheckedNodes++;
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {
               numberOfCheckedNodes = GetNodeRecursive(tn, numberOfCheckedNodes);
            }

            return numberOfCheckedNodes;
        }
    }
}
