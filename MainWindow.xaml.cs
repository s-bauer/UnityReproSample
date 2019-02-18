using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var container = new UnityContainer();
            container.RegisterType<ITestClass1, TestClass1>();
            container.RegisterType<ITestClass2, TestClass2>();

            var inst = container.Resolve<ITestClass2>();
            inst.DoStuff();
        }
    }

    public interface ITestClass1
    {
    }

    public class TestClass1 : ITestClass1
    {

    }

    public interface ITestClass2
    {
        void DoStuff();
    }

    public class TestClass2 : ITestClass2
    {
        public TestClass2(ITestClass1 testClass1)
        {
        }

        public void DoStuff()
        {
            throw new Exception("Fuck u");
        }
    }
}
