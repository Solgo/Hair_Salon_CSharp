using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;


namespace HairSalon.Test
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-GC3DC7B\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
    [Fact]
    public void Test_StylistTableEmpty_True()
    {
      //Arrange,Act
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0,result);
    }
    [Fact]
    public void Test_SavesStylistToDatabase()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jim","9am-5pm","Monday-Friday");
      newStylist.Save();
      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{newStylist};
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_AssignsIdToObject()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jim","9am-5pm","Monday-Friday");
      newStylist.Save();
      //Act
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetId();
      int expected = newStylist.GetId();

      //Assert
      Assert.Equal(result, expected);
    }
    [Fact]
    public void Test_Find_FindStylist()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jim","9am-5pm","Monday-Friday");
      newStylist.Save();
      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      //Assert
      Assert.Equal(foundStylist, newStylist);
    }
    [Fact]
    public void Test_Update_UpdatesStylistInDatabase()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jimbo","12pm-2pm","Tuesdays");
      newStylist.Save();
      string newHours = "11am-3pm";
      newStylist.Update("Jimbo",newHours,"Tuesdays");
      //Act
      string result = newStylist.GetWorkHours();
      //Assert
      Assert.Equal(result, newHours);
    }
    [Fact]
    public void Test_Delete_DeletesInstanceFromDatabase()
    {
      //Arrange
      Stylist newStylist1 = new Stylist("Jimbo Fisher","9am-2pm","Wednesdays-Tuesdays");
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Jimbo","12pm-2pm","Tuesdays");
      newStylist2.Save();

      Client newClient1 = new Client("Mary", newStylist1.GetId());
      newClient1.Save();
      Client newClient2 = new Client("Susan", newStylist2.GetId());
      newClient2.Save();
      //Act
      newStylist1.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylists = new List<Stylist> {newStylist2};
      //Assert
      Assert.Equal(resultStylists, testStylists);
    }
  }
}
