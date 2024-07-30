using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList
    {
        public LinkedListNode<T> GetNodeAt<T>(LinkedList<T> ds, int index)
        {
            LinkedListNode<T> x = ds.First;
            for(int i=0;i< index; i++)
            {
                x = x.Next;
            }

            return x;
        }
        public static void Main(string[] args)
        {
            LinkedList<string> ds = new LinkedList<string>();
            ds.AddLast("Vu Quang Tung");
            ds.AddLast("vu thi hoai");
            ds.AddLast("vu tuan tu");
            // tìm kiem theo index 
            LinkedList d = new LinkedList();
            var node = d.GetNodeAt(ds, 1);
            if(node != null)
            {
                Console.WriteLine($"gia tri cua 1 la " + node.Value);
            }
            else
            {
                Console.WriteLine("khong tim thay phan tu nao ");
            }
            // tim kiem theo gai tri 
            LinkedListNode<string> giatri = ds.Find("Vu Quang Tung");
            Console.WriteLine("gia tri can tim kiem la " + giatri.Value);
            // tim kiem ra mot mang cac danh sach la 
            var mangds = ds.Where(u => u.Contains("tu")).ToList();
            // chuyen doi kieu list sang kieu linkedlist 
            LinkedList<string> dsne =  new LinkedList<string>(mangds);
            foreach(var x in dsne)
            {
                Console.WriteLine($"{x}");
            }
            // chen du lieu thong qua bien linkedlist 

            // dau tien phai tim giá trị gần đó cần chèn trước đã sau đó có thể sử dụng addafter hoặc addbefore để chèn gái trị 
            // tim hoa tri can chen 
            LinkedListNode<string> tim = ds.Find("vu thi hoai");
            // chen gia tri sau gia trij cua Vu thi hoai 
            LinkedList<string> ds2 = new LinkedList<string>();
            ds2.AddLast("vu quang nam");
            ds2.AddLast("pham thi ngoan");
            ds2.AddFirst("ho thi loi");
            // không thể chèn ds2 vào thằng luôn vào ngay sau ds1 mà nó phải truyền từng cái 1 vào 

           //  LinkedList<string> chen = ds.AddAfter(tim, ds2);
           if(tim == null)
            {
                Console.WriteLine(" khong the tim thay vi tri can chen ");
            }
            else
            {
                foreach (var x in ds2)
                {
                    ds.AddAfter(tim, x);
                    tim = tim.Next;
                }
                Console.WriteLine("danh sach sau khi truyen vao la ");
                foreach (var k in ds)
                {
                    Console.WriteLine($"{k}");
                }
            }
           
        }
    }
}
