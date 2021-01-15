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
using System.Data;

namespace CalcMiniXX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            public MainWindow()
        {
            InitializeComponent();
            //создаем обработчик с помощью класса UIElement объекта 'el' и перебираем все элементы ButtonText всех дочерние объекты
            foreach (UIElement el in ButtonText.Children)
            {
                //создаем условие, если объект 'el' принадлежит классу Button
                if (el is Button)
                {
                    //то выполняется обработчик события, преобразуем объект el к классу Button и вызывем метод Button_Click
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        //создаем метод обработчика событий нажатия кнопок
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //создаем переменную Elt, будет равна объекту при нажатии кнопке 'e' на основании класса RoutedEventArgs 
            //приводим к классу Button, берем объект е.OriginalSource с помощью класса Content получаем контент с кнопки и все преобразовываем к классу string
            string elt = (string)((Button)e.OriginalSource).Content;
            //если введенный текст равен "C" 
            if (elt == "C")
            {
                //то обращаемся к TextBlock свойству Text и выводим пуcтую строку
                TxtBlock.Text = "";
            }
            //если введенный текст равен "="
            else if (elt == "=")
            {
                //то выполняется математическое действие с помощью библиотеки using System.Data;
                //создаем переменную value
                //создаем объект на основании класса DataTable, 
                //обращаемся к методу Compute(вычесление математической операции из строки),
                //обращаемся к TextBlock свойству Text и фильром null,
                //преобразовываем к формату ToString()
                string value = new DataTable().Compute(TxtBlock.Text, null).ToString();
                //обращаемся к TextBlock свойству Text и приравниваем к перемнной value
                TxtBlock.Text = value;
            }
            //обращаемся к TextBlock к свойству Text и добавляем полученное значение Elt. 
            //значения суммируются и выводятся в TextBlock
            else
                TxtBlock.Text += elt;
        }
    }
}
