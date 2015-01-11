﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Wa1gon.Models;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Wa1gon.Models.Common;

namespace IntergrationTest
{

    /// <summary>  These are not unit test but integration test for the test
    /// to work correct there must be a connection with the name of "Flex" connected to 
    /// a PowerSDR.  The PowerSDR can be running in demo mode, as well as the RigControlServer
    /// 
    /// </summary>


    [TestClass()]
    public class SettingsTest
    {


        [ClassInitialize()]
        static public void TestSetup(TestContext context)
        {
            string baseUrl = "http://localhost:7301/api/Connection";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl).Result;

            var results = response.Content.ReadAsAsync<List<RadioComConnConfig>>().Result;

            bool hasFlex = results.Exists(n => n.ConnectionName == "Flex");
            if (hasFlex == false)
            {
                throw new Exception("Flex isn't defined");
            }

        }
        //[AssemblyInitialize()]
        //public static void AssemblyInit(TestContext context)
        //{
        //    MessageBox.Show("AssemblyInit " + context.TestName);
        //}

        //[ClassInitialize()]
        //public static void ClassInit(TestContext context)
        //{
        //    MessageBox.Show("ClassInit " + context.TestName);
        //}

        //[TestInitialize()]
        //public void Initialize()
        //{
        //    MessageBox.Show("TestMethodInit");
        //}

        //[TestCleanup()]
        //public void Cleanup()
        //{
        //    MessageBox.Show("TestMethodCleanup");
        //}

        //[ClassCleanup()]
        //public static void ClassCleanup()
        //{
        //    MessageBox.Show("ClassCleanup");
        //}

        //[AssemblyCleanup()]
        //public static void AssemblyCleanup()
        //{
        //    MessageBox.Show("AssemblyCleanup");
        //}
        [TestMethod]
        public void GetListOfConnections()
        {
            string baseUrl = "http://localhost:7301/api/Connection";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl).Result;

            var results = response.Content.ReadAsAsync<List<RadioComConnConfig>>().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


        }
        [TestMethod]
        public void ReadMajorTest()
        {
            string baseUrl = "http://localhost:7301/api/Radio/Flex/RM";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl).Result;

            var results = response.Content.ReadAsAsync<MajorSettings>().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostSetModeDummyTest()
        {
            string baseUrl = "http://localhost:7301/api/Radio/Dummy/";
            var client = new HttpClient();

            var cmdReq = new RadioCmd();
            var setting = new SettingValue();
            setting.Setting = "Mode";
            setting.Value = "USB";
            cmdReq.Settings.Add(setting);

            HttpResponseMessage response = client.PostAsJsonAsync(baseUrl, cmdReq).Result;

            var results = response.Content.ReadAsAsync<RadioCmd>().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostSetModeFlexTest()
        {
            string baseUrl = "http://localhost:7301/api/Radio/Flex/";
            var client = new HttpClient();

            var cmdReq = new RadioCmd();
            var setting = new SettingValue();
            setting.Setting = "Mode";
            setting.Value = "USB";
            cmdReq.Settings.Add(setting);

            HttpResponseMessage response = client.PostAsJsonAsync(baseUrl, cmdReq).Result;

            var results = response.Content.ReadAsAsync<RadioCmd>().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
