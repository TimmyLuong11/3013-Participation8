using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSON___Serialization
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public DetailWindow()
        {
            InitializeComponent();
        }

        public void SetupWindow(Game selection)
        {
            this.Title = selection.Name;
            txtBlockDetail.Text = selection.Summary;
            txtBlockDate.Text = selection.Date;
            txtBlockMeta.Text = selection.MetaScore;
            txtBlockReview.Text = selection.UserReview;
        }
    }
}
