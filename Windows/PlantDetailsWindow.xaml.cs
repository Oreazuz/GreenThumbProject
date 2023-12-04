﻿using GreenThumbProject.Database;
using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantModel PlantModel { get; set; }
        public PlantDetailsWindow(PlantModel plantModel)
        {
            InitializeComponent();
            PlantModel = plantModel;
            FillFields();

        }

        private void FillFields()
        {

            using (AppDbContext context = new())
            {
                var plant = context.Plants.Include(p => p.Instructions).First(p => p.PlantName == PlantModel.PlantName);
                txtName.Text = PlantModel.PlantName;
                txtDescription.Text = PlantModel.PlantDescription;
                var instructions = plant.Instructions.ToList();
                foreach (var instruction in instructions)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = instruction;
                    item.Content = instruction.ToString();
                    lstInstructions.Items.Add(item);
                }
            }



        }
    }
}
