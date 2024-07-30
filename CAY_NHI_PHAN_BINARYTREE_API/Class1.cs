using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CAY_NHI_PHAN_BINARYTREE_API
{
    public class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
    public class Node
    {
        public Todo data {  get; set; }
        public Node right {  get; set; }
        public Node left { get; set; }
        // khoi tao
        public Node(Todo data)
        {
            this.data = data;
            right = left = null;
        }

    }
    public class Cay_Nhi_Phan
    {
        public Node node { get; set; }
        // them cay nhi phan vao danh sach 
        public Node Insert(Node node, Todo data)
        {
            if(node == null)
            {
                return new Node(data);
            }
            if(data.Id < node.data.Id)
            {
                node.left = Insert(node.left, data);
            }
            if(data.Id > node.data.Id)
            {
                node.right = Insert(node.right, data);
            }
            return node;
        }
        public void InsertBinary(Todo data)
        {
            // them du lieu vao 
            node = Insert(node, data);
        }
        // duyt cay theo kieu tu trung gian den trai, den phai
        public void Duyet(Node node)
        {
            if(node != null)
            {
                Console.WriteLine($"Id: {node.data.Id}, Title: {node.data.Title}");
                Duyet(node.left);
                Duyet(node.right);
            }
        }
        private bool timkiem(Node node, int id)
        {
            if (node == null)
            {
                return false; // Nếu cây rỗng, không tìm thấy giá trị
            }

            if (node.data.Id == id)
            {
                return true; // Nếu giá trị của nút hiện tại bằng giá trị cần tìm
            }

            if (id < node.data.Id)
            {
                return timkiem(node.left, id); // Tìm kiếm trong cây con bên trái
            }
            else
            {
                return timkiem(node.right, id); // Tìm kiếm trong cây con bên phải
            }

        }

        public static async Task Main(string[] args)
        {
            Cay_Nhi_Phan x = new Cay_Nhi_Phan();
            
           
            
            // tim kiem du lieu lien quan den APi
            string url = "https://jsonplaceholder.typicode.com/todos";
            using HttpClient client = new HttpClient();
            string chuyen = await client.GetStringAsync(url);
            List<Todo> json = JsonConvert.DeserializeObject<List<Todo>>(chuyen);
           foreach(var z in json)
            {
                x.InsertBinary(z);
            }
            x.Duyet(x.node);
            Console.Write("nhap vao so can tim la ");
            int h = int.Parse(Console.ReadLine());
            string k = x.timkiem(x.node, h) ? "yes" : "no";
            Console.WriteLine($"so" + h + " nhap vao la " + k);
        }
    }
}
