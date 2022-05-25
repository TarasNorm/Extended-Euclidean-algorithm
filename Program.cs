using System;
using System.Numerics;
using System.Collections.Generic;
using ConsoleTables;
using System.Linq;

namespace NSD
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Title = "Extended Euclidean algorithm";
                    Console.Write("Input first number: ");
                    BigInteger a = BigInteger.Parse(Console.ReadLine());
                    Console.Write("Input second number: ");
                    BigInteger b = BigInteger.Parse(Console.ReadLine());
                    if (b > a)
                    {
                        a = a + b;
                        b = a - b;
                        a = a - b;
                    }
                    BigInteger num;
                    BigInteger num1;
                    Queue<BigInteger> r = new Queue<BigInteger>();
                    Queue<BigInteger> q = new Queue<BigInteger>();
                    Queue<BigInteger> t = new Queue<BigInteger>();
                    t.Enqueue(1);
                    t.Enqueue(0);
                    Queue<BigInteger> tt = new Queue<BigInteger>();
                    tt.Enqueue(1);
                    tt.Enqueue(0);
                    Queue<BigInteger> s = new Queue<BigInteger>();
                    s.Enqueue(0);
                    s.Enqueue(1);
                    Queue<BigInteger> st = new Queue<BigInteger>();
                    st.Enqueue(0);
                    st.Enqueue(1);
                    r.Enqueue(a);
                    r.Enqueue(b);
                    while (true)
                    {
                        num = a % b;
                        r.Enqueue(num);
                        num1 = a / b;
                        q.Enqueue(num1);
                        BigInteger i1 = t.Dequeue();
                        BigInteger i2 = t.Dequeue();
                        BigInteger i = i1 - i2 * num1;
                        tt.Enqueue(i);
                        t.Enqueue(i2);
                        t.Enqueue(i);
                        BigInteger j1 = s.Dequeue();
                        BigInteger j2 = s.Dequeue();
                        BigInteger j = j1 - j2 * num1;
                        st.Enqueue(j);
                        s.Enqueue(j2);
                        s.Enqueue(j);
                        a = b;
                        b = num;
                        if (b == 0)
                        {
                            break;
                        }
                    }
                    string[] tablr = Array.ConvertAll(r.ToArray(), x => x.ToString());
                    string[] tab = Array.ConvertAll(q.ToArray(), x => x.ToString());
                    string[] tab1 = { "", "" };
                    string[] tablq = tab1.Concat(tab).ToArray();
                    string[] tabltt = Array.ConvertAll(tt.ToArray(), x => x.ToString());
                    string[] tablst = Array.ConvertAll(st.ToArray(), x => x.ToString());
                    var table = new ConsoleTable(tablr);
                    table.AddRow(tablq).
                        AddRow(tabltt).
                        AddRow(tablst);
                    table.Write();
                    Console.WriteLine("Press Enter to new table...");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter an integer!\nPress Enter to type new value...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}