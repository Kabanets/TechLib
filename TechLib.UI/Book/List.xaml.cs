﻿using System;
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
using TechLib.DataAccess;
using TechLib.DataAccess.Repositories;

namespace TechLib.UI.Book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
            this.DataContext = new BookViewModel(new BookRepository(new AppDbContext()));
        }
    }
}
