using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пекарь
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new ReyBreadBuilder();
            // Выпекаем
            Bread reybBread = baker.Bake(builder);
            Console.WriteLine(reybBread.ToString());

            Console.Read();
        }
    }

    /// <summary>
    /// Строитель для ржаного хлеба
    /// </summary>
    class ReyBreadBuilder : BreadBuilder
    {
        public override void SetAdditives()
        {
            // не используется
        }

        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }
    }

    /// <summary>
    /// Абстрактный класс строитель
    /// </summary>
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }

        public void CreateBread()
        {
            Bread = new Bread();
        }
        
        public abstract void SetFlour();

        public abstract void SetSalt();

        public abstract void SetAdditives();
    }

    /// <summary>
    /// Пекарь
    /// </summary>
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    /// <summary>
    /// Мука
    /// </summary>
    class Flour
    {
        /// <summary>
        /// Сорт муки
        /// </summary>
        public string Sort { get; set; }
    }

    /// <summary>
    /// Соль
    /// </summary>
    class Salt
    {

    }

    /// <summary>
    /// Пищевые добавки
    /// </summary>
    class Additives
    {
        public string Name { get; set; }
    }

    class Bread
    {
        /// <summary>
        /// Мука
        /// </summary>
        public Flour Flour { get; set; }

        /// <summary>
        /// Соль
        /// </summary>
        public Salt Salt { get; set; }

        /// <summary>
        /// Пищевые добавки
        /// </summary>
        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Flour != null)
            {
                sb.Append(Flour.Sort + "\n");
            }

            if (Salt != null)
            {
                sb.Append("Соль \n");
            }

            if (Additives != null)
            {
                sb.Append("Добавки: " + Additives.Name + "\n");
            }

            return sb.ToString();
        }
    }
}
