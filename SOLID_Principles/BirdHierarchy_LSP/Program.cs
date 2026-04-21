using System;
using System.Collections.Generic;
using BirdHierarchy.Core;
using BirdHierarchy.Birds;

namespace BirdHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- LSP Compliant Bird Hierarchy Demo ---");

            // إنشاء كائنات من أنواع مختلفة من الطيور
            Bird eagle = new Eagle("Majestic Eagle");
            Bird sparrow = new Sparrow("Chirpy Sparrow");
            Bird ostrich = new Ostrich("Speedy Ostrich");
            Bird penguin = new Penguin("Waddling Penguin");

            List<Bird> allBirds = new List<Bird> { eagle, sparrow, ostrich, penguin };

            Console.WriteLine("\n--- Displaying Info and Eating Behavior (Common to all Birds) ---");
            foreach (var bird in allBirds)
            {
                bird.DisplayInfo();
                bird.Eat();
            }

            Console.WriteLine("\n--- Flying Behavior (Only for IFlyable Birds) ---");
            foreach (var bird in allBirds)
            {
                // هذا هو المكان الذي نطبق فيه LSP:
                // نتحقق مما إذا كان الطائر يستطيع الطيران قبل محاولة استدعاء دالة Fly().
                // هذا يمنع خطأ التحويل الذي واجهته.
                if (bird is IFlyable flyableBird)
                {
                    flyableBird.Fly();
                }
                else
                {
                    Console.WriteLine($"{bird.Name} cannot fly. (It is a Bird, but not IFlyable)");
                }
            }

            Console.WriteLine("\n--- Specific Behaviors (Casting to specific types) ---");
            // الوصول إلى سلوكيات خاصة بأنواع معينة بعد التحقق أو التحويل الآمن
            if (ostrich is Ostrich specificOstrich)
            {
                specificOstrich.Run();
            }

            if (penguin is Penguin specificPenguin)
            {
                specificPenguin.Swim();
            }

            Console.WriteLine("\n--- Demonstrating LSP Compliance with helper methods ---");
            // دالة ProcessBird تقبل أي كائن من نوع Bird (الكلاس الأساسي)
            ProcessBird(eagle);    // تمرير Eagle (يرث من Bird)
            ProcessBird(ostrich);  // تمرير Ostrich (يرث من Bird)

            // دالة ProcessFlyable تقبل فقط كائنات تطبق واجهة IFlyable
            // لذلك يجب التأكد من أن الكائن يطبق الواجهة قبل تمريره.
            if (eagle is IFlyable flyableEagleForProcess)
            {
                ProcessFlyable(flyableEagleForProcess); // صحيح: Eagle يطبق IFlyable
            }
            if (sparrow is IFlyable flyableSparrowForProcess)
            {
                ProcessFlyable(flyableSparrowForProcess); // صحيح: Sparrow يطبق IFlyable
            }

            // مثال على ما سيسبب الخطأ الذي واجهته:
            // ProcessFlyable(ostrich); // هذا السطر سيسبب خطأ "cannot convert from 'Bird' to 'IFlyable'"
            // لأنه Ostrich هو Bird لكنه لا يطبق IFlyable.

            Console.WriteLine("\n--- End of Demo ---");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// دالة مساعدة تقبل أي كائن من نوع Bird (الكلاس الأساسي).
        /// </summary>
        static void ProcessBird(Bird bird)
        {
            Console.WriteLine($"Processing bird: {bird.Name}");
            bird.Eat();
            bird.DisplayInfo();
        }

        /// <summary>
        /// دالة مساعدة تقبل فقط كائنات تطبق واجهة IFlyable.
        /// </summary>
        static void ProcessFlyable(IFlyable flyable)
        {
            Console.WriteLine($"Processing flyable object.");
            flyable.Fly();
        }
    }
}
