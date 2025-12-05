using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SHMIP.Test
{
    [TestClass]
    public class test6
    {
        [TestMethod]
        public void TestLoadProducts_FilterByManufacturer()
        {
  
            var form = new ProductForm(new AutorizationForm()); 

            
            form.comboBox1.SelectedItem = "Tefal"; 

    
            form.OnManufacturerSelected(null, EventArgs.Empty); 

 
            Assert.IsNotNull(form.flowLayoutPanel1.Controls); 
            Assert.IsTrue(form.flowLayoutPanel1.Controls.Count > 0);
        }
    }
}
