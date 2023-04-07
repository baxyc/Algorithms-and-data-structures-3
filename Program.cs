using System;

class Program
{
    static void Main()
    {
        RedBlackTree<int> tree = new RedBlackTree<int>();

        // Добавляем элементы в дерево
        tree.Add(10);
        tree.Add(5);
        tree.Add(20);
        tree.Add(3);
        tree.Add(7);
        tree.Add(15);
        tree.Add(25);

        // Ищем элементы в дереве
        Console.WriteLine(tree.Contains(10));  // true
        Console.WriteLine(tree.Contains(5));   // true
        Console.WriteLine(tree.Contains(20));  // true
        Console.WriteLine(tree.Contains(3));   // true
        Console.WriteLine(tree.Contains(7));   // true
        Console.WriteLine(tree.Contains(15));  // true
        Console.WriteLine(tree.Contains(25));  // true
        Console.WriteLine(tree.Contains(1));   // false
        Console.WriteLine(tree.Contains(30));  // false
    }
}


