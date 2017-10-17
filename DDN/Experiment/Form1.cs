using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib;

namespace Experiment
{
    //////////////////////////////

    public interface IMyinter
    {
        void eat();
    }

   


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();           
        }

   

        private void button3_Click(object sender, EventArgs e)
        {


            int[] values = { 0, 0x111, 0xfffff, 0x8888, 0x22000022 };
            foreach (int v in values)
            {
                Debug.WriteLine("~0x{0:x8} = 0x{1:x8}", v, ~v);
            }
            //      MyInter myInter = new MyInter();
            ////      OtherInter otherInter = new OtherInter();
            //      MyInter2 myinter2 = new MyInter2();
            //    test(myinter2);
            //   Debug.Print((2<<3).ToString());
        }
      
        //在这个方法中，参数是一个接口
        void test(IMyinter aa)
        {
            aa.eat();
        }
    }

    public class MyInter : IMyinter
    {
        public virtual void eat()
        {
            Debug.Print("这是我的eat");
        }
    }
    public class MyInter2 : MyInter
    {
        public override  void eat()
        {
            Debug.Print("这是我的2eat");
         //   int a = 0;
            int i = 0;
            if (true & ++i == 1)
            {
                // i is incremented, but the conditional
                // expression evaluates to false, so
                // this block does not execute.
                Debug.Print("这是我的2eat");
            }
        }
    }

    public class OtherInter : IMyinter
    {
        public virtual void eat()
        {
            Debug.Print("这是other的eat");
        }
    }
}