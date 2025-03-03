﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceControl;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        public MeasureLengthDevice(Units DeviceUnits)
        {
            unitsToUse = DeviceUnits;
        }

        public decimal MetricValue()
        {
            decimal metricMostRecentMeasure;

            if (unitsToUse == Units.Metric)
            {
                metricMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                // Imperial measurement are in pounds.
                // Multiply imperial measurement by 0.4536 to convert from pounds to kilograms.
                //Conver from an integer value to decimal.
                decimal decimalImperialValue = Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 0.4536M;
                metricMostRecentMeasure = decimalImperialValue * conversionFactor;
            }
            return metricMostRecentMeasure;
        }

        public decimal ImperialValue()
        {
            decimal imperialMostRecentMeasure;

            if (unitsToUse == Units.Imperial)
            {
                imperialMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                // Metric measurement are in kilograms.
                // Multiply imperial measurement by 2.2046 to convert from kilograms to pounds.
                //Conver from an integer value to decimal.
                decimal decimalMetricValue = Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 2.2046M;
                imperialMostRecentMeasure = decimalMetricValue * conversionFactor;
            }
            return imperialMostRecentMeasure;
        }

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }
        private void GetMeasurements()
        {
            dataCaptured = new int[10];
            System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
            {
                int x = 0;
                Random timer = new Random();

                while (controller != null)
                {
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                    dataCaptured[x] = controller != null ? controller.TakeMeasurement() : dataCaptured[x];
                    mostRecentMeasure = dataCaptured[x];

                    x++;
                    if (x == 10)
                    {
                        x = 0;
                    }
                }
            });
        }

        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();
                controller = null;
            }
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController controller;
        private const DeviceType measurementType = DeviceType.LENGTH;

        /*   private void GetMeasurements()
           {
               dataCaptured = new int[10];
               System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
                   {
                       int x = 0;
                       Random timer = new Random();
                       while (controller != null)
                       {
                           System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                           dataCaptured[x] = controller != null ?
                               controller.TakeMeasurement() : dataCaptured[x];
                           mostRecentMeasure = dataCaptured[x];
                           x++;
                           if (x == 10)
                           {
                               x = 0;
                           }

                       }
                   }); 
           }*/


    }
}
