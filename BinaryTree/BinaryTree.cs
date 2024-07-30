//using Elasticsearch.Net;
//using Microsoft.VisualBasic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BinaryTree
//{
//    public class Node
//    {
//        public int Value {  get; set; }
//        public Node right { get; set; }
//        public Node left { get; set; }
//        // khai bao khoi tao
//        public Node(int value)
//        {
//            this.Value = value;
//            right = left = null;
//        }
//    }
//    public class thunghiem{
//        public Node root {  get; set; }
//        public thunghiem()
//        {
//            root = null;
//        }
//        public Node InsertBinary(Node node, int value)
//        {
//            // them du lieuj vao
//            if(node == null)
//            {
//                return new Node(value);
//            }
//            if(value < node.Value)
//            {
//               root.left = InsertBinary(node.left, value);
//            }
//            if(value > node.Value)
//            {
//               root.right = InsertBinary(node.right, value);
//            }
//               return root;
//        }
//        public void Insert(int value)
//        {
//            root = InsertBinary(root, value);
//        }
//        // khang dinh 
//        // dung ham de quy de xu ly cay con ben trai va phai
//        public void InDequy(Node node)
//        {
//            if(node!= null)
//            {
//                InDequy(node.left);
//                Console.Write(node.Value + " ");
//                InDequy(node.right);
//            }
//        }
//        // duyet tu tren xuong duoi , tu trai sang phai
//        public void DuyetThang(Node node)
//        {
//            if(node != null)
//            {
//                Console.Write(node.Value +" ");
//                DuyetThang(node.left);
//                DuyetThang(node.right);
//            }
//        }
//        // duyet tu duoi len tren 
//        public void phaitrai(Node node)
//        {
//            if (node != null)
//            {
//                Console.Write(node.Value + " ");
//                DuyetThang(node.right);
//                DuyetThang(node.left);
//            }
//        }
//        public static void Main(string[] args)
//        {
//            // them du lieu vao
//            thunghiem x = new thunghiem();
//            x.Insert(13);
//            x.Insert(23);
//            x.Insert(12);
//            x.Insert(34);
//            x.Insert(90);
//            Console.WriteLine("In-order traversal:");
//            x.DuyetThang(x.root);
//            Console.WriteLine();

//        }


//    }

//}
using System;

namespace BinaryTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        // Khai báo khởi tạo
        public Node(int value)
        {
            this.Value = value;
            Right = Left = null;
        }
    }

    public class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public Node InsertBinary(Node node, int value)
        {
            // Thêm dữ liệu vào cây
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = InsertBinary(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = InsertBinary(node.Right, value);
            }

            return node;
        }

        public void Insert(int value)
        {
            Root = InsertBinary(Root, value);
        }

        // Duyệt theo thứ tự trung gian (In-order Traversal)
        public void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }

        // Duyệt theo thứ tự trước (Pre-order Traversal)
        public void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        // Duyệt theo thứ tự sau (Post-order Traversal)
        public void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        public static void Main(string[] args)
        {
            // Thêm dữ liệu vào
            BinaryTree tree = new BinaryTree();
            tree.Insert(13);
            tree.Insert(23);
            tree.Insert(12);
            tree.Insert(34);
            tree.Insert(90);

            Console.WriteLine("In-order traversal:");
            tree.InOrderTraversal(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Pre-order traversal:");
            tree.PreOrderTraversal(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Post-order traversal:");
            tree.PostOrderTraversal(tree.Root);
            Console.WriteLine();
        }
    }
}

