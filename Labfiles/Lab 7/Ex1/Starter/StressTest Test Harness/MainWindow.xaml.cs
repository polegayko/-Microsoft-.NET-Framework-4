﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using StressTest;

namespace StessTest_Test_Harness
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

        /// <summary>
        /// Execute some stress tests on girders and show the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doTests_Click(object sender, RoutedEventArgs e)
        {
            testList.Items.Clear();
            resultList.Items.Clear();
            StressTestCase[] stressTestCases = CreateTestCases();
            StressTestCase stc;
            TestCaseResult tcr;

            for (int i = 0; i < stressTestCases.Length; i++)
            {
                stc = stressTestCases[i];

                // TODO - Update this code to resolve errors.
                // This will not compile
                //Material m = stc.girderMaterial;
                //CrossSection c = stc.crossSection;
                //int l = stc.lengthInMm;
                //int h = stc.heightInMm;
                //int w = stc.widthInMm;
                //tcr = stc.testCaseResult.Value;

                stc.PerformStressTest();

                testList.Items.Add(stc.ToString());
                if (stc.GetStressTestResult().HasValue)
                {
                    tcr = (TestCaseResult)stc.GetStressTestResult().Value;
                    resultList.Items.Add(tcr.result.ToString() + " " + tcr.reasonForFailure);
                }
            }
        }

        /// <summary>
        /// Create some sample stress tests
        /// </summary>
        /// <returns>Array of Stress Test Cases</returns>
        private StressTestCase[] CreateTestCases()
        {
            StressTestCase[] stressTestCases = new StressTestCase[10];

            stressTestCases[0] = new StressTestCase();
            stressTestCases[1] = new StressTestCase(Material.Composite, CrossSection.CShaped, 3500, 100, 20);
            stressTestCases[2] = new StressTestCase();
            stressTestCases[3] = new StressTestCase(Material.Aluminium, CrossSection.Box, 3500, 100, 20);
            stressTestCases[4] = new StressTestCase();
            stressTestCases[5] = new StressTestCase(Material.Titanium, CrossSection.CShaped, 3600, 150, 20);
            stressTestCases[6] = new StressTestCase(Material.Titanium, CrossSection.ZShaped, 4000, 80, 20);
            stressTestCases[7] = new StressTestCase(Material.Titanium, CrossSection.Box, 5000, 90, 20);
            stressTestCases[8] = new StressTestCase();
            stressTestCases[9] = new StressTestCase(Material.StainlessSteel, CrossSection.Box, 3500, 100, 20);

            return stressTestCases;
        }
    }
}

