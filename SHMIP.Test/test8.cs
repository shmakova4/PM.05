using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SHMIP.Test
{
    [TestClass]
    public class test8
    {
        [TestMethod]
        public void TestRadioButton_CheckedChanged_SortAscending()
        {
          
            var form = new ProductForm(new AutorizationForm()); 

            form.radioButton1.Checked = true; 

            form.RadioButton_CheckedChanged(form.radioButton1, EventArgs.Empty); 

            Assert.AreEqual("ASC", form.GetCurrentSortOrder()); 
        }
    }
}
