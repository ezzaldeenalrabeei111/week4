using System;

namespace BirdHierarchy.Core
{
    /// <summary>
    /// الكلاس الأساسي لجميع الطيور. يحتوي على الخصائص والسلوكيات المشتركة.
    /// لا يحتوي على دالة Fly() لتجنب انتهاك LSP للطيور غير الطائرة.
    /// </summary>
    public abstract class Bird
    {
        public string Name { get; private set; }

        /// <summary>
        /// منشئ الكلاس Bird.
        /// </summary>
        /// <param name="name">اسم الطائر.</param>
        protected Bird(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Bird name cannot be null or empty.");
            }
            Name = name;
        }

        /// <summary>
        /// سلوك مشترك لجميع الطيور (مثل الأكل).
        /// </summary>
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        /// <summary>
        /// دالة مجردة لعرض معلومات الطائر. يجب أن تنفذها الكلاسات المشتقة.
        /// </summary>
        public abstract void DisplayInfo();
    }
}
