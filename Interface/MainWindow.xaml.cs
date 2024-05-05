using ShapesWithComputableArea;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestProject2;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoTests();
            DataContext = new ViewModel();
        }

        private void DoTests ()
        {
            var triangleTest = new TriangleTests();
            triangleTest.TestIsARightTriangle();
            triangleTest.TestArea();
            var circleTest = new CircleTests();
            circleTest.TestArea();
        }

        private void AddTriangle(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel vm)
            {
                if (vm.A.HasValue && vm.B.HasValue && vm.C.HasValue)
                {
                    try
                    {
                        vm.Triangles.Add(new Triangle(vm.A.Value, vm.B.Value, vm.C.Value, new TriangleAreaComputer()));
                    }
                    catch (Exception ex)
                    {
                        vm.ErrorMessageTriangle = ex.Message;
                        return;
                    }
                    vm.ErrorMessageTriangle = string.Empty;
                }
            }
        }

        private void AddCircle(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel vm)
            {
                if (vm.Radius.HasValue)
                {
                    try
                    {
                        vm.Circles.Add(new Circle(vm.Radius.Value, new CircleAreaComputer()));
                    }
                    catch (Exception ex)
                    {
                        vm.ErrorMessageCircle = ex.Message;
                        return;
                    }
                    vm.ErrorMessageCircle = string.Empty;
                }
            }
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Triangle> Triangles { get; set; } = [];
        public ObservableCollection<Circle> Circles { get; set; } = [];
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? Radius { get; set; }
        public string ErrorMessageCircle { get; set; } = string.Empty;
        public string ErrorMessageTriangle { get; set; } = string.Empty;
    }
}