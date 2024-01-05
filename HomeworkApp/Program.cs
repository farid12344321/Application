using System;
using System.Linq;
using System.Security.Principal;

namespace HomeworkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] product = {"iphone","samsung"};
            string opt;
            do 
            {
                Console.WriteLine("1. Bütün mehsullara bax");
                Console.WriteLine("2. Seçilmiç mehsula bax");
                Console.WriteLine("3. Yeni mehsul elave et");
                Console.WriteLine("4. Mehsul adını deyiş");
                Console.WriteLine("5. Seçilmiş mehsulu sil");
                Console.WriteLine("0 .Çıx");


                Console.Write("Emeliyyat secin: ");
                opt = Console.ReadLine();


                switch (opt)
                {
                    case "1":
                        ShowProducts(product);
                        break;
                    case "2":
                        Console.WriteLine("Indexi daxil et");
                        string indexStr = Console.ReadLine();
                        try
                        {
                            int index = Convert.ToInt32(indexStr);
                            Console.WriteLine(product[index]);
                        }
                        catch
                        {
                            Console.WriteLine("Xeta bas verdi");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Yeni Product adi yazin");
                        string newProductName = Console.ReadLine();
                        AddNewProduct(ref product, ref newProductName);
                        break;
                    case "4":
                        ShowProducts(product);

                        EditProduct(product);

                        break;
                    case "5":
                        ShowProducts(product);
                        try
                        {
                            DeleteProduct(ref product);
                        }
                        catch
                        {
                            Console.WriteLine("Xeta bas verdi");
                        }
                        break;
                    default:
                        Console.WriteLine("Yanlis emeliyyat");
                        break;
                }
            }
            while (opt !="0");
            Console.WriteLine("Emeliyat bitdi");

        }
        static void ShowProducts(string[] product)
        {
            for (int i = 0; i < product.Length; i++)
            {
                Console.WriteLine($"                                              {i}. {product[i]}");
            }
        }
        static void EditProduct(string[] products)
        {
            Console.WriteLine("Adini deysimek istediyin productun indexi elave edin");
            string editProductStr = Console.ReadLine();
            int editProduct = Convert.ToInt32(editProductStr);

            Console.WriteLine("Yeni product adi elave edin");

            string nn = Console.ReadLine();

            string mm = "";
            int startIndex = FindFirstNonSpaceIndex(nn);
            int endIndex = FindLasttNonSpaceIndex(nn);

            for (int i = startIndex; i <= endIndex; i++)
            {
                mm += nn[i];
            }
            if (mm.Length >= 2 && mm.Length <= 20)
            {
                products[editProduct] = mm;
            }
            else
            {
                Console.WriteLine("Productun adi Min 2 max 20 olmalidir ! ");
            }
        }
        static void DeleteProduct(ref string[] products)
        {
            Console.WriteLine("Delete etmek istediyin indexi secin");

            string idStr = Console.ReadLine();
            int index = Convert.ToInt32(idStr);
            int count = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (index == i)
                {
                    Console.WriteLine($"Silindi: {products[i]}");
                }
                else
                {
                    count++;
                }
            }
            string[] newarr = new string[count];
            int index2 = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if(index != i) 
                {
                    newarr[index2] = products[i];
                    index2++;
                }
            }
            products = newarr;
        }
        static void AddNewProduct(ref string[] arr,ref string nn)
        {
            string mm = "";
            int startIndex = FindFirstNonSpaceIndex(nn);
            int endIndex = FindLasttNonSpaceIndex(nn);
            for (int i = startIndex; i <= endIndex; i++)
            {
                mm += nn[i];
            }


            string[] newArr = new string[arr.Length + 1];

            bool check = false;

            if (mm.Length >= 2 && mm.Length <= 20)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (mm != arr[i])
                    {
                        newArr[i] = arr[i];
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Eyni iki adli product olmaz");
                        check = false;
                        break;
                    }
                    
                   
                }
                if (check)
                {
                    newArr[newArr.Length - 1] = mm;
                    arr = newArr;
                }
              
            }
            else
            {
                Console.WriteLine("Productun adi Min 2 max 20 olmalidir ! ");
            }
            
           
        }


        static int FindFirstNonSpaceIndex(string product)
        {
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i] != ' ')
                {
                    return i;
                }
            }
            return -1;
        }
        static int FindLasttNonSpaceIndex(string product)
        {
            for (int i = product.Length - 1; i >= 0; i--)
            {
                if (product[i] != ' ')
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
