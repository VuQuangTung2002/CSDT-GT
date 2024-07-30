using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cay_AVL
{
    public class Node
    {
        public int Hight { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public int key { get; set; }
        public Node(int key)
        {
            this.key = key;
            Hight = 1;
        }
    }
    public class AVLTRee
    {
        public Node root { get; set; }

        // lay chieu cao cuar 1 nut
        public int Hight(Node node)
        {
            return node == null ? 0 : node.Hight;
        }
        // so sanh su max min 
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        // suw can bang cua mot nut
        public int balance(Node node)
        {
            return node == null ? 0 : Hight(node.Left) - Hight(node.Right);
        }
        //quay phai
        public Node xoayphai(Node y)
        {
            Node x = y.Left;
            Node z = x.Right;

            // thuc hien viec xoay trai
            x.Right = y;
            z.Left = x;

            // cap nhat lai chieu cao cua x va y
            x.Hight = Max(Hight(x.Left), Hight(x.Right)) + 1;
            y.Hight = Max(Hight(y.Left), Hight(y.Right)) + 1;

            return x;
        }
        // quay trai
        public Node xoaytrai(Node y)
        {
            Node x = y.Right;
            Node z = x.Left;
            // thuc hien xoay trai
            x.Left = y;
            y.Right = z;

            // cap nhat laij hight cho ca x va y
            x.Hight = Max(Hight(x.Left), Hight(x.Right));
            y.Hight = Max(Hight(x.Left), Hight(x.Right));


            return x;
        }
        // chen nut vao AVL
        public void Inset(int key)
        {
            root = InserNext(root, key);
        }
        public Node InserNext(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }
            if (node.key < key)
            {
                node.Left = InserNext(node.Left, key);
            }
            if (node.key > key)
            {
                node.Right = InserNext(node.Right, key);
            }
            else
            {
                return node;
            }
            // cap nhat lai nut cha 
            node.Hight = Max(Hight(node.Left), Hight(node.Right)) + 1;
            // kiem tra do can bang cua nut cha 
            int b = balance(node);

            // truong hop left left
            if (b > 1 && key < node.Left.key)
            {
                return xoayphai(node);
            }
            // truong hop right right 
            if (b < -1 && key > node.Right.key)
            {
                return xoaytrai(node);
            }
            // truong hop right left
            if (b < -1 && key < node.Right.key)
            {
                // xoay phai node.right
                node.Right = xoayphai(node.Right);
                return xoaytrai(node);
            }
            // truong hop left right 
            if (b > 1 && key < node.Left.key)
            {
                // xoaty trai tai node.left
                node.Left = xoaytrai(node.Left);
                return xoayphai(node);
            }
            return node;

        }
        // in theo thu tu giua
        private void output(Node root)
        {
            if (root != null)
            {
                Console.Write(root.key + " ");
                output(root.Left);
                output(root.Right);
            }

        }
        public void outt()
        {
            output(root);
            {




            }
        }
        class program
        {
            public static void Main(string[] args)
            {
                AVLTRee x = new AVLTRee();
                x.Inset(12);
                x.Inset(13);
                x.Inset(3);
                x.Inset(7);
                x.Inset(9);
                x.Inset(18);
                x.Inset(23);
                x.outt();
            }
        }

    }
}
