﻿
namespace OSAE.UI.Controls
{
    using System;
    using System.IO;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for AddControlStateImage.xaml
    /// </summary>
    public partial class AddControlStateImage : UserControl
    {
        private OSAE osae = new OSAE("OSAE.UI.Controls");
        private string currentScreen;

        public AddControlStateImage(string screen)
        {
            InitializeComponent();
            currentScreen = screen;
            LoadObjects();
        }

        /// <summary>
        /// Load the objects from the DB into the combo box
        /// </summary>
        private void LoadObjects()
        {
            DataSet dataSet = osae.RunSQL("SELECT object_name FROM osae_v_object order by object_name");
            objectComboBox.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name 
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png"; // Filter files by extension 

            if (dlg.ShowDialog() == true)
            {
                imgState1.Source = new BitmapImage(new Uri(dlg.FileName));
                txtState1Path.Text = dlg.FileName;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name 
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png"; // Filter files by extension 

            if (dlg.ShowDialog() == true)
            {
                imgState2.Source = new BitmapImage(new Uri(dlg.FileName));
                txtState2Path.Text = dlg.FileName;
            }
        }

        private void objectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string fileName1 = Path.GetFileName(txtState1Path.Text).Split('.')[0];
            string fileName2 = Path.GetFileName(txtState2Path.Text).Split('.')[0];
            string ext1 = Path.GetFileName(txtState1Path.Text).Split('.')[1];
            string ext2 = Path.GetFileName(txtState2Path.Text).Split('.')[1];

            ImageManager imgMgr = new ImageManager();

            int imgID1 = 0;
            int imgID2 = 0;
            byte[] byt1;
            byte[] byt2;

            if(ext1.ToLower() == "jpg" || ext1.ToLower() == "jpeg")
            {
                byt1 = imgMgr.getJPGFromImageControl((BitmapImage)imgState1.Source);
                imgID1 = imgMgr.AddImage(fileName1,ext1,byt1);
            }
            else if(ext1.ToLower() == "png")
            {
                byt1 = imgMgr.getPNGFromImageControl((BitmapImage)imgState1.Source);
                imgID1 = imgMgr.AddImage(fileName1,ext1,byt1);
            }

            if (ext2.ToLower() == "jpg" || ext2.ToLower() == "jpeg")
            {
                byt2 = imgMgr.getJPGFromImageControl((BitmapImage)imgState2.Source);
                imgID2 = imgMgr.AddImage(fileName2, ext2, byt2);
            }
            else if (ext2.ToLower() == "png")
            {
                byt2 = imgMgr.getPNGFromImageControl((BitmapImage)imgState2.Source);
                imgID2 = imgMgr.AddImage(fileName2, ext2, byt2);
            }

            string sName = currentScreen + " - " + objectComboBox.Text;
            osae.ObjectAdd(sName, sName, "CONTROL STATE IMAGE", "", currentScreen, true);
            osae.ObjectPropertySet(sName, "Object Name", objectComboBox.Text);
            osae.ObjectPropertySet(sName, "State 1 Name", "ON");
            osae.ObjectPropertySet(sName, "State 1 Image", fileName1);
            osae.ObjectPropertySet(sName, "State 1 X", "100");
            osae.ObjectPropertySet(sName, "State 1 Y", "100");
            osae.ObjectPropertySet(sName, "State 2 Name", "OFF");
            osae.ObjectPropertySet(sName, "State 2 Image", fileName2);
            osae.ObjectPropertySet(sName, "State 2 X", "100");
            osae.ObjectPropertySet(sName, "State 2 Y", "100");
            osae.ObjectPropertySet(sName, "Zorder", "1");

            osae.ScreenObjectAdd(currentScreen,objectComboBox.Text,sName);

            NotifyParentFinished();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NotifyParentFinished();
        }

        /// <summary>
        /// Let the hosting contol know that we are done
        /// </summary>
        /// <remarks>At present it tells the parent to close, this could later be altered to have a event that fires to
        /// the parent allowing them to decide what to do when the control is finished. If the control is being hosted in
        /// an element host this will have no affect as the parent is the element host and not the form.</remarks>
        private void NotifyParentFinished()
        {
            // Get the window hosting us so we can ask it to close
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}