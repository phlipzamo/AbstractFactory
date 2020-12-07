using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            ColorFactory colorFactory = new ColorFactory();
            Circle circle = shapeFactory.GetData((int)ShapeType.circle).DataItem as Circle;
            circle.GetInfo();

            Red red = colorFactory.GetData((int)ColorType.red).DataItem as Red;
            red.GetInfo();

            Console.ReadLine();

        }
    }

    class FactoryDataItem
    {
        public FactoryDataItem (object dataItem)
        {
            _dataItem = dataItem;
        }
        private object _dataItem;
        public object DataItem { get { return _dataItem; } }
    }

    interface IFactory
    {
        FactoryDataItem GetData(int type);

    }

    abstract class AbstractFactory : IFactory
    {
        public abstract FactoryDataItem GetData(int type);
    }
    class ShapeFactory : AbstractFactory
    {
        public override FactoryDataItem GetData(int type)
        {
            FactoryDataItem factoryDataItem = null;
            switch ((ShapeType)type)
            {
                case ShapeType.circle:
                    factoryDataItem = new FactoryDataItem(new Circle());
                    break;
                case ShapeType.square:
                    factoryDataItem = new FactoryDataItem(new Square());
                    break;
                case ShapeType.rectangle:
                    factoryDataItem = new FactoryDataItem(new Rectangle());
                    break;
            }
            return factoryDataItem;
        }
    }
    class ColorFactory : AbstractFactory
    {
        public override FactoryDataItem GetData(int type)
        {
            FactoryDataItem factoryDataItem = null;
            switch ((ColorType)type)
            {
                case ColorType.blue:
                    factoryDataItem = new FactoryDataItem(new Blue());
                    break;
                case ColorType.red:
                    factoryDataItem = new FactoryDataItem(new Red());
                    break;
                case ColorType.green:
                    factoryDataItem = new FactoryDataItem(new Green());
                    break;
            }
            return factoryDataItem;
        }
    }
    #region shapes

    enum ShapeType
    {
        circle = 1,
        square = 2,
        rectangle = 3
    }

    class Circle
    {
        public void GetInfo()
        {
            Console.WriteLine("This is a circle");
        }
    }

    class Square
    {
        public void GetInfo()
        {
            Console.WriteLine("This is a square");
        }
    }
    class Rectangle
    {
        public void GetInfo()
        {
            Console.WriteLine("This is a rectangle");
        }
    }

    #endregion shapes

    #region Colors

    enum ColorType
    {
        red = 1,
        green = 2,
        blue = 3
    }

    class Red
    {
        public void GetInfo()
        {
            Console.WriteLine("This is red");
        }
    }

    class Green
    {
        public void GetInfo()
        {
            Console.WriteLine("This is green");
        }
    }
    class Blue
    {
        public void GetInfo()
        {
            Console.WriteLine("This is blue");
        }
    }

    #endregion Colors

}
