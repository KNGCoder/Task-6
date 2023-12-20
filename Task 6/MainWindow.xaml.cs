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

namespace Task_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            private ListBoxItem dragSource;
   

        private void ListBox_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is ListBox listBox)
            {
                var point = e.GetPosition(listBox);
                var hitResult = VisualTreeHelper.HitTest(listBox, point);

                if (hitResult != null)
                {
                    dragSource = hitResult.VisualHit as ListBoxItem;
                }
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBox listBox && dragSource != null)
            {
                var point = e.GetPosition(listBox);
                var hitResult = VisualTreeHelper.HitTest(listBox, point);

                if (hitResult != null && hitResult.VisualHit is ListBoxItem target)
                {
                    var sourceIndex = listBox.Items.IndexOf(dragSource.Content);
                    var targetIndex = listBox.Items.IndexOf(target.Content);

                    listBox.Items.Remove(dragSource.Content);
                    listBox.Items.Insert(targetIndex, dragSource.Content);
                }
            }

        }
    }
}