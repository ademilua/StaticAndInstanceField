using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaticAndInstanceMembersOfClass
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            SomeClass demo = new SomeClass();
              demo.InstanceField= 5;  // only instance fields that is instancefield and instance method are available outside its class
            evaluation myval = new evaluation();
            
            //resultLabel.Text = myval.PerfomCalculation(8, 9).ToString();
            evaluation2 val1 = new evaluation2();
            val1.myVar =4;

            evaluation2 val2 = new evaluation2();
            val2.myVar = 13;

          evaluation2.PerfomCalculation(8, 12);
            evaluation3.ObjectCounter = 0;
            evaluation3 valu1 = new evaluation3();
            evaluation3 valu2 = new evaluation3();
            resultLabel.Text = evaluation3.ObjectCounter.ToString();

        }
       
    }
    public class SomeClass
    {
        public static int StaticField;
        public int InstanceField;

        public static void StaticMethod() { }
        public void InstanceMethod() { }
    }
    public class evaluation  // when to use static :Notice how the static method PerformCalculation() references the other static method handleSomePartOfTheCalculation(). This is perfectly fine, however, it would not be possible for the static method to reference an instance method even if they both belong to the same class:
    {
        public static int PerfomCalculation(int one, int two)
        {
            return handleSomePartOfTheCalculation(one, two);
        }
        private static int handleSomePartOfTheCalculation(int one, int two)
        {
            return one + two;
        }
         
    }
    public class evaluation2  // when to use static :Notice how the static method PerformCalculation() references the other static method handleSomePartOfTheCalculation(). That  was perfectly fine, however, it would not be possible for the static method to reference an instance method even if they both belong to the same class:
    {
        //The reason this is not allowed is because instance methods, in principle, have access to (1) instance fields, properties, and methods with its own class. If handleSomePartOfTheCalculation() were to (2) reference an instance property, then PerfomCalculation() would (3) also be referencing that instance property (although indirectly). However, since PerformCalculation() is statically accessible, handleSomePartOfTheCalculation() wouldn’t know what instance, if any, is being referenced:
        public int myVar { get; set; }
        public static int PerfomCalculation(int one, int two) // static 
        {
           return handleSomePartOfTheCalculation(one, two);
        }
        private  int handleSomePartOfTheCalculation(int one, int two) //not static
        {
            return one + two + myVar;
        }

    }
    public class evaluation3  // An Instance Can Reference a Static, But not Vice Versa
    {
        public int PerfomCalculation(int one, int two) // not static
        {
            return handleSomePartOfTheCalculation(one, two);
        }
        private static int handleSomePartOfTheCalculation(int one, int two)  // static
        {
            return one + two;
        }
        public static int ObjectCounter { get; set; }
        public evaluation3()
        {
            ObjectCounter++;
        }
    }


}