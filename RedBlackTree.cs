public class RedBlackTree<T> where T : IComparable<T>
{
    private enum NodeColor { Red, Black };

    private class Node
    {
        public T value;
        public NodeColor color;
        public Node left;
        public Node right;

        public Node(T value, NodeColor color)
        {
            this.value = value;
            this.color = color;
        }
    }

    private Node root;

    public bool Contains(T value)
    {
        return FindNode(value) != null;
    }

    public void Add(T value)
    {
        root = AddNode(root, value);
        root.color = NodeColor.Black;
    }

    private Node AddNode(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value, NodeColor.Red);
        }

        if (value.CompareTo(node.value) < 0)
        {
            node.left = AddNode(node.left, value);
        }
        else if (value.CompareTo(node.value) > 0)
        {
            node.right = AddNode(node.right, value);
        }
        else
        {
            throw new ArgumentException("Value already exists in tree");
        }

        if (IsRed(node.right) && !IsRed(node.left))
        {
            node = RotateLeft(node);
        }

        if (IsRed(node.left) && IsRed(node.left.left))
        {
            node = RotateRight(node);
        }

        if (IsRed(node.left) && IsRed(node.right))
        {
            FlipColors(node);
        }

        return node;
    }

    private Node FindNode(T value)
    {
        Node node = root;
        while (node != null)
        {
            if (value.CompareTo(node.value) < 0)
            {
                node = node.left;
            }
            else if (value.CompareTo(node.value) > 0)
            {
                node = node.right;
            }
            else
            {
                return node;
            }
        }

        return null;
    }

    private bool IsRed(Node node)
    {
        if (node == null)
        {
            return false;
        }

        return node.color == NodeColor.Red;
    }

    private Node RotateLeft(Node node)
    {
        Node x = node.right;
        node.right = x.left;
        x.left = node;
        x.color = node.color;
        node.color = NodeColor.Red;
        return x;
    }

    private Node RotateRight(Node node)
    {
        Node x = node.left;
        node.left = x.right;
        x.right = node;
        x.color = node.color;
        node.color = NodeColor.Red;
        return x;
    }

    private void FlipColors(Node node)
    {
        node.color = NodeColor.Red;
        node.left.color = NodeColor.Black;
        node.right.color = NodeColor.Black;
    }
}
