﻿using System;

namespace ShoppingCenter
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var productRepository = new ProductRepository();
            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine();
                var index = cmd.IndexOf(' ');
                var command = cmd.Substring(0, index);

                try
                {
                    var cmdArgs = cmd.Substring(index + 1).Split(';', StringSplitOptions.RemoveEmptyEntries);
                    switch (command)
                    {
                       
                        case "AddProduct":
                            productRepository.AddProduct(cmdArgs[0],
                                decimal.Parse(cmdArgs[1]), cmdArgs[2]);
                            Console.WriteLine("Product added");
                            break;
                        case "DeleteProducts":
                            var deleted = 0;
                            if (cmdArgs.Length == 1)
                            {
                                deleted = productRepository.DeleteByProducer(cmdArgs[0]);
                            }
                            else
                            {
                                 deleted = productRepository.DeleteByNameAndProducer(cmdArgs[0], cmdArgs[1]);
                            }
                            Console.WriteLine($"{deleted} products deleted");
                            break;
                        case "FindProductsByName":
                            var result = productRepository.FindByName(cmdArgs[0]);
                            Console.WriteLine(String.Join(Environment.NewLine, result));
                            break;
                        case "FindProductsByProducer":
                            var resultByProducer = productRepository.FindByProducer(cmdArgs[0]);
                            Console.WriteLine(String.Join(Environment.NewLine, resultByProducer));
                            break;
                        case "FindProductsByPriceRange":
                            var resultByPrice = productRepository
                                .FindProductsByPriceRange(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                            Console.WriteLine(String.Join(Environment.NewLine, resultByPrice));
                            break;

                        default:
                            break;
                    }



                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
